using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerController : MonoBehaviour
{
    public GameObject head;

    public float m_Sensitivity = 1.0f; // -1 to 1
    public float m_MaxSpeed = 1.0f;

    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;

    private float m_Speed = 0.0f;

    private CharacterController m_CharacterController = null;

    private void Awake()
    {
        Debug.Log("Started Movement Calculation Script");
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
        if (m_MovePress.GetStateUp(SteamVR_Input_Sources.Any))
        {
            m_Speed = 0;
        }

        // if button pressed
        if (m_MovePress.state)
        {
            // add, clamp
            m_Speed += m_MoveValue.axis.y * m_Sensitivity;
            m_Speed = Mathf.Clamp(m_Speed, -m_MaxSpeed, m_MaxSpeed); // can reduce backward speed here

            // orientation - moving in the direction we are looking at
            movement += orientation * (m_Speed * Vector3.forward) * Time.deltaTime;
        }

        // apply
        m_CharacterController.Move(movement);
    }
}