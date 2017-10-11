using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject powerUp;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;

	public int score;

	void Start(){
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves ());

	}

	void Update(){
		if (restart) {
			if(Input.GetKeyDown(KeyCode.R)){
				SceneManager.LoadScene ("Main",LoadSceneMode.Single);
			}
		}
	}
		
	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while(true){
    		for(int i = 0; i < hazardCount;i++){
	    	    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),0.0f, spawnValues.z);
		        Quaternion spawnRotation = Quaternion.identity;

         		GameObject hazardClone = Instantiate (hazard, spawnPosition, spawnRotation) as GameObject;
				SpawnPowerUp ();
	    		yield return new WaitForSeconds (spawnWait);
		    }
			if(gameOver){
				restartText.text = "Press R for restart";
				restart = true;
				break;
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

	public void GameOver(){
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	void SpawnPowerUp ()
	{
		float rand = Random.Range (0.0f, 20.0f);

		Debug.Log ("rand: "+rand.ToString());
		if(rand>19.555f){
			Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),0.0f, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;

			GameObject powerClone = Instantiate (powerUp, spawnPosition, spawnRotation) as GameObject;
		}
	}
}
