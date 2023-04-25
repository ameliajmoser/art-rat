using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// References https://www.youtube.com/watch?v=pPDIFBxX7Gs&ab_channel=Mr.PineappleStudio
public class HairController : MonoBehaviour {

    public Transform hairStrand;

    [SerializeField] 
    private float forwardBackwardTilt = 0;
    [SerializeField]
    private float sideToSideTilt = 0;

    // Update is called once per frame
    void Update()
    {
        forwardBackwardTilt = hairStrand.rotation.eulerAngles.x;
        if(forwardBackwardTilt < 355 && forwardBackwardTilt > 290) {
            forwardBackwardTilt = Math.Abs(forwardBackwardTilt - 360);
            // Move arms using forwardBackwardTilt value
        }
        
        sideToSideTilt = hairStrand.rotation.eulerAngles.z;
        if(sideToSideTilt < 355 && sideToSideTilt > 290) {
            sideToSideTilt = Math.Abs(sideToSideTilt - 360);
            // Turn arms? 
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.CompareTag("PlayerHand")) {
            transform.LookAt(other.transform.position, transform.up);
        }
    }

}
