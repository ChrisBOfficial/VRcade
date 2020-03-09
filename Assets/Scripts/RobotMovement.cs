using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;

    public Transform player;

    public enum Modes { unprogrammed, programmed, followPlayer };
    public Modes currentMode;
    
    
    private int current = 0;
    private float rotSpeed;
    private float WPradius = 0.5f;

    void Start()
    {
         currentMode = Modes.unprogrammed;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentMode)
        {
            case Modes.unprogrammed:
                if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
                {
                    current = Random.Range(0, waypoints.Length);
                }
                transform.position = Vector3.MoveTowards(transform.position, waypoints[current].position, Time.deltaTime * speed);
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
