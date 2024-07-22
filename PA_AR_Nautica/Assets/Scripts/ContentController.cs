using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ContentController : MonoBehaviour
{
    public void AlignContentToCamera(Transform objectToAlign)
    {
        Vector3 lookAtPosition = Camera.main.transform.position - objectToAlign.position;
        lookAtPosition.y = 0f;
        var rotation = Quaternion.LookRotation(lookAtPosition);
        objectToAlign.rotation = rotation;
    }
}
