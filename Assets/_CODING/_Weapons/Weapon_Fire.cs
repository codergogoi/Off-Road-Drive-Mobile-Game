using UnityEngine;
using System.Collections;

public class Weapon_Fire : MonoBehaviour 
{

public GUITexture Shoot;
public GUITexture rocketShoot;
	
public GameObject Bullet;
public GameObject  Rocket;
public Transform Turret_Rocket1;
public Transform Turret_Rocket2;	
	
	
private float speed;
private float time;
private float FireRateTime;
private int Ammo;

	/*
private Transform Turret_Bullet1;
private Transform Turret_Bullet2;

private Renderer  Bullet1_MuzzleFlash_renderer;
private Renderer  Bullet2_MuzzleFlash_renderer;

private Renderer  CarExhaustFlame_renderer;	
*/
	
	// Use this for initialization
	void Start () 
	{
		
		speed=120;
 		time=0.0f;
		FireRateTime=0.0f;
		/*
		Turret_Bullet1=transform.FindChild("R_Gun/Turret_Bullet1") as Transform;
		Turret_Bullet2=transform.FindChild("L_Gun/Turret_Bullet2")as Transform;
		
		Bullet1_MuzzleFlash_renderer=transform.Find("R_Gun/Turret_Bullet1/Bullet1_MuzzleFlash").GetComponent<Renderer>() as Renderer;
		Bullet2_MuzzleFlash_renderer=transform.Find("L_Gun/Turret_Bullet2/Bullet2_MuzzleFlash").GetComponent<Renderer>() as Renderer;
		
		Bullet1_MuzzleFlash_renderer.renderer.enabled =false;
		Bullet2_MuzzleFlash_renderer.renderer.enabled =false;
		
		CarExhaustFlame_renderer=transform.FindChild("Exhaust_Flame").GetComponent<Renderer>() as Renderer;
		CarExhaustFlame_renderer.renderer.enabled  =false;
		*/
	}
	
	
	
	
	// Update is called once per frame
	void Update() 
	{
		
		/*
		if(CameraShake.IsCameraNeedToShake)
			CarExhaustFlame_renderer.renderer.enabled  =true;
		else
			CarExhaustFlame_renderer.renderer.enabled  =false;
		
		*/
		/*
		Vector3 touchpos = Input.mousePosition;
		
			
			foreach (Touch touch in Input.touches)
				{
						if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
						 {
							 if (touch.fingerId == 0)
							  {
					
								 if(Shoot.HitTest(touchpos))
									{
										
										if (FireRateTime>0.1f) //Bullet
										{	
											GameObject bullet1 = Instantiate(Bullet,Turret_Bullet1.TransformPoint(0,0,-0.25f),Turret_Bullet1.rotation)as GameObject;
													bullet1.rigidbody.velocity = Turret_Bullet1.transform.TransformDirection(new Vector3(0.0f,0.0f,speed));			
											
											GameObject bullet2 = Instantiate(Bullet,Turret_Bullet2.TransformPoint(0,0,-0.25f),Turret_Bullet2.rotation)as GameObject;
													bullet2.rigidbody.velocity = Turret_Bullet2.transform.TransformDirection(new Vector3(0,0,speed));
											
											StartCoroutine(ShowMuzzleFlash(Bullet1_MuzzleFlash_renderer));
											StartCoroutine(ShowMuzzleFlash(Bullet2_MuzzleFlash_renderer));
											FireRateTime=0.0f;	
										
										}
										
										
									}
					
									else if(Input.GetKeyDown("mouse 0"))
									{
											SendMessage("PlayerPickup", 1);
											CameraShake.IsCameraNeedToShake = true;
											
									} 
									else
									{
										if(SpeedControl.analog== false)
											SendMessage("PlayerPickup", 1);
							
									}
					
							  
									
							  }
				
							  else if (touch.fingerId == 1 && touch.phase == TouchPhase.Began)
							  {
								
									if(Shoot.HitTest(touchpos))
									{
									
												if (FireRateTime>0.1f) //Bullet
												{	
													GameObject bullet1 = Instantiate(Bullet,Turret_Bullet1.TransformPoint(0,0,-0.25f),Turret_Bullet1.rotation)as GameObject;
															bullet1.rigidbody.velocity = Turret_Bullet1.transform.TransformDirection(new Vector3(0.0f,0.0f,speed));			
													
													GameObject bullet2 = Instantiate(Bullet,Turret_Bullet2.TransformPoint(0,0,-0.25f),Turret_Bullet2.rotation)as GameObject;
															bullet2.rigidbody.velocity = Turret_Bullet2.transform.TransformDirection(new Vector3(0,0,speed));
													
													StartCoroutine(ShowMuzzleFlash(Bullet1_MuzzleFlash_renderer));
													StartCoroutine(ShowMuzzleFlash(Bullet2_MuzzleFlash_renderer));
													FireRateTime=0.0f;	
												
												}
										
									}
								
					
									
					
									if(SpeedControl.analog== false)
										SendMessage("PlayerPickup", 0);
									
							  }
				
							  else if(touch.phase == TouchPhase.Stationary && Shoot.HitTest(touch.position))
							  {
									if(FireRateTime>0.1f) //Bullet
									{	
										GameObject bullet1 = Instantiate(Bullet,Turret_Bullet1.TransformPoint(0,0,-0.25f),Turret_Bullet1.rotation)as GameObject;
												   bullet1.rigidbody.velocity = Turret_Bullet1.transform.TransformDirection(new Vector3(0.0f,0.0f,speed));			
													
										GameObject bullet2 = Instantiate(Bullet,Turret_Bullet2.TransformPoint(0,0,-0.25f),Turret_Bullet2.rotation)as GameObject;
												   bullet2.rigidbody.velocity = Turret_Bullet2.transform.TransformDirection(new Vector3(0,0,speed));
													
													StartCoroutine(ShowMuzzleFlash(Bullet1_MuzzleFlash_renderer));
													StartCoroutine(ShowMuzzleFlash(Bullet2_MuzzleFlash_renderer));
													FireRateTime=0.0f;	
												
									}
					
							 }	 
							 else
							 {
								if(SpeedControl.analog == false)
									SendMessage("PlayerPickup", 0);

							 }
							
					
						 }
			
					
				}
			
			
			
		*/	
		
		if(Input.GetKeyDown("s"))//Rocket
		{
			if(Ammo > 0) {
				//Vector3 touchpos = Input.mousePosition;
				/*
		
				if(rocketShoot.HitTest(touchpos))
				{
					
						GameObject rocket1= Instantiate(Rocket, Turret_Rocket1.position,Turret_Rocket1.rotation ) as GameObject;
						   rocket1.rigidbody.velocity = Turret_Rocket1.transform.TransformDirection(new Vector3(0,0,speed) );	
						Physics.IgnoreCollision( rocket1.collider,transform.root.collider);
					
						GameObject rocket2 = Instantiate(Rocket, Turret_Rocket2.position,Turret_Rocket2.rotation ) as GameObject;
									Physics.IgnoreCollision(collider,rocket2.collider );   
						rocket2.rigidbody.velocity = Turret_Rocket2.transform.TransformDirection(new Vector3(0,0,speed) );
					
					
				}
			*/
				GameObject rocket1= Instantiate(Rocket, Turret_Rocket1.position,Turret_Rocket1.rotation ) as GameObject;
						   rocket1.rigidbody.velocity = Turret_Rocket1.transform.TransformDirection(new Vector3(0,0,speed) );	
						Physics.IgnoreCollision( rocket1.collider,transform.root.collider);
					
						GameObject rocket2 = Instantiate(Rocket, Turret_Rocket2.position,Turret_Rocket2.rotation ) as GameObject;
									Physics.IgnoreCollision(collider,rocket2.collider );   
						rocket2.rigidbody.velocity = Turret_Rocket2.transform.TransformDirection(new Vector3(0,0,speed) );
				Ammo = Ammo -2;
		
			}
			/*
			if(Shoot.HitTest(touchpos))
			 {
										
				if(FireRateTime>0.1f) //Bullet
				{	
					GameObject bullet1 = Instantiate(Bullet,Turret_Bullet1.TransformPoint(0,0,-0.25f),Turret_Bullet1.rotation)as GameObject;
							   bullet1.rigidbody.velocity = Turret_Bullet1.transform.TransformDirection(new Vector3(0.0f,0.0f,speed));			
											
					GameObject bullet2 = Instantiate(Bullet,Turret_Bullet2.TransformPoint(0,0,-0.25f),Turret_Bullet2.rotation)as GameObject;
							   bullet2.rigidbody.velocity = Turret_Bullet2.transform.TransformDirection(new Vector3(0,0,speed));
											
							   StartCoroutine(ShowMuzzleFlash(Bullet1_MuzzleFlash_renderer));
							   StartCoroutine(ShowMuzzleFlash(Bullet2_MuzzleFlash_renderer));
							   FireRateTime=0.0f;	
										
				}
				
										
										
			}*/
		}
		
		
		
	
		time=time+Time.deltaTime;
		FireRateTime+=Time.deltaTime;
		
	}
	
	
	
	
	
	IEnumerator ShowMuzzleFlash( Renderer renderer) 
	{
		// Show muzzle flash when firing
		renderer.transform.localRotation *= Quaternion.Euler(0, 0, Random.Range(-360, 360));
		renderer.enabled = true;
		yield return new WaitForSeconds(0.05f);
		renderer.enabled = false;
	}
	
	
	void OnCollisionEnter(Collision collision){
		
		
		if(collision.gameObject.tag=="ammo"){
			
			Ammo = Ammo + 100;
		//	Debug.Log("PlayerGet ammo" + Ammo);
			
			
		}
		
		
	}
	
}
