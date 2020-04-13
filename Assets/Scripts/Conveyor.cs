using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;
    public float visualSpeedScalar;

    private Vector3 direction;
    private float currentScroll;

    private void Update()
    {
        // Scroll texture to appear moving
        currentScroll = currentScroll + Time.deltaTime * speed * -visualSpeedScalar;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(currentScroll, 0);
    }

    private void OnCollisionStay(Collision otherThing)
    {
        direction = -transform.right * speed;
        if (otherThing.gameObject.tag == "RobotBody") {
            otherThing.gameObject.transform.position = new Vector3(otherThing.gameObject.transform.position.x - 0.018f, otherThing.gameObject.transform.position.y, otherThing.gameObject.transform.position.z);
            // otherThing.rigidbody.AddForce(direction, ForceMode.Acceleration);
        } else if (otherThing.gameObject.tag == "RobotHead") {
            otherThing.gameObject.transform.position = new Vector3(otherThing.gameObject.transform.position.x - 0.006f, otherThing.gameObject.transform.position.y, otherThing.gameObject.transform.position.z);
        } else {
            otherThing.gameObject.transform.position = new Vector3(otherThing.gameObject.transform.position.x - 0.006f, otherThing.gameObject.transform.position.y, otherThing.gameObject.transform.position.z);
        }
    }
}
