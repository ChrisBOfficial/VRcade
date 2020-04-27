using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(gameObject.transform.position.x > 15 || gameObject.transform.position.x < -35
    		|| gameObject.transform.position.y < -10 || gameObject.transform.position.z > 15
    		|| gameObject.transform.position.z < -35) {
    		transform.position = new Vector3(0f, 0f, 0f);
    	}
        
    }
}
