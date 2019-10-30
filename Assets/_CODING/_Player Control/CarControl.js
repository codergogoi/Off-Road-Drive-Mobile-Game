var flWheelCollider : WheelCollider;
var frWheelCollider : WheelCollider;
var rlWheelCollider : WheelCollider;
var rrWheelCollider : WheelCollider;

var maxTorqe = 1500.0;
var maxBrakeTorque = 500.0;
var maxSteerAngle  = 45.0;
var maxSpeed : float = 60.0;
var maxBackwardSpeed : float = 20.0;
var CurrentSpeed : float = 0.0;
private var isBreaking :boolean = false;
//var steerStep : float = 1.0;



var flWheel : Transform;
var frWheel : Transform;
var rlWheel : Transform;
var rrWheel : Transform;


var gearSpeed: int[];
private var currentGear : int = 0;


//breaking system
var FullBreakTorque : float  = 5000.00;

private var oldForwardFriction :float = 0.00;
private var oldSidewaysFriction :float = 0.00;
private var newForwardFriction :float = 0.04;
private var newSidewaysFriction :float = 0.01;
private var stopForwardFriction :float = 1;
private var stopSidewaysFriction :float = 1;

private var isPlayingSound : boolean = false;

private var pickup : float;
private var isOver : boolean;

private var tempTime : float;
private var ResetTime : float;

private var isFWD : boolean;
private var pickupIndex : int;

private var isOnAir : boolean;

public var btnFwd : GUITexture;
public var btnBack : GUITexture;

function Start(){
	pickup = 1;
	//GuiSpeed.material.color = Color.green;
	rigidbody.centerOfMass.y = -1.3;
	//rigidbody.centerOfMass = transform.localPosition;
	//rigidbody.centerOfMass  += Vector3(0,0,1.0);
	
	oldForwardFriction = rrWheelCollider.forwardFriction.stiffness;
	oldSidewaysFriction = rrWheelCollider.sidewaysFriction.stiffness;
	isOver = false;
	
	

}

function PickUpSet(sp : float){

	
		if(sp > 5){
		
			isOver = true;
			
		}else if(sp > 3){
			
			isOver = false;
			pickup = 1;
		}else if(sp > 2){
				
				pickup = 1;
		}else{
		
				pickup = -1;
		}
		
		
		

	

}

function pickupFWD(val : float){
		isBreaking = true;
		if(val > 2){
			
			pickupIndex = 3;
			isFWD = true;
			
		}else if(val > 1){
			pickupIndex = 2;
			isFWD = true;
			
		}else{
			pickupIndex = 0;
			isFWD = false;
			
		}
		isBreaking = false;
	
			
	

}
 

function setMass( val : int){

//	if(val > 2){
//		
//		rigidbody.centerOfMass.z = 2.5f;
//	
//	}else if(val > 1){
//		
//		rigidbody.centerOfMass.z = -2.5f;
//	
//	}else{
//	
//		rigidbody.centerOfMass.z = -1.2f;
//	}

 }



