using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {
	GardenHealthDisplay gardenHealthDisplay;

	void Start(){
		gardenHealthDisplay = GameObject.FindObjectOfType<GardenHealthDisplay> ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Destroy (collider.gameObject);
		if(name.Equals("LoseCollider")){
			gardenHealthDisplay.DamageGarden (1);
		}
	}
}
