using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
  private Vector3 screenPoint;
  private Vector3 offset;
  private bool check = false;

  private bool doorState = false;
  public Transform door;
  
  // Start is called before the first frame update
  void Start () {
  
  }

 
 void Update () {
     
     if(gameObject.transform.position.y > 1.15 && gameObject.transform.position.y < 1.3) {
     	gameObject.GetComponent<Renderer>().material.color = Color.green;
     	if(check == false) {
     		Check.count++;
     		check = true;
        Debug.Log("count " + Check.count);
     	}
        if (Check.count == 2 && doorState == false) {
            doorState = true;
            Debug.Log("Door");
            door.transform.rotation = Quaternion.Euler(0.0f, 0f, 0.0f);
            door.transform.position = new Vector3(door.transform.position.x + 0.6f, door.transform.position.y, transform.position.z + 3.8f);
        }
     }
     else {
     	gameObject.GetComponent<Renderer>().material.color = Color.red;
     	if(check == true) {
     		Check.count--; 
     		check = false;
        Debug.Log("count " + Check.count);
     	}
     }
 }

 void OnMouseDown()
 {
     screenPoint = Camera.main.WorldToScreenPoint(transform.position);
     offset =  transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,screenPoint.z));
 }

 void OnMouseDrag()
 {
     Vector3 curScreenPoint = new Vector3(0f, Input.mousePosition.y, screenPoint.z);
     Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
     curPosition.x = transform.position.x;
	 curPosition.z = transform.position.z;
     transform.position = curPosition;
 }
 
}
