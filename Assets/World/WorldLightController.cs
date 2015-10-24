using UnityEngine;
using UnityEngine.Networking;

// used by worldlight in world scene
public class WorldLightController : NetworkBehaviour {

    public static float angleDawn = 0f;
    public static float angleSunset = 135f;
    public static float angleMidnight = 225f;
    public static float angleDawnWrap = 360f;

    [SyncVar(hook ="OnSync")]
    private float timeToTarget;
    void OnSync(float f) {
        timeToTarget = f;
        elapsedTime = 0f;
    }

    [SyncVar]
    private float startAngle;
    [SyncVar]
    private float endAngle;

    private float elapsedTime;

    public void RotateToDawn(float duration) { StartRotation(angleMidnight, angleDawnWrap, duration); }
    public void RotateToSunset(float duration) { StartRotation(angleDawn, angleSunset, duration); }
    public void RotateToMidnight(float duration) { StartRotation(angleSunset, angleMidnight, duration); }
    [Server]
    public void StartRotation(float from, float to, float duration) {
        timeToTarget = duration;
        elapsedTime = 0f;
        startAngle = from;
        endAngle = to;
    }

    void Update() {
        if (isClient && (elapsedTime < timeToTarget)) {
            elapsedTime += Time.deltaTime;

            float angle = startAngle + ((endAngle - startAngle) * (elapsedTime / timeToTarget));
            transform.rotation = Quaternion.Euler(angle, -90, 0);
        }
    }

}
