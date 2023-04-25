using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class GiantController : MonoBehaviour
{
    Animator animator;
    public XRNode inputSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        bool triggerValue = false;
        if(device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue)
        && triggerValue) {
            animator.SetInteger("state", 1);
        }
        else {
            animator.SetInteger("state", 0);
        }
    }
}
