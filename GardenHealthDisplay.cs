using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GardenHealthDisplay : MonoBehaviour {
	private double gardenHealth, normalDifficultyHealth = 10;
	private Text text;
	private LevelManager levelManager;
	private float difficultyLevel;

	// Use this for initialization
	void Start ()  {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		CalculateGardenLives ();
		text = GetComponent<Text> ();
		UpdateDisplay ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DamageGarden(int damage){
		gardenHealth -= damage;
		UpdateDisplay ();
		if (gardenHealth <= 0 && !levelManager.levelCompleted) {
			levelManager.ChangeLevel ("03b Lose");
		}
	}

	private void UpdateDisplay(){
		text.text = gardenHealth.ToString ();
	}

	private void CalculateGardenLives(){
		difficultyLevel = PlayerPrefsManager.GetDifficulty ();
		if (difficultyLevel == 3) {gardenHealth = normalDifficultyHealth * 0.5;}		//50% fewer health
		if (difficultyLevel == 2) {gardenHealth = normalDifficultyHealth;}				//normal health as declared at the top of this file
		if (difficultyLevel == 1) {gardenHealth = (int)normalDifficultyHealth * 1.5;}		//50% more health
	}
}
