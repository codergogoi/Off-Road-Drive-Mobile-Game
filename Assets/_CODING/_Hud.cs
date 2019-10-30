using UnityEngine;
using System.Collections;

public class _Hud : MonoBehaviour {
	
	public GUITexture Reload;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(0)){
			
			
			Vector3 pos = Input.mousePosition;
			
			if(Reload.HitTest(pos)){
				
				Application.LoadLevel("XLevel");
			}
			
		}
	
	}
}
