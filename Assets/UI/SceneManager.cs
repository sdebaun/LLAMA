using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour {

    public List<Animator> startOpen = new List<Animator>();
    public float openDelaySeconds;

    void Start() {
        StartCoroutine(ProgressiveReveal());
    }

    IEnumerator ProgressiveReveal() {
        foreach (Animator a in startOpen) {
            a.gameObject.SetActive(true);
            a.SetTrigger("Open");
            yield return new WaitForSeconds(openDelaySeconds);
        }

    }
}
