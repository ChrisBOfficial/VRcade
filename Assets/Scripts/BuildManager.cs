using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class BuildManager : MonoBehaviour
    {
        public Throwable _head;
        public Throwable _body;
        public Throwable _leftArm;
        public Throwable _rightArm;

        public GameObject p_wheels;
        public GameObject p_armLeft;
        public GameObject p_armRight;
        public GameObject p_head;
        public GameObject p_body;

        public Vector3 spawnPoint;

        private new Rigidbody rigidbody;
        private bool completed = false;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (!completed && _head.readyDestroy && _body.readyDestroy && _leftArm.readyDestroy && _rightArm.readyDestroy)
            {
                completed = true;
                p_wheels.SetActive(false);
                p_armLeft.SetActive(false);
                p_armRight.SetActive(false);
                p_head.SetActive(false);
                p_body.SetActive(false);
                transform.position = spawnPoint;
            }
        }
    }
}