using UnityEngine;
using System.Collections;

public class AI_Reset : MonoBehaviour {
	
	private RaycastHit hit;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		Vector3 top = transform.TransformDirection (Vector3.up);
			
				if (Physics.Raycast (transform.TransformPoint(0,0,0),top,out hit,1.2F)) {
					
					Debug.DrawLine(transform.position, hit.point, Color.red);
				
					if (hit.collider.gameObject.tag=="Ground"){
				
					//reset the car
					StartCoroutine(WaitForCommand(2.0F));
				}
						
			}
		
	}
	
	
	//reset the car position and rotation if the Car is lost it's Gravity
	
	IEnumerator WaitForCommand(float time){
		
		yield return new WaitForSeconds(time);
		transform.eulerAngles = new Vector3(0,0,0);
		transform.position = new Vector3(transform.position.x,transform.position.y - 0.2F, transform.position.z);
		
		
	}
	
	
	
}
