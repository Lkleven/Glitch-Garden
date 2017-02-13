using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour {
	private float levelTime = 90;
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;
	private Text timer, levelText;
	private int currentLevel;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		FindYouWin ();
		FindTimeLabel ();
		FindLevelLabel ();
		winLabel.SetActive (false);
		currentLevel = SceneManager.GetActiveScene ().buildIndex - 2; //the first game level begins at buildIndex 3
		levelText.text = "Level " + currentLevel;
		levelTime = levelTime + ((currentLevel - 1) * 10);			//increases levelTime based on the currentLevel
	}

	private void FindYouWin(){
		winLabel = GameObject.Find ("LevelCompleteText");
		if (!winLabel) {
			Debug.LogWarning ("Please create 'LevelCompleteText' object");
		}
	
	}

	private void FindTimeLabel(){
		foreach (Transform child in transform) {
			if (child.name.Equals ("Time")) {
				timer = child.gameObject.GetComponent<Text> ();
			}
		}
		if(!timer){
			Debug.LogWarning ("Make sure there is a 'Time' text UI object in the GameTimer GameObject");
		}
	}

	private void FindLevelLabel(){
		foreach (Transform child in transform) {
			if (child.name.Equals ("LevelText")) {
				levelText = child.gameObject.GetComponent<Text> ();
			}
		}
		if(!timer){
			Debug.LogWarning ("Make sure there is a 'Time' text UI object in the GameTimer GameObject");
		}
	}
	
	// Update is called once per frame
	void Update () {

		float clock = levelTime - Time.timeSinceLevelLoad;
		float minutes = clock / 60;
		float seconds = clock % 60;
		//float fraction = (clock * 100) % 100;	//milliseconds

		//timer.text = string.Format ("{0:00}:{1:00}:{2:00}", (int)minutes, (int)seconds, (int)fraction);    //minutes:seconds:fraction
		if (seconds <= 0) {
			seconds = 0;
		}
		timer.text = string.Format ("{0:0}:{1:00}", (int)minutes, (int)seconds);//minutes:seconds


		slider.value = (Time.timeSinceLevelLoad / levelTime);

		if (Time.timeSinceLevelLoad >= levelTime && !isEndOfLevel) {
			HandleWinCondition ();
		}
	}

	void HandleWinCondition (){
		DestroyAllTaggedObjects ();
		audioSource.Play ();
		Invoke ("LoadNextLevel", audioSource.clip.length); 	//waits until audiosource have finished playing
		winLabel.SetActive (true);
		isEndOfLevel = true; 								//prevents this method from being called repediatly
		levelManager.levelCompleted = true; 				//tells levelManager level is completed, prevents losing after winning
	}

	//Destroys all objects tagged 'destroyOnWin'
	void DestroyAllTaggedObjects(){
		GameObject[] destroyThese = GameObject.FindGameObjectsWithTag ("destroyOnWin");

		foreach (GameObject gameObj in destroyThese) {
			Destroy (gameObj);
		}

	}

	void LoadNextLevel(){
		levelManager.LoadNextLevel ();
	}
}
