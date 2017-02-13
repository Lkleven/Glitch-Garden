using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	public Camera gameCamera;
	private GameObject parent;
	private StarDisplay starDisplay;
	private PauseButton pauseButton;

	// Use this for initialization
	void Start () {
		pauseButton = GameObject.FindObjectOfType<PauseButton> ();
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();

		parent = GameObject.Find ("Defenders");
		if (!parent) {
			parent = new GameObject ("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//also works for touch surfaces
	void OnMouseDown(){
		if (!pauseButton.pause) {																			//Can't build when paused
			GameObject defender = Button.selectedDefender;
			int defenderCost = defender.GetComponent<Defender> ().starCost;

			if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
				GameObject newDefender = Instantiate (defender, CalculateWorldPointOfMouseClick (), Quaternion.identity) as GameObject;
				newDefender.transform.parent = parent.transform;
			} else {
				starDisplay.TooFewStarsWarning ();
			}
		}
	}
		
	//Mouse pixel position to world point
	//Rounds world point to nearest integer "Snap-to-grid"
	Vector2 CalculateWorldPointOfMouseClick(){
		Vector2 worldPos = gameCamera.ScreenToWorldPoint(Input.mousePosition);
		return new Vector2 (Mathf.Round(worldPos.x), Mathf.Round(worldPos.y));
	}
}
