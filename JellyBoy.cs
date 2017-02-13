using UnityEngine;
using System.Collections;

public class JellyBoy : MonoBehaviour {
	Attacker attackerScript;
	Animator animator;

	// Use this for initialization
	void Start () {
		attackerScript = GetComponent<Attacker> ();
		animator = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		GameObject target = collider.gameObject;

		if (!target.GetComponent<Defender>()){
			return;
		}
		animator.SetBool ("isAttacking", true);
		attackerScript.Attack (target);
	}
}
