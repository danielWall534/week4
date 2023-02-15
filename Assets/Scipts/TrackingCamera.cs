using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    public Transform ObjectToTrack;
    Vector3 targetPosition;

    void Update()
    {
        //Set X and Y to be ObjectToTrack X and Y 
        targetPosition = ObjectToTrack.position;
        //Z is the same as the camera depth (z)
        targetPosition.z = transform.position.z;
        //Update the camera position to match the ObjectToTrack position
        transform.position = targetPosition;
    }
}
