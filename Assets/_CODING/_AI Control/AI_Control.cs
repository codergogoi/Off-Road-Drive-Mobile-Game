using UnityEngine;
using System.Collections;

public class AI_Control : MonoBehaviour {
	
	private int rocketHit = 0;
		
	public GameObject Explosion_AICar;
	public GameObject Car_Debris;
	
	private RaycastHit hit;

	//shoot function
	public GameObject Rocket;
	public Transform Turret_Rocket1;
	public Transform Turret_Rocket2;	
	
	
	private float speed;
	private float time;
	private float FireRateTime;
	
	private int Ammo;
	
	
	// Use this for initialization
	void Start () {
		
		speed=100;
 		time=0.0f;
		FireRateTime=0.0f;
		Ammo = 5000;
	
	}
	
	// Update is called once per frame
	void Update () {
		
				Vector3 left = transform.TransformDirection (Vector3.forward);
			
				if (Physics.Raycast (transform.TransformPoint(0,0,0),left,out hit,10)) {
					
					Debug.DrawLine(transform.position, hit.point, Color.green);
				
					if (hit.collider.gameObject.tag=="Enemy"){
				
				
				if(Ammo > 0){
					
					
					if (FireRateTime>0.8f) //Bullet
						{	
							GameObject rocket1= Instantiate(Rocket, Turret_Rocket1.position,Turret_Rocket1.rotation ) as GameObject;
						   rocket1.rigidbody.velocity = Turret_Rocket1.transform.TransformDirection(new Vector3(0,0,speed) );	
						Physics.IgnoreCollision( rocket1.collider,transform.root.collider);
					
						GameObject rocket2 = Instantiate(Rocket, Turret_Rocket2.position,Turret_Rocket2.rotation ) as GameObject;
									Physics.IgnoreCollision(collider,rocket2.collider );   
						rocket2.rigidbody.velocity = Turret_Rocket2.transform.TransformDirection(new Vector3(0,0,speed) );
							FireRateTime=0.0f;	
						 Ammo = Ammo - 2;
						
						}
			
					time=time+Time.deltaTime;
					FireRateTime+=Time.deltaTime;
				
				}
						
			}
		}
		
		
	
	}
	
	IEnumerator ShowMuzzleFlash( Renderer renderer) 
	{
		// Show muzzle flash when firing
		renderer.transform.localRotation *= Quaternion.Euler(0, 0, Random.Range(-360, 360));
		renderer.enabled = true;
		yield return new WaitForSeconds(0.05f);
		renderer.enabled = false;
	}
	
	
	void OnCollisionEnter(Collision collision) 
	{
		
		if(collision.gameObject.name == "Rocket(Clone)X")
		{
			rocketHit+=1;
			
			if (rocketHit >=3)
			{
				transform.rigidbody.velocity= new Vector3(Random.Range(-5,5),Random.Range(15,25),Random.Range(20,35));
				transform.rigidbody.angularVelocity= new Vector3(0,0,Random.Range(-5,5));
				Invoke("DestroyAICar",0.5f);
				
				rocketHit = 0;
				
			}
		
			
		}
		
		if(collision.gameObject.tag=="ammo"){
			
			Ammo = Ammo + 100;
			
		}
		
	}
	
	
	void DestroyAICar()
		{
			Instantiate(Explosion_AICar,transform.position+ new Vector3(0,0.1f,0),transform.rotation);
			Destroy(gameObject,0.12f);
			Instantiate(Car_Debris,transform.position+ new Vector3(0,0.1f,0),transform.rotation);
		
		}
	
}
