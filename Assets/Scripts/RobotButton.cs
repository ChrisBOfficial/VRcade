using UnityEngine;
using Valve.VR.InteractionSystem;

public class RobotButton : MonoBehaviour
{
    // public RobotMovement robot;

    public void onPress(Hand hand)
    {
        Debug.Log("Triggered");
    }
}
