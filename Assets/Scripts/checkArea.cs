using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkArea : MonoBehaviour
{
	public static bool wherePlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(gameObject.transform.position.x > 8 && gameObject.transform.position.x < 16 
    		&& gameObject.transform.position.z > 4.5 && gameObject.transform.position.z < 12.5) {
   
     		wherePlayer = true;
     	}
        
    }
}
