//This script is attached to each car debris that is instantiated by car explosion.

using UnityEngine;
using System.Collections;

public class CarDebris : MonoBehaviour 
{

	 float time;
	 float destroyTime;
	 float RandPosX,RandPosY,RandPosZ;
	
	// Use this for initialization
	void Start () 
	{
		time=0;
		destroyTime= Random.Range(0.7f,1.5f);
		
		RandPosX=Random.Range(-2,2);
		RandPosY=Random.Range(-2.5f,2.5f);
		RandPosZ=Random.Range(-3,3);
		
		transform.position+= new Vector3(RandPosX,RandPosY,RandPosZ);
		
		transform.rigidbody.velocity= new Vector3(Random.Range(-5,5),Random.Range(7,15),Random.Range(-7,20));
		transform.rigidbody.angularVelocity= new Vector3(0,0,Random.Range(-5,5));
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(time>destroyTime)
		{
			Destroy(gameObject);
			//print(destroyTime);
		}	
		time+=Time.deltaTime;
		
	}
}
