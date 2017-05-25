using UnityEngine;
using System.Collections;

//this script controls the movement of the monkey
public class MonkeyBall : MonoBehaviour {

	public Rigidbody body;							//the component that hooks the monkey into the physics system
	
	public float minTilt = 5f;						//the minimum amount of tilt needed to move
	public float sensitivity = 1f;					//a multiplier for adding force to the monkey ball
	
	private Vector3 totalRotate = Vector3.zero;		//how much rotation has been applied by the player
	
	public Transform monkeyPivot;					//the monkey inside of the ball
	public float monkeyLookSpeed = 10f;				//how fast the monkey turns to face its direction of movement
	
	
	
	public void Awake() {
		//turn on the tracking of the device's gyroscope
		Input.gyro.enabled = true;
	}
	
	public void Update() {
		//grab the current rotation input and convert it to degrees
		Vector3 rotation = Input.gyro.rotationRate * Mathf.Rad2Deg;
		
		//if any axis has rotated less than our minimum, throw out the value
		if(Mathf.Abs(rotation.x) < minTilt) rotation.x = 0;
		if(Mathf.Abs(rotation.y) < minTilt) rotation.y = 0;
		if(Mathf.Abs(rotation.z) < minTilt) rotation.z = 0;
		
		//recored how much rotation has been applied so far
		totalRotate += new Vector3(-rotation.x, rotation.z, -rotation.y) * Time.deltaTime;
	}
	
	public void FixedUpdate() {
		//give the ball some rotational force, based on the total rotation of the device.
		body.AddTorque(totalRotate * sensitivity);
	}
	
	public void LateUpdate() {
		//if the monkey is available
		if(monkeyPivot != null) {
			//find the movement direction of the ball
			Vector3 velocity = body.velocity;
			//zero out the vertical movement
			velocity.y = 0;
			
			//find the monkey's current facing
			Vector3 forward = monkeyPivot.forward;
			//zero out the vertical direciton
			forward.y = 0;
			
			//figure out how much the monkey can turn this frame
			float step = monkeyLookSpeed * Time.deltaTime;
			
			//find a new direction to face that is closer towards the ball's movement direction
			Vector3 newFacing = Vector3.RotateTowards(forward, velocity, step, 0);
			//rotate the monkey to face in the new direction
			monkeyPivot.rotation = Quaternion.LookRotation(newFacing);
		}
	}
}
