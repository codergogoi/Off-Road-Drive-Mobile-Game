using UnityEngine;
using System.Collections;

public class _AudioCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		print(audio.clip.length);
	}
	
	// Update is called once per frame
	void Update () {

		if(audio.time == audio.clip.length){

			print("Finished Playing");


		}
	
	}
}
