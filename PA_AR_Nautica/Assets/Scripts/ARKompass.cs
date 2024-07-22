using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARKompass : MonoBehaviour
{
    public Transform compassNeedle;
    public Transform targetPosition;

    // Start is called before the first frame update
    void Start()
    {

        Input.compass.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        float magneticHeading = Input.compass.trueHeading;

        Quaternion targetRotation = Quaternion.Euler(-90f, magneticHeading, 0);

        compassNeedle.rotation = targetRotation;
        compassNeedle.position = targetPosition.position;

    }
}
