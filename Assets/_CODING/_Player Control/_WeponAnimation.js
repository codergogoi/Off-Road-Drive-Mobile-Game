#pragma strict




public var TurretL:Transform;
public var TurretMeshL:Transform;
public var TurretR:Transform;
public var TurretMeshR:Transform;

public var B_TurretL:Transform;
public var B_TurretMeshL:Transform;
public var B_TurretR:Transform;
public var B_TurretMeshR:Transform;


public var rate: float;


public var RocketShoot : GUITexture;
public var BulletShoot : GUITexture;

//private var lineRenderer:LineRenderer;
//lineRenderer=GetComponent(LineRenderer);
//lineRenderer.SetColors(Color.white,Color(1,1,1,0));


function Start(){

	RocketShoot = GameObject.Find("_Rock_B").guiTexture;
	BulletShoot = GameObject.Find("_Rock_B").guiTexture;


}


function Update () 
{


if(Input.GetMouseButtonDown(0)){

	var pos : Vector3 = Input.mousePosition;
	
	
	if(RocketShoot.HitTest(pos)){
	
			TurretMeshL.position=Vector3.Lerp(TurretL.TransformPoint(0.0,0,-0.25f),TurretL.TransformPoint(0.0,0.0,0.0),rate * 0.5f);
	 	 	TurretMeshR.position=Vector3.Lerp(TurretR.TransformPoint(0.0,0,-0.25f),TurretR.TransformPoint(0.0,0.0,0.0),rate * 0.5f);
	
	}
	
	if(BulletShoot.HitTest(pos)){
	
			B_TurretMeshL.position=Vector3.Lerp(B_TurretL.TransformPoint(0.0,0,-0.35f),B_TurretL.TransformPoint(0.0,0.0,0.0),rate * 0.8f);
	 	 	B_TurretMeshR.position=Vector3.Lerp(B_TurretR.TransformPoint(0.0,0,-0.35f),B_TurretR.TransformPoint(0.0,0.0,0.0),rate * 0.8f);
		
	
	}




}else{

	
	
		TurretMeshL.position=Vector3.Lerp(TurretL.TransformPoint(0.0,0,0f),TurretL.TransformPoint(0.0,0.0,0.0),rate * 0.5f);
		TurretMeshR.position=Vector3.Lerp(TurretR.TransformPoint(0.0,0,0f),TurretR.TransformPoint(0.0,0.0,0.0),rate * 0.5f);
		
		B_TurretMeshL.position=Vector3.Lerp(B_TurretL.TransformPoint(0.0,0,0f),B_TurretL.TransformPoint(0.0,0.0,0.0),rate * 0.5f);
	 	B_TurretMeshR.position=Vector3.Lerp(B_TurretR.TransformPoint(0.0,0,0f),B_TurretR.TransformPoint(0.0,0.0,0.0),rate * 0.5f);
		
	

}
  
 
	 
	// print(">"+TurretMesh.position);
	// print(">>"+TurretMesh.localPosition);
	 
	 
	 

}







