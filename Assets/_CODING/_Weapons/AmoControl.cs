using UnityEngine;
using System.Collections;

public class AmoControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnCollisionEnter(Collision collision){
		
		if(collision.gameObject.tag =="Player"){
				Destroy(gameObject);
			
		}else if(collision.gameObject.tag =="Enemy"){
	
				Destroy(gameObject);
		}
		
		
		
	}
	
	

}
