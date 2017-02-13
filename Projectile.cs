using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float speed, damage;
	Slime slime;

	// Use this for initialization
	void Start () {
		slime = GetComponent<Slime> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collider){
		GameObject target = collider.gameObject;
		if (!target.GetComponent<Attacker>()){
			return;
		}
		if(slime){target.GetComponent<Attacker> ().Slowed(slime.slowingDuration);}
		Health health = target.GetComponent<Health> ();
		health.DealDamage (damage);
		Destroy (gameObject);

	}
}
