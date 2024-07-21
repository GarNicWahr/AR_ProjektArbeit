using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARKompass : MonoBehaviour
{
    public Transform compassNeedle;

    // Start is called before the first frame update
    void Start()
    {

        Input.compass.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        float magneticHeading = Input.compass.trueHeading;

        Quaternion targetRotation = Quaternion.Euler(-89.98f, -magneticHeading, 0);

        compassNeedle.rotation = targetRotation;

    }
}
