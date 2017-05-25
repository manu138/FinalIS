using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//this script controls the volume that detects player victory
public class VictoryVolume : MonoBehaviour {

	public GameObject victoryText;			//the text to display when the player wins
	public GameObject outOfTimeText;		//the text to display when the player loses
	public Text timer;						//the object that displays how much time is left
	public float timeLimit = 60f;			//how many seconds does the player have to reach the finish
	private bool countDown = true;			//whether or not the timer should be counting down
	
	
	public void Awake() {
		//at the beginning of the game, turn off the text displays
		victoryText.SetActive(false);
		outOfTimeText.SetActive(false);
	}
	
	//when the player enters the goal trigger volume
	public void OnTriggerEnter(Collider other) {
		//if they have not run out of time
		if(countDown) {
			//turn on the victory text
			victoryText.SetActive(true);
			//stop them from moving around
			other.attachedRigidbody.isKinematic = true;
			//stop counting their time
			countDown = false;
		}
	}
	
	public void Update() {
		//if they still have some time left and haven't reached the end
		if(countDown) {
			//reduce their remaing time
			timeLimit -= Time.deltaTime;
			//display the remaing time on the screen
			timer.text = timeLimit.ToString("0.00");
			//if they ran out of time
			if(timeLimit <= 0) {
				//turn on the losing message
				outOfTimeText.SetActive(true);
				//turn off the timer display
				timer.gameObject.SetActive(false);
				//stop counting the time
				countDown = false;
			}
		}
	}
}
