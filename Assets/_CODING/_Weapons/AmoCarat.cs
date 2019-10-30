using UnityEngine;
using System.Collections;

public class AmoCarat : MonoBehaviour {
	
	//amo carat;	
	public GameObject Bullet;
	//public GameObject Rocket;
	
	//amo Instantiate position
	public GameObject way1;
	public GameObject way2;
	public GameObject way3;
	public GameObject way4;
	public GameObject way5;
	public GameObject way6;

	
	private float time;
	private int randAmmo;

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		GameObject bulletAmo;
		//GameObject rocketAmo;
		
		time += Time.deltaTime;
		
		if(time > 1F){
			
			randAmmo = Random.Range(0,6);
			
			switch(randAmmo){
			
			case 1:
					
					bulletAmo = Instantiate(Bullet, way1.transform.position, way1.transform.rotation) as GameObject;
					
					break;
			case 2:
					bulletAmo = Instantiate(Bullet, way2.transform.position, way2.transform.rotation) as GameObject;
				
					break;
			case 3:
					bulletAmo = Instantiate(Bullet, way3.transform.position, way3.transform.rotation) as GameObject;
					
					break;
			case 4:
					
					bulletAmo = Instantiate(Bullet, way4.transform.position, way4.transform.rotation) as GameObject;
				
					break;
			case 5:
				
					bulletAmo = Instantiate(Bullet, way5.transform.position, way5.transform.rotation) as GameObject;
				
					break;
			default:
				
					bulletAmo = Instantiate(Bullet, way6.transform.position, way6.transform.rotation) as GameObject;
				
					break;
				
			}
		
			time = 0;
			
		}
		
		
		
	
	}
}
