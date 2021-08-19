using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTargetMover : MonoBehaviour
{
    public float speedSpine = 180.0f;
    public float motionMagnitude = 0.1f;
    public bool doSpine = true;
    public bool doMotion = false;
    // Update is called once per frame
    void Update()
    {
        if (doSpine) {
            gameObject.transform.Rotate(Vector3.up * speedSpine * Time.deltaTime);
        }
        if (doMotion)
        {
            gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
        }   
    }
}
