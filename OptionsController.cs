using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider, difficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (musicManager) {
			musicManager.SetVolume (volumeSlider.value);
		}
	}

	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);
		levelManager.LoadPrevLevel();
	}

	public void SetDefaults(){
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2.0f;
	}
}
