using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;

    public Transform player;

    public enum Modes { notbuilt, built, fix, stay };
    public Modes currentMode;
    
    
    private int current = 0;
    private float rotSpeed;
    private float WPradius = 0.1f;
    private float timeToFix = 0f;

    void Start()
    {
         currentMode = Modes.notbuilt;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentMode)
        {
            case Modes.built:
                if (Vector3.Distance(waypoints[current].position, this.transform.position) < WPradius)
                {
                    if (current == 4) {
                        timeToFix = 3.0f;
                        currentMode = Modes.fix;
                        break;
                    }
                    current++;
                }
                Vector3 waypointDirection = waypoints[current].position - this.transform.position;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(waypointDirection), 0.02f);
                this.transform.Translate(0, 0, speed * Time.deltaTime);
                break;
            case Modes.fix:
                timeToFix -= Time.deltaTime;
                if (timeToFix < 0) {
                    current++;
                    currentMode = Modes.built;
                }
                break;
            case Modes.notbuilt:
                if (transform.position.y > 0)
                {
                    currentMode = Modes.built;
                }
                break;
        }
        
    }
}
