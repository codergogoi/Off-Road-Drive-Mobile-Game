using UnityEngine;
using System.Collections;

public class ChangeVelocity : MonoBehaviour {


 
	public GameObject FrontColl,BackColl;
	void FixedUpdate() {

		 
 
		if(Input.GetKey("x")){
		
			FrontColl.SetActive(true);
			BackColl.SetActive(false);
			StartCoroutine(WaitForDisable(2.0f));
		} 

		if(Input.GetKey("z")){
			FrontColl.SetActive(false);
			BackColl.SetActive(true);
			StartCoroutine(WaitForDisable(2.0f));
		} 
 
	}


	IEnumerator WaitForDisable(float tm){

		yield return new WaitForSeconds(tm);
		FrontColl.SetActive(false);
		BackColl.SetActive(false);
	}
}
