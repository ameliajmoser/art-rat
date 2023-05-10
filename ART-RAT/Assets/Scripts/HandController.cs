using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject item;
    public GameObject hand;

    void LateUpdate()
    {
        Transform itempos = item.transform;
        hand.transform.position = new Vector3(itempos.position.x, (itempos.position.y - 0.1f), itempos.position.z);
    }
}


