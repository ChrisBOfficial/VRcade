using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : MonoBehaviour
{
	private bool check = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(checkArea.wherePlayer == true && check == false) {
     		check = true;
     		transform.Rotate(0.0f, 270.0f, 0.0f, Space.Self);
     	}
     	if(Check.count == 2) {
     		transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
     	}
    }
}
