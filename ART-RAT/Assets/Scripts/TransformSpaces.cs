using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSpaces : MonoBehaviour
{
    public bool position_on = false;
    public bool rotation_on = false;

    public float magnitude_scale;
    public GameObject source_transform;
    public GameObject target_transform;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //position
        if (position_on) target_transform.transform.localPosition = source_transform.transform.position * magnitude_scale;

        //rotation
        if (rotation_on) target_transform.transform.localEulerAngles = source_transform.transform.eulerAngles * magnitude_scale;
    }
}
