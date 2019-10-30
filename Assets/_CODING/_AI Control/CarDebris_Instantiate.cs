using UnityEngine;
using System.Collections;

public class CarDebris_Instantiate: MonoBehaviour 
{

	public GameObject CarDebris1; 
	public GameObject CarDebris2;
	public GameObject CarDebris3;
	public GameObject CarDebris4;
	public GameObject CarDebris5;
	public GameObject CarDebris6;
	public GameObject CarDebris7;
	
	int Rand1,Rand2;
	
	
	
	
	
	// Use this for initialization
	void Start () 
	{
		
		Rand1= (int)Random.Range(1,4);
		Rand2= (int)Random.Range(4,8);
		//print("Rand1="+Rand1);
		
	
		switch(Rand1)
		{
			case 1: Instantiate(CarDebris1,transform.position,transform.rotation); break;
			case 2: Instantiate(CarDebris2,transform.position,transform.rotation); break;
			case 3: Instantiate(CarDebris3,transform.position,transform.rotation); break;

		}
	
		switch(Rand2)
		{
			case 4: Instantiate(CarDebris4,transform.position,transform.rotation); break;
			case 5: Instantiate(CarDebris5,transform.position,transform.rotation); break;
			case 6: Instantiate(CarDebris6,transform.position,transform.rotation); break;
			case 7: Instantiate(CarDebris7,transform.position,transform.rotation); break;
		}	
	
		Instantiate(CarDebris1,transform.position,transform.rotation); 
	
	}
	
}
