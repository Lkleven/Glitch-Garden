using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject projectile, gun;
	private GameObject projectilesParent;
	private Animator animator;
	private EnemySpawner myLaneSpawner;

	void Start(){
		//Checks for any GameObject named "Projectiles" to store all projectiles, if not existing, it will create one.
		projectilesParent = GameObject.Find ("Projectiles");
		if (!projectilesParent) {
			projectilesParent = new GameObject("Projectiles");
		}

		animator = GameObject.FindObjectOfType<Animator> ();
		SetMyLaneSpawner ();
	}

	void Update(){
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	private void Fire(){
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectilesParent.transform;
		newProjectile.transform.position = gun.transform.position;
		
	}

	//Look through all spawners, and set myLaneSpawner if found
	private void SetMyLaneSpawner(){
		GameObject spawner = GameObject.Find ("Spawners");
		if (!spawner) {
			Debug.LogError ("Error, no spawner found. Make sure all Spawner objects is a child of 'Spawners' and check the y position");
			return;
		}
		foreach (Transform spawn in spawner.transform) {
			if (spawn.transform.position.y == transform.position.y) {
				myLaneSpawner = spawn.GetComponent<EnemySpawner>();
				return;
			}
		}
	}

	bool IsAttackerAheadInLane(){
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		//Attackers in lane, but behind the defender
		return false;
	}



	//this method is called when object is not visible on any camera
	/*void OnBecameInvisible(){
	}*/
}
