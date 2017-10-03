using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public Text scoreText;
	public int score;

	void Start(){
		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves ());

	}
		
	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while(true){
    		for(int i = 0; i < hazardCount;i++){
	    	    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),0.0f, spawnValues.z);
		        Quaternion spawnRotation = Quaternion.identity;

         		GameObject hazardClone = Instantiate (hazard, spawnPosition, spawnRotation) as GameObject;
	    		yield return new WaitForSeconds (spawnWait);
		    }
		}
	}

	public void AddScore(int scoreValue){
		score += scoreValue;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score.ToString ();
	}

}