function FixedUpdate () {

	

	FullBreaking();
	
	CurrentSpeed = (Mathf.PI * 2 * flWheelCollider.radius) * flWheelCollider.rpm * 60/1000;
	CurrentSpeed = Mathf.Round(CurrentSpeed);

	var relativeVelocity : Vector3 = transform.InverseTransformDirection(rigidbody.velocity);

	
	if(((CurrentSpeed > 0) && (Input.GetAxis("Vertical") < 0)) || ((CurrentSpeed < 0) && (Input.GetAxis("Vertical") > 0))){
		
		isBreaking = true;
	
	}else{
		isBreaking = false;
		flWheelCollider.brakeTorque =0;
		frWheelCollider.brakeTorque =0;
		rlWheelCollider.brakeTorque =0;
		rrWheelCollider.brakeTorque =0;
	}
	
	if(isBreaking == false){
	
		if((CurrentSpeed < maxSpeed) && (CurrentSpeed > (maxBackwardSpeed * -1)) && isFWD){
		
			if(pickupIndex > 2){
			
				rlWheelCollider.motorTorque = maxTorqe * 1;
				rrWheelCollider.motorTorque = maxTorqe * 1;
				
			}else if(pickupIndex > 1){
				rlWheelCollider.motorTorque = maxTorqe * -1;
				rrWheelCollider.motorTorque = maxTorqe * -1;
			
			}
	
			//flWheelCollider.motorTorque = maxTorqe * Input.GetAxis("Vertical");
			//frWheelCollider.motorTorque = maxTorqe * Input.GetAxis("Vertical");
			 
			/*flWheelCollider.motorTorque = maxTorqe * 1;// Input.GetAxis("Vertical");
			frWheelCollider.motorTorque = maxTorqe * 1;//Input.GetAxis("Vertical");*/
	
		}else{
			rlWheelCollider.motorTorque = 0;
			rrWheelCollider.motorTorque = 0;
			flWheelCollider.motorTorque = 0;
			frWheelCollider.motorTorque = 0;
		}
	
	
	}else{
	
		flWheelCollider.brakeTorque = maxBrakeTorque;
		frWheelCollider.brakeTorque = maxBrakeTorque;
		rrWheelCollider.brakeTorque = maxBrakeTorque;
		rlWheelCollider.brakeTorque = maxBrakeTorque;
		flWheelCollider.motorTorque = 0;
		frWheelCollider.motorTorque = 0;
		rlWheelCollider.motorTorque = 0;
		rrWheelCollider.motorTorque = 0;
		
	}
	
	//dir.x = Input.acceleration.x;
	//iphone control
	
	//  if (Application.platform == RuntimePlatform.OSXEditor)
      //      Debug.Log("Do something special here!");
        
    //}
    
    
    if(Application.platform == RuntimePlatform.OSXEditor){
    
   	 	flWheelCollider.steerAngle = 0;
		frWheelCollider.steerAngle = 0;
    
    }
    
    
	
	
	/*
	*/
	
	
	//editor Control
	/*
	flWheelCollider.steerAngle = maxSteerAngle * Input.GetAxis("Horizontal"); 
	frWheelCollider.steerAngle = maxSteerAngle * Input.GetAxis("Horizontal");
	*/
	
	  
	//GuiSpeed.text = flWheelCollider.rpm.ToString();
	
	SetCurrentGear();
	GearSound();


}

function FullBreaking(){

	 if(Input.GetKey("space")){
		 rlWheelCollider.brakeTorque = FullBreakTorque;
		 rrWheelCollider.brakeTorque = FullBreakTorque;
	 	 
	 	if((Mathf.Abs(rigidbody.velocity.z) > 1) || (Mathf.Abs(rigidbody.velocity.x)>1)){
	 	
	 		SetFriction(newForwardFriction, newSidewaysFriction);
	 	
	 	}else{
	 		
	 		SetFriction(stopForwardFriction, stopSidewaysFriction);
	 	
	 	}
	 
	 
	 
	 }else{
	 
	 	 rlWheelCollider.brakeTorque = 0;
		 rrWheelCollider.brakeTorque =0;
		 flWheelCollider.brakeTorque = 0;
		 frWheelCollider.brakeTorque =0;
	 	 SetFriction(oldForwardFriction, oldSidewaysFriction);
	 }
	
}

function SetFriction(MyForwardFriction : float, MySidewaysFriction: float){

	transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,0,transform.rotation.eulerAngles.z);
	
	if(transform.position.x > 1.0f || transform.position.x < -1.0f){
	
		transform.position = Vector3(0,transform.position.y,transform.position.z);
	}
	
	frWheelCollider.forwardFriction.stiffness = MyForwardFriction;
	flWheelCollider.forwardFriction.stiffness = MyForwardFriction;
	rrWheelCollider.forwardFriction.stiffness = MyForwardFriction;
	rlWheelCollider.forwardFriction.stiffness = MyForwardFriction;

 	  frWheelCollider.sidewaysFriction.stiffness = MySidewaysFriction;
	  flWheelCollider.sidewaysFriction.stiffness = MySidewaysFriction;
 	 rrWheelCollider.sidewaysFriction.stiffness = MySidewaysFriction;
 	 rlWheelCollider.sidewaysFriction.stiffness = MySidewaysFriction;


}

function SetBreakEffects(playEffects: boolean){
	
	var isGrounding : boolean = false;
	
	if(playEffects == true){
	
		var hit : WheelHit;
		
		if(rlWheelCollider.GetGroundHit(hit)){
		
			GameObject.Find("dustL").particleEmitter.emit = true;
		}
		
		if(rrWheelCollider.GetGroundHit(hit)){
		
			GameObject.Find("dustR").particleEmitter.emit = true;
		
		}
		
		
		if(isPlayingSound==false){
		
			
		
		}
	
	
	}




}




