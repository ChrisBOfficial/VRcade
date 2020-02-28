using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerController : MonoBehaviour
{
    public GameObject head;

    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;

    private float m_Sensitivity = 0.2f; // -1 to 1
    private float m_MaxWalkSpeed = 2.0f;
    private float m_MaxRunSpeed = 5.0f;

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

        if (m_MoveValue.axis != Vector2.zero)
        {
            Debug.Log(m_MoveValue.axis);
            m_Speed += m_MoveValue.axis.y * m_Sensitivity;
            if (m_MovePress.state)
            {
                m_Speed = Mathf.Clamp(m_Speed, -m_MaxRunSpeed, m_MaxRunSpeed); // set run speed
            }
            else
            {
                m_Speed = Mathf.Clamp(m_Speed, -m_MaxWalkSpeed, m_MaxWalkSpeed); // set walk speed
            }
            
        }
        else
        {
            m_Speed = 0;
            Debug.Log("Stopped!");
        }
        movement += orientation * (m_Speed * Vector3.forward) * Time.deltaTime;

        // apply
        m_CharacterController.Move(movement);
    }
}