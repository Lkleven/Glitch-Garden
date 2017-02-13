using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]			//if there is no text element, one will be created
public class StarDisplay : MonoBehaviour {
	public int stars = 110;
	private Text text;
	private bool tooFewStarsWarning = false;
	private Color startColor, endColor, initialColor;
	private float fadeDuration = 0.3f, lastColorChangeTime;
	private int warningCycles;


	public enum Status{SUCCESS, FAILURE};

	// Use this for initialization
	void Start ()  {
		text = GetComponent<Text> ();
		UpdateDisplay ();

		initialColor = text.color;
		startColor = initialColor;
		endColor = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		if (warningCycles >= 4) {
			tooFewStarsWarning = false;
			text.color = initialColor;				//Makes sure the text color goes back to "normal" might look a bit wonky
		}

		if (tooFewStarsWarning) {
			float ratio = (Time.time - lastColorChangeTime) / fadeDuration;
			ratio = Mathf.Clamp01 (ratio);
			text.color = Color.Lerp (startColor, endColor, ratio);

			if (ratio == 1f) {
				lastColorChangeTime = Time.time;
				// Switch Colors
				Color temp = startColor;
				startColor = endColor;
				endColor = temp;
				warningCycles++;
			}
		}
	}

	public void AddStars(int amount){
		stars += amount;
		UpdateDisplay ();
	}

	public Status UseStars(int amount){
		if (stars >= amount) {
			stars -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

	private void UpdateDisplay(){
		text.text = stars.ToString ();
	}

	public void TooFewStarsWarning(){
		warningCycles = 0;
		tooFewStarsWarning = true;

	}

}
