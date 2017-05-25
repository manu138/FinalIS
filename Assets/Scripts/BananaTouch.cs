using UnityEngine;
using System.Collections;

//this script allows us to touch bananas and collect them
public class BananaTouch : MonoBehaviour {

	public void Update() {
		//if the screen hasn't been touched this frame, don't do anything
		if(Input.touchCount <= 0) return;
		
		//for every touch that is currently active
		foreach(Touch next in Input.touches) {
			//if the touch has just started this frame
			if(next.phase == TouchPhase.Began) {
				//create a variable to store information about the raycast
				RaycastHit hit;
				//find a position and direction in the world to shoot rays from
				Ray touchRay = Camera.main.ScreenPointToRay(next.position);
				//shoot out a ray and record anything that was hit
				if(Physics.Raycast(touchRay, out hit)) {
					//tell the thing that the player touched that we touched it
					hit.transform.gameObject.SendMessage("Touched", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
