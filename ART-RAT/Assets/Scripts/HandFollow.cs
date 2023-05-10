using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollow : MonoBehaviour
{
    public GameObject item;

    void LateUpdate()
    {
        transform.position = item.transform.position;
    }
}
