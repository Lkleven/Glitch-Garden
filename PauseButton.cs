using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
	private LevelManager levelManager;
	private GameObject pausePanel;
	public bool pause = false;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		pausePanel = GameObject.Find ("PausePanel");
		pausePanel.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if (!pause) {
			PauseGame ();
		}

	}

	public void PauseGame(){
		pause = true;
		Time.timeScale = 0;
		pausePanel.SetActive (true);
	}

	public void ResumeGame(){
		pause = false;
		Time.timeScale = 1;
		pausePanel.SetActive (false);
	}

	public void ToMenu(){
		Time.timeScale = 1;
		levelManager.ChangeLevel ("01a Menu");
	}
}
