using UnityEngine;
using System.Collections;

//this script makes the camera follow the monkey around
public class CameraFollow : MonoBehaviour {

	public Transform ball;		//what should the camera be following
	
	
	public void LateUpdate() {
		//move the camera to the position of the ball
		transform.position = ball.position;
	}
	
}
