using UnityEngine;
using System.Collections;

public class SmoothFollowCs : MonoBehaviour {

	public Transform target;
    public float smooth = 0.3F;
    public float distance = 5.0F;
    public float height = 5.0F;
	
	private float yVelocity = 0.0F;
	
    void Update() {
        
		float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref yVelocity, smooth);
		
        Vector3 position = target.position;
        
		//position += Quaternion.Euler(30, yAngle, 0) * new Vector3(0, height, -distance);
		position += Quaternion.Euler(30, 300, 0) * new Vector3(0, height, -distance);
		transform.position = position;
		
        transform.LookAt(target);
    }
}
