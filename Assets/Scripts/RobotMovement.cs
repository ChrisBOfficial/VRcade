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
    private int current = 0;
    private float rotSpeed;
    private float WPradius = 0.5f;

    void Start()
    {
         currentMode = Modes.notbuilt;
         currentWaypoint = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentMode)
        {
            case Modes.unprogrammed:
                Debug.Log(Vector3.Distance(currentWaypoint.transform.position, transform.position));
                if (Vector3.Distance(currentWaypoint.transform.position, transform.position) < WPradius)
                {
                    Debug.Log("Test");
                    current = Random.Range(0, waypoints.Length);
                    currentWaypoint = waypoints[current];
                }
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentWaypoint.position), 0.1f);
                // transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, Time.deltaTime * speed);
                transform.Translate(0, 0, speed * Time.deltaTime);
                break;
            case Modes.notbuilt:
                if (transform.position.y > 0)
                {
                    currentMode = Modes.unprogrammed;
                }
                break;
            case Modes.followPlayer:
                Vector3 playerDirection = player.position - transform.position;
                float angle = Vector3.Angle(playerDirection, transform.forward);

                playerDirection.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerDirection), 0.1f);

                if (playerDirection.magnitude > 5)
                {
                    transform.Translate(0, 0, speed * Time.deltaTime);
                }
                break;
        }
        
    }

    public void ChangeMode(bool pressed)
    {
        Debug.Log("Changing Mode");
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
