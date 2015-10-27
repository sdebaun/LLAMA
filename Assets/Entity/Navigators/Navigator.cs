﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Pathfinding;

// used: in creep prefab
public class Navigator : MonoBehaviour {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public string destinationName;
    //public NavMeshAgent agent;
    public float moveSpeedMax = 2.5f, moveSpeedMin = 5.0f;

    private Rigidbody rb;

    //The point to move to
    public Vector3 targetPosition;
    public Seeker seeker;
    private CharacterController controller;
    //The calculated path
    public Path path;
    //The AI's speed per second
    public float speed = 100;
    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;
    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    public void Start() {
        //seeker = GetComponent<Seeker>();
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(moveSpeedMax, moveSpeedMin);
        targetPosition = GameObject.Find(destinationName).transform.position;
        //Start a new path to the targetPosition, return the result to the OnPathComplete function
        seeker.StartPath(transform.position, targetPosition, OnPathComplete);
    }

    public void OnPathComplete(Path p) {
        //Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
        if (!p.error) {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
        }
    }

    public void Update() {
        //print("Navigator.Update");
        if (path == null) {
            //We have no path to move after yet
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count) {
            // Debug.Log("End Of Path Reached");  // This was brutalizing the android lol
            return;
        }
        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.deltaTime;
        //controller.SimpleMove(dir);
        // MovePosition() seems to go too slow the way we're using it--probably should be used in FixedUpdate()
        //rb.MovePosition(dir + rb.transform.position);
        // Let's try setting the position every Update
        transform.position += dir;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);

        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
            currentWaypoint++;
            return;
        }
    }
} 

