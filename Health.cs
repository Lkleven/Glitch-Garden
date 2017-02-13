using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float currentHealth = 200f;
	private float fullHealth;
	private GameObject healthBar;
	private Vector3 fullHealthScale, temp;

	void Start(){
		fullHealth = currentHealth;
		healthBar = transform.Find ("HealthBar").gameObject;
		if (!healthBar) {
			Debug.LogWarning (name + " Make sure all attacker/defender prefabs contain a 'HealthBar' game object");
		}
		fullHealthScale = healthBar.GetComponent<Transform> ().localScale;
		temp = fullHealthScale;
	}

	void Update(){
	}


	public void DealDamage (float damage){
		currentHealth -= damage;
		UpdateHealthBar ();
		if(currentHealth <= 0){
			//animation?
			DestroyObject();
		}
	}

	public void DestroyObject(){
		Destroy (gameObject);
	}

	private void UpdateHealthBar (){
		//Vector3 temp = healthBar.GetComponent<Transform> ().localScale;		//initial scale
		float healthPercentageRemaining = currentHealth / fullHealth;		//health percentage
		temp.x = fullHealthScale.x * healthPercentageRemaining;

		healthBar.GetComponent<Transform> ().localScale = temp;
	}
}
