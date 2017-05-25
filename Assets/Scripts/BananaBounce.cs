using UnityEngine;
using System.Collections;

//this script makes the bananas bob up and down, and handles their health
public class BananaBounce : MonoBehaviour {

	public float bobSpeed = 1.5f;		//how fast does the banana move
	public float bobHeight = 0.75f;		//how far from its starting position can it move
	public float spinSpeed = 180f;		//how fast does it rotate
	
	public Transform bobber;			//the piece of the banana that actually moves
	
	public int health = 3;				//how many times must the banana be touched before deletion
	public float divider = 2f;			//how to reduce speed when losing health
	
	
	public void Update() {
		//if there is an object to make move
		if(bobber != null) {
			//calculate a new position that bounces back and forth from its starting position to the max height
			float newPos = Mathf.PingPong(Time.time * bobSpeed, bobHeight);
			//update the bananas position
			bobber.localPosition = Vector3.up * newPos;
		}
		
		//make the banana rotate in place
		transform.Rotate(Vector3.up * Time.deltaTime * spinSpeed);
	}
	
	//when the player touches the banana
	public void Touched() {
		//reduce the health
		health--;
		//reduce the bob speed
		bobSpeed /= divider;
		//reduce the spin speed
		spinSpeed /= divider;
		
		//if we run out of health
		if(health <= 0) {
			//get rid of the banana
			Destroy(gameObject);
		}
	}
}