function Update(){

		rigidbody.drag = rigidbody.velocity.magnitude / 250; //


		var hit : RaycastHit;
	var fwd = transform.TransformDirection (Vector3.down);
	if (Physics.Raycast (transform.position, fwd,hit, 2)) {
	
		Debug.DrawLine(transform.position,hit.point,Color.red);
		
		if(hit.collider.tag=="ground"){
			rigidbody.centerOfMass.z = -1.2f;
			isOnAir = false;
		}
		
	}else{
		
		isOnAir = true;
		
	}
		
	if(Input.GetMouseButton(0) && isOnAir){
			
			var pos : Vector3;
			
			 pos = Input.mousePosition;
			 
			 if(btnFwd.HitTest(pos)){
			 	rigidbody.centerOfMass.z = 0.5f;
			 	print("Fwd");
			 }else if(btnBack.HitTest(pos)){
			 	rigidbody.centerOfMass.z = -2.5f;
			 	print("back");
			 }
			
			
	}else{
	
		rigidbody.centerOfMass.z = -1.2f;
	}
	
	if(Input.GetKey(KeyCode.LeftArrow) && isOnAir){
 		rigidbody.centerOfMass.z = -2.5f;
	}else if(Input.GetKey(KeyCode.RightArrow) && isOnAir){
	
		rigidbody.centerOfMass.z = 0.5f;
	}else{
 		rigidbody.centerOfMass.z = -1.2f;
	} 
	
	//print(rigidbody.centerOfMass);
	

	if(isOver){
				isBreaking = true;
				CurrentSpeed = 0;
				pickup = 0;
				maxTorqe = 0;
			
				
				
				
				rlWheelCollider.brakeTorque = FullBreakTorque;
		 		rrWheelCollider.brakeTorque = FullBreakTorque;
	 	 
			 	if((Mathf.Abs(rigidbody.velocity.z) > 1) || (Mathf.Abs(rigidbody.velocity.x)>1)){
			 	
			 		SetFriction(newForwardFriction, newSidewaysFriction);
			 	
			 	}else{
			 		
			 		SetFriction(stopForwardFriction, stopSidewaysFriction);
			 	
			 	}
	 
				
				
				
				flWheelCollider.brakeTorque =0;
				frWheelCollider.brakeTorque =0;
			 	
				
		
		}else{
				isBreaking = false;
				
		
		}
	RotateWheels();
	//SteelWheels(); 

}
 

function RotateWheels(){

	flWheel.Rotate(flWheelCollider.rpm/60 *360 * Time.deltaTime, 0,0);
	frWheel.Rotate(frWheelCollider.rpm/60 *360 * Time.deltaTime, 0,0);
	rlWheel.Rotate(rlWheelCollider.rpm/60 *360 * Time.deltaTime, 0,0);
	rrWheel.Rotate(rrWheelCollider.rpm/60 *360 * Time.deltaTime, 0,0);
}

function SteelWheels(){
	
	flWheel.localEulerAngles.y = flWheelCollider.steerAngle - flWheel.localEulerAngles.z;
	frWheel.localEulerAngles.y = frWheelCollider.steerAngle - frWheel.localEulerAngles.z;

}

function SetCurrentGear(){

	var gearNumber :int;
	gearNumber = gearSpeed.length;
	
	
	for(var i=0; i< gearNumber; i++){
		
		if(gearSpeed[i] > CurrentSpeed){
			
			currentGear = i;
			break;
		
		}
	
	}
	
}


function GearSound(){

	var tempMinSpeed : float = 0.0;
	var tempMaxSpeed : float = 0.0;
	var currentPitch : float = 0.0;
	
	switch(currentGear){
	
		case 0:
			
			tempMinSpeed = 0.0;
			tempMaxSpeed = gearSpeed[currentGear];
			break;
		default :
			
			tempMinSpeed = gearSpeed[currentGear - 1];
			tempMaxSpeed = gearSpeed[currentGear];
			break;
	
	}
	
	
	currentPitch = (( Mathf.Abs(CurrentSpeed) - tempMinSpeed)/(tempMaxSpeed - tempMinSpeed)) +1;
 
	 
	audio.pitch = currentPitch;
	 


}
