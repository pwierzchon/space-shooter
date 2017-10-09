using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public GameController gameController;

	void Start(){
		GameObject gcObject = GameObject.FindWithTag ("GameController");	
		if (gcObject != null) {
			gameController = gcObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("cannot find GameController instance");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag != "Boundary") {
			GameObject animation1 = Instantiate (explosion, transform.position, transform.rotation) as GameObject;

			if(other.tag == "Player"){
				GameObject animation2 = Instantiate (playerExplosion, other.transform.position, other.transform.rotation) as GameObject;
				gameController.GameOver ();
			}
			if (other.tag == "PlayerBolt") {
				gameController.AddScore (scoreValue);
			}

			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
