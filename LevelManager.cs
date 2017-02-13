using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public float startDelay;
	private bool gameStarted;
	public bool levelCompleted;
	//private int difficultyLevel;


	public void Start(){
		levelCompleted = false;
		if (startDelay > 0) {
			Invoke ("LoadNextLevel", startDelay);
		} else {
			//Debug.Log ("Start Delay disabled, use a positive number in seconds");
		}
	}

	public void Update(){
		//for testing purposes
		/*if (Input.GetKeyDown ("space")) {
			LoadNextLevel ();
		}*/
			
	}
		
	
	public void ChangeLevel(string levelToLoad){
		SceneManager.LoadScene (levelToLoad);
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void LoadPrevLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
	}

	public void Quit(){
		Application.Quit ();
	}
		

	/*public void SetDifficultyLevel(int diffLevel){
		difficultyLevel = diffLevel;
	}

	public int GetDifficultyLevel(){
		return difficultyLevel;
	}*/
}
