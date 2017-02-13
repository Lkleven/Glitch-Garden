using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))] //will add an attacker component if missing
public class Fox : MonoBehaviour {
	private Attacker attackerScript;
	private Animator animator;

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

		if (target.GetComponent<Stone> ()) {
			animator.SetTrigger ("jumpTrigger");
		} else {
			animator.SetBool ("isAttacking", true);
			attackerScript.Attack (target);
		}
	}
}
