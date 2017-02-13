using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {
	public float fadeInTime = 1.5f;

	private Image fadePanel;
	private Color color;


	// Use this for initialization
	void Start () {
		fadePanel = gameObject.GetComponent<Image> ();
		color = fadePanel.color;
		color.a = 1.0f;
		fadePanel.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) {
			float alphaChange = Time.deltaTime / fadeInTime;
			color.a -= alphaChange;
			fadePanel.color = color;
			
		} else {
			gameObject.SetActive (false);
		}
	
	}
}
