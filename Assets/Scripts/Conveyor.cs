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
        otherThing.rigidbody.AddForce(direction, ForceMode.Acceleration);
    }
}
