using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupByContact : MonoBehaviour {

	public GameController gameController;
	public float speedUp = 0.0f;
	public float duration = 0.0f;

	void Start () {
		GameObject gcObject = GameObject.FindWithTag ("GameController");	
		if (gcObject != null) {
			gameController = gcObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("cannot find GameController instance");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag != "Boundary") {
			if(other.tag == "Player"){
				other.GetComponent<PlayerController>().SpeedUp(speedUp,duration);
			}
			Destroy (gameObject);
		}
	}

}
