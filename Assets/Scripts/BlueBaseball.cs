using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class BlueBaseball : MonoBehaviour
{

	public static bool hold = false;
    private AudioSource src;
    public TrailRenderer t;

    private Rigidbody rb;
    private float velocityMax = 200f;

    //Vector3 velocity;
    //SteamVR_Action_Pose pose = SteamVR_Input.GetAction<SteamVR_Action_Pose>("Pose");

    void Awake() {
    	src = gameObject.GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Random.Range(4f, 6f), ForceMode.Impulse);
        Destroy(gameObject, 7f);
    }

    private void OnCollisionEnter(Collision collision) {
    	if(collision.gameObject.name == "BlueBat" && hold == true) {
    		rb.velocity = Vector3.zero;
    		src.Play();
    		Physics.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider>(), gameObject.GetComponent<SphereCollider>());

    		float forceMultiplier = GetBatForce(collision.gameObject.GetComponent<Rigidbody>(), collision);
    		Vector3 direction = (transform.position - collision.contacts[0].point).normalized;
    		rb.AddForce(direction * forceMultiplier, ForceMode.Impulse);
    		rb.useGravity = true;

    		t.enabled = true;
    		Destroy(gameObject, 8f);
    	}
    }

    private float GetBatForce(Rigidbody batRB, Collision collision) {
    	//get the velocity
    	return Random.Range(collision.relativeVelocity.magnitude / 20, collision.relativeVelocity.magnitude * 20) / velocityMax * 100f;
    }
}
