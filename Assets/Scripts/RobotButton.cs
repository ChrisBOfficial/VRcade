using UnityEngine;
using Valve.VR.InteractionSystem;

public class RobotButton : MonoBehaviour
{
    public void onPress(Hand hand)
    {
        GameObject robot = GameObject.FindGameObjectsWithTag("Robot")[0];
        robot.GetComponent<RobotModeChanger>().ChangeMode(true);
    }
}
