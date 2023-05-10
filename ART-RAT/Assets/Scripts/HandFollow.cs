using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollow : MonoBehaviour
{
    public GameObject brush;

    void Update()
    {
        transform.position = brush.transform.position;
    }
}
