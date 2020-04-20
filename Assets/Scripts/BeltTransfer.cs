using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltTransfer : MonoBehaviour
{
    private void OnCollisionEnter(Collision otherThing)
    {
        otherThing.gameObject.transform.position = new Vector3(otherThing.gameObject.transform.position.x, otherThing.gameObject.transform.position.y, otherThing.gameObject.transform.position.z + 14);
    }
}
