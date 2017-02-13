using UnityEngine;
using System.Collections;

//Used as a tag for other scripts (GetComponent<Stone>())
public class Stone : MonoBehaviour {
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D collider){
		Attacker attacker = collider.gameObject.GetComponent<Attacker> ();
		if (attacker && !attacker.gameObject.GetComponent<Fox>()) {				//Fox does not trigger the "underAttakTrigger" as it jumps across
			animator.SetTrigger ("underAttackTrigger");
		}
	}
}
