using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
}

[System.Serializable]
public class Shoots{
	public GameObject shoot;
	public Transform shootSpawn;

	public float nextFire = 0.0f;
	public float fireRate = 0.0f;


}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	public Shoots shoots;
	private float previousRate = 0.0f;
	private bool speedUp = false;
	float endSpeedUp = 0.0f;


	void Update(){
		Fire ();
		CheckPowerUps ();
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().velocity = movement*speed;

		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp(GetComponent<Rigidbody> ().position.x,boundary.xMin,boundary.xMax),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody> ().position.z,boundary.zMin,boundary.zMax)
		);

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f,0.0f,GetComponent<Rigidbody> ().velocity.x * -tilt);
	}

    void Fire(){
		if (Input.GetButton ("Fire1") && Time.time > shoots.nextFire) {
			shoots.nextFire = Time.time + shoots.fireRate;
			GameObject clone = Instantiate (shoots.shoot, shoots.shootSpawn.position, shoots.shootSpawn.rotation) as GameObject;
			GetComponent<AudioSource>().Play();
		}
	}

	public void SpeedUp(float factor, float duration){
		previousRate = shoots.fireRate;
		speedUp = true;
		shoots.fireRate = factor;
		endSpeedUp = Time.time + duration;
	}

	void CheckPowerUps ()
	{
		if(speedUp){
			if(Time.time > endSpeedUp){
				shoots.fireRate = previousRate;
				speedUp = false;
			}
		}
	}

}
