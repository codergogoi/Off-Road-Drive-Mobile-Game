var waypoint : Transform[];
var speed : float = 20;
private var currentWaypoint: int;
var loop: boolean = true;

var player:Transform;

function Update () {
	
	if(currentWaypoint < waypoint.length){
		var target: Vector3 = waypoint[currentWaypoint].position;
		var moveDirection: Vector3 = target - transform.position;
		var distFormPlayer: Vector3 = player.position - transform.position;
		
		var velocity = rigidbody.velocity;
		
		if(moveDirection.magnitude < 1){
				currentWaypoint++;
			}
			else if(distFormPlayer.magnitude < 20){
				
				velocity = Vector3.zero;
				target = player.position;
				velocity = (player.position - transform.position);
				
				/* target = player.position;
				 velocity = moveDirection.normalized * speed; */
				}
			else{
			 velocity = moveDirection.normalized * speed;
			}
		}
	else{
		
		if(loop){
			currentWaypoint = 0;
	  	}
	  else{
	  	velocity = Vector3.zero;
  	 }
		
	}
	
	rigidbody.velocity = velocity;
	transform.LookAt(target);
	
}