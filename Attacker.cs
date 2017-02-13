using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;

	private float currentSpeed, animSpeed, normalSpeed;
	private GameObject currentTarget;
	private Animator animator;
	private bool isSlowed = false;
	private float slowDuration;

	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D> ();
		myRigidBody.isKinematic = true;
		animator = GetComponent<Animator> ();
		animSpeed = animator.speed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed *Time.deltaTime);

		if (!currentTarget) {
			animator.SetBool ("isAttacking", false);
		}

		if (isSlowed) {
			slowDuration -= Time.deltaTime;
			if (slowDuration <= 0) {
				isSlowed = false;
				GetComponentInChildren<SpriteRenderer> ().color = Color.white;
				if(animator.GetCurrentAnimatorStateInfo(0).IsName("Walking")){
					SetSpeed (normalSpeed);
				}
			}
		}
	}

	//Called from Animator
	public void SetSpeed(float speed){
		if (normalSpeed == 0) {						//Sets the normal speed
			normalSpeed = speed;
		}
		if (isSlowed) {
			float slowingEffect = 0.5f;				//speed reduction
			animator.speed = animSpeed * slowingEffect;
			currentSpeed = speed * slowingEffect;

			GetComponentInChildren<SpriteRenderer> ().color = Color.green;
			return;
		}
		currentSpeed = speed;
	}

	//called from the animator at the time of actual blow
	public void StrikeCurrentTarget(float damage){
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health> ();
			if (health) {
				health.DealDamage (damage);
			}
		}
	}

	//called from gameObject initiating attack animation
	public void Attack(GameObject target){
		currentTarget = target;
	}

	public void Slowed(float duration){
		isSlowed = true;
		slowDuration = duration;
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Walking")){
			SetSpeed (normalSpeed);
		}
	}

}
