using UnityEngine;
using System.Collections;

//this script resets the monkey if it goes too far away
public class KillVolume : MonoBehaviour {

	public Transform respawnPoint;			//where do we put the monkey when it goes out of bounds

	public void OnTriggerEnter(Collider other) {
		//move the monkey to the respawn point
		other.transform.position = respawnPoint.position;
		//stop them from moving wildly out of control
		other.attachedRigidbody.velocity = Vector3.zero;
	}
}
