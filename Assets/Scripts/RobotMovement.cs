using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour, RobotModeChanger
{
    public Transform[] waypoints;
    public float speed;

    public Transform player;

    public enum Modes { notbuilt, unprogrammed, programmed, followPlayer };
    public Modes currentMode;

    private Transform currentWaypoint;
    private int current;
    private float rotSpeed;
    private float WPradius = 1f;

    void Start()
    {
         currentMode = Modes.notbuilt;
         current = 0;
         currentWaypoint = waypoints[current];
    }

    // Make sure it stays on ground and is always upright
    void Update()
    {
        switch (currentMode)
        {
            case Modes.unprogrammed:
                if (Vector3.Distance(currentWaypoint.position, this.transform.position) < WPradius)
                {
                    current = Random.Range(0, waypoints.Length);
                    currentWaypoint = waypoints[current];
                }
                Vector3 waypointDirection = currentWaypoint.position - this.transform.position;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(waypointDirection), 0.02f);
                this.transform.Translate(0, 0, speed * Time.deltaTime);
                break;
            case Modes.notbuilt:
                if (this.transform.position.y > 0)
                {
                    currentMode = Modes.unprogrammed;
                }
                break;
            case Modes.followPlayer:
                Vector3 playerDirection = player.position - this.transform.position;
                float angle = Vector3.Angle(playerDirection, this.transform.forward);

                playerDirection.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(playerDirection), 0.01f);
                if (playerDirection.magnitude > 2)
                {
                    this.transform.Translate(0, 0, speed * Time.deltaTime);
                }
                break;
        }
    }

    public void ChangeMode(bool pressed)
    {
        if (pressed)
        {
            currentMode = Modes.followPlayer;
        }
        else
        {
            currentMode = Modes.unprogrammed;
        }
    }
}
