using UnityEngine;
using System.Collections;

public class _CoinsController : MonoBehaviour {

	private Ray ray;
	private RaycastHit hit;
	private bool isLanding;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

 
		if(Physics.Raycast(transform.position, -Vector3.up,out hit,3) && !isLanding){

			if(hit.collider.tag=="ground" || hit.collider.tag=="coins"){
				isLanding = true;
  				Destroy(rigidbody);
			}
 
		}

	
	}

}
