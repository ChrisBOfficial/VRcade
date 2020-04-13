using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltTransfer : MonoBehaviour
{
    public Vector3 movePosition;
    private void OnCollisionEnter(Collision otherThing)
    {
        otherThing.gameObject.transform.position = movePosition;
    }
}
