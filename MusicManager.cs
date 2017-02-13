using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;
	private bool menuMusic = false;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
	}


	void Start(){
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume ();
	}

	//listens for changes of scene
	void OnEnable(){
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
		int level = scene.buildIndex;
		if (menuMusic == true && level == 1) {		//Do not change music when switching between Menu and Option scenes
			return;
		} else if (level == 1) {
			menuMusic = true;
		} else if (level > 2) {
			menuMusic = false;
		}
		AudioClip clip = levelMusicChangeArray [level];
		if (clip != null) {
			audioSource.clip = clip;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

	public void SetVolume(float volume){
		audioSource.volume = volume;
	}
}
