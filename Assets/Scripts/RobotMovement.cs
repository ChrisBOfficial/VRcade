using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public Transform[] waypoints;
    
    public Transform door;

    public GameObject light;

    private float speed;
    private enum Modes { notbuilt, built, fix, stay };
    private Modes currentMode;
    private int current;
    private float rotSpeed;
    private float WPradius;
    private float timeToFix;
    

    void Start()
    {
        light.SetActive(false);
        speed = 3.0f;
        current = 0;
        rotSpeed = 0.02f;
        WPradius = 0.5f;
        timeToFix = 0f;
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
                    if (current == waypoints.Length - 1) {
                        currentMode = Modes.stay;
                        break;
                    }
                    current++;
                }
                Vector3 waypointDirection = waypoints[current].position - this.transform.position;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(waypointDirection), rotSpeed);
                this.transform.Translate(0, 0, speed * Time.deltaTime);
                break;
            case Modes.fix:
                timeToFix -= Time.deltaTime;
                if (timeToFix < 0) {
                    current++;
                    currentMode = Modes.built;
                    light.SetActive(true);
                    door.transform.Rotate(0.0f, -90.0f, 0.0f, 0);
                    door.transform.position = new Vector3(door.transform.position.x - 0.9f, door.transform.position.y, door.transform.position.z + 1);
                }
                break;
            case Modes.notbuilt:
                if (transform.position.y > 0)
                {
                    currentMode = Modes.built;
                }
                break;
            case Modes.stay:
                this.transform.position = waypoints[current].position;
                this.transform.rotation = Quaternion.identity;
                this.enabled = false;
                break;
        }
        
    }
}
