using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : MonoBehaviour
{
    private bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     	if(Check.count == 2 && open == false) {
            open = true;
     		transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);

            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
     	}
    }
}
