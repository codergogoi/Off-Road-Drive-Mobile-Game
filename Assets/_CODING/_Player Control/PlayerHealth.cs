using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	private int rocketHit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnCollisionEnter(Collision collision) 
	{
		
		if(collision.gameObject.name == "Rocket(Clone)")
		{
			rocketHit+=1;
			
			if (rocketHit >=3)
			{
				
				transform.rigidbody.velocity= new Vector3(Random.Range(-5,5),Random.Range(15,25),Random.Range(20,35));
				transform.rigidbody.angularVelocity= new Vector3(0,0,Random.Range(-5,5));
				
				rocketHit = 0;
				
			}
		
			
			
		}
	}
}
