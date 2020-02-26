using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerController : MonoBehaviour
{
    public GameObject head;

    public SteamVR_Action_Boolean m_WalkPress = null;
    public SteamVR_Action_Vector2 m_WalkValue = null;

    public SteamVR_Action_Boolean m_RunPress = null;
    public SteamVR_Action_Vector2 m_RunValue = null;

    private float m_Sensitivity = 1.0f; // -1 to 1
    private float m_MaxSpeed = 1.0f;

    private float m_Speed = 0.0f;

    private CharacterController m_CharacterController = null;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        // figure out movement orientation
        Vector3 orientationEuler = new Vector3(0, head.transform.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        // if not moving
        if (m_RunPress.GetStateUp(SteamVR_Input_Sources.Any))
        {
            m_Speed = 0;
        }

        // if button pressed
        if (m_RunPress.state)
        {
            // add, clamp
            m_Speed += m_RunValue.axis.y * m_Sensitivity;
            m_Speed = Mathf.Clamp(m_Speed, -m_MaxSpeed, m_MaxSpeed); // can reduce backward speed here

            // orientation - moving in the direction we are looking at
            movement += orientation * (m_Speed * Vector3.forward) * Time.deltaTime;
        }

        // apply
        m_CharacterController.Move(movement);
    }
}