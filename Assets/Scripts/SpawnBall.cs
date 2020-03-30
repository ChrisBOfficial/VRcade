using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public float timeBetweenPitches;
    public GameObject ball;
    public GameObject blueball;
    public float launchAngle;

    int count = 0;

    void Start()
    {
        StartCoroutine(Pitch());
    }

    private IEnumerator Pitch() {
    	while(true) {
    		yield return new WaitForSeconds(timeBetweenPitches);
    		Vector3 launchDirection = GetLaunchDirection();
    		Quaternion q = Quaternion.Euler(launchDirection);

    		if(count == 0) {
    			Instantiate(ball, transform.position, q);
    			count++;
    		}
    		else {
    			Instantiate(blueball, transform.position, q);
    			count--;
    		}
    	}
    }

    private Vector3 GetLaunchDirection() {
    	return new Vector3(Random.Range(-launchAngle, launchAngle), 180, Random.Range(0f, 180f));
    }
}
