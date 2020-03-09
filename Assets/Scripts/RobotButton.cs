using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotButton : MonoBehaviour
{
    public RobotMovement robot;

    void onTriggerEnter(Collider collider)
    {
        Debug.Log("Triggered");
        Debug.Log(collider.gameObject.tag);
        // if (collider.gameObject.CompareTag("Hand"))
        // {
        //     robot.ChangeMode(true);
        // }
    }
}
