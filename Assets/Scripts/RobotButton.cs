using UnityEngine;
using Valve.VR.InteractionSystem;

public class RobotButton : MonoBehaviour
{
    private float timeToReset;
    private bool timerIsActive;
    private GameObject robot;

    void Start()
    {
        timeToReset = 0;
        robot = GameObject.FindGameObjectsWithTag("Robot")[0];
        timerIsActive = false;
    }

    void Update()
    {
        if (timerIsActive)
        {
            Debug.Log(timeToReset);
            timeToReset -= Time.deltaTime;
            if (timeToReset <= 0)
            {
                timerIsActive = false;
                robot.GetComponent<RobotModeChanger>().ChangeMode(false);
            }
        }
    }

    public void onPress(Hand hand)
    {
        timeToReset = 10f;
        timerIsActive = true;
        robot.GetComponent<RobotModeChanger>().ChangeMode(true);
    }
}
