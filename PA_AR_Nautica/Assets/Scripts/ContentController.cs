using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ContentController : MonoBehaviour
{
    public Transform MainCamera;
    public void AlignContentToCamera(Transform objectToAlign)
    {
        Vector3 lookAtPosition = MainCamera.position - objectToAlign.position;
        lookAtPosition.y = 0f;
        var rotation = Quaternion.LookRotation(lookAtPosition);
        objectToAlign.rotation = rotation;
    }
}
