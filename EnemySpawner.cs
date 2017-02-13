using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject[] attackerPrefabs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject attacker in attackerPrefabs) {
			if (isTimeToSpawn (attacker)) {
				Spawn (attacker);
			}
		}
	}

	bool isTimeToSpawn(GameObject attacker){
		Attacker attackerScript = attacker.GetComponent<Attacker> ();
		float meanSpawnDelay = attackerScript.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		}

		float threshold = spawnsPerSecond * Time.deltaTime / 5; //5 lanes
		return (Random.value < threshold);
	}

	private void Spawn(GameObject attacker){
		GameObject newAttacker = Instantiate (attacker) as GameObject;
		newAttacker.transform.parent = transform;
		newAttacker.transform.position = transform.position;
	}
}
