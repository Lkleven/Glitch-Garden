using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {
	private Button[] buttons;
	private Text costText;

	public static GameObject selectedDefender;
	public GameObject defenderPrefab;

	// Use this for initialization
	void Start () {
		buttons = Object.FindObjectsOfType<Button> ();
		SetCost ();

	}

	private void SetCost(){
		//costText = transform.Find ("Cost/Price").gameObject.GetComponent<Text>();
		costText = GetComponentInChildren<Text>();
		if (!costText) {
			Debug.LogWarning (name + "No cost text found. Make sure there is a Price Text object within a Cost gameObject on the buy defender buttons");
		}
		int cost = defenderPrefab.GetComponent<Defender> ().starCost; //starCost as defined in Defender script/unity gameObject
		costText.text = cost.ToString ();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//highlights the selected button
	void OnMouseDown(){
		foreach (Button button in buttons){
			DeselectButtons (button);
		}

		if (this.GetComponent<SpriteRenderer> ()) {
			this.GetComponent<SpriteRenderer> ().color = Color.white;
			selectedDefender = defenderPrefab;
			return;
		}
		foreach (Transform child in transform) {
			if (!child.name.Equals ("Cost")) {
				child.GetComponent<SpriteRenderer> ().color = Color.white;
				selectedDefender = defenderPrefab;
			}
		}

	}

	//makes all buttons go black
	private void DeselectButtons(Button button){
		if (button.GetComponent<SpriteRenderer> ()) {
			button.GetComponent<SpriteRenderer> ().color = Color.black;
			return;
		}
		foreach (Transform child in button.transform) {
			if (!child.name.Equals ("Cost")) {
				child.GetComponent<SpriteRenderer> ().color = Color.black;
			}
		}
	}
}
