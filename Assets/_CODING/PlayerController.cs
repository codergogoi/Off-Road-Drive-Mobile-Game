using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject Player;

	public GUITexture FWD,BACK,Pause;

	public GameObject TyreParticle;
	private bool isDisable;

	// coins control here

	public GameObject coinsPrefab;
	
	public GameObject InstPoint;
	public GameObject InstTrigger;

	private Vector3 CurrentPosition;
	private RaycastHit hit;

	private bool isOnAir;

	public GameObject FrontColl,BackColl;
	public LayerMask lm;
	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {

//
//		Vector3 dwn = transform.TransformDirection(Vector3.down);
//
//		if(Physics.Raycast(transform.position,dwn,out hit,2.5f,lm)){
//
//			Debug.DrawLine(transform.position, hit.point,Color.red);
//
//			if(hit.collider.tag=="ground"){
//
//				isOnAir = false;
//
//			}
//
//		}else{
//
//			isOnAir = true;
//		}

 
		//print(transform.position);

		if(Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android ){

		if(Input.GetKey("mouse 0")){

			Vector3 pos = Input.mousePosition;

			if(FWD.HitTest(pos)){
				
					if(isOnAir){

						//Player.SendMessage("setMass",3);
						StartCoroutine(WaitForDisable(2.0f));
					}
				isDisable = true;
				TyreParticle.SetActive(true);
				Player.SendMessage("pickupFWD",3);

			}


			if(BACK.HitTest(pos)){

					if(isOnAir){
						
					//	Player.SendMessage("setMass",2);
						StartCoroutine(WaitForDisable(2.0f));
					}

				 Player.SendMessage("pickupFWD",2);
			}

			if(Pause.HitTest(pos)){
				
				Application.LoadLevel(0);
			}

		}else{
			isOnAir = false;
			Player.SendMessage("setMass",1);

			if(isDisable){
				isDisable = false;
				StartCoroutine(particleDisable());
			}
			Player.SendMessage("pickupFWD",1);

		}

	}

		if(Application.platform == RuntimePlatform.OSXEditor){


			if(Input.GetKey(KeyCode.RightArrow)){

			

				isDisable = true;
				TyreParticle.SetActive(true);
				Player.SendMessage("pickupFWD",3);

				if(isOnAir){
					
					Player.SendMessage("setMass",3);
					StartCoroutine(WaitForDisable(2.0f));
				}

			}else if(Input.GetKey(KeyCode.LeftArrow)){
				
				
				if(isOnAir){
					
					Player.SendMessage("setMass",2);
					StartCoroutine(WaitForDisable(2.0f));
				}
			}else{

				if(isDisable){
					isDisable = false;
					StartCoroutine(particleDisable());
				}
				Player.SendMessage("pickupFWD",1);
				Player.SendMessage("setMass",1);

			}





		}


	
	}

	
	IEnumerator WaitForDisable(float tm){
		
		yield return new WaitForSeconds(tm);
		Player.SendMessage("setMass",1);
	}


	IEnumerator particleDisable(){

		yield return new WaitForSeconds(0.3f);

		TyreParticle.SetActive(false);
	}

	void OnTriggerEnter(Collider coll){


		if(coll.collider.tag == "coins"){

			Destroy(coll.collider.gameObject);
		}

		if(coll.collider.tag =="coinsInst"){

			int maxCoins = 20;
			float zPos = transform.position.z + 30.0f;
			float yPos = 1.0f;
			Vector3 tempPos = new Vector3(0,yPos,zPos);

			for(int i = 0; maxCoins > i; i++ ){
				tempPos = new Vector3(0,yPos,zPos);
				GameObject coin = Instantiate(coinsPrefab,tempPos,coll.collider.transform.rotation) as GameObject;
				zPos+= 3.0f;
				yPos+= 0.2f;
			}

			Destroy(coll.collider.gameObject);

		}


	}
}
