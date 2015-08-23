using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject background;
	public GameObject[] victims;

	private Transform levelHolder; 

	private static readonly float WEAK_SPAWN_CHANCE = 0.3f;

	void SetupVictims (int level) {
		levelHolder = new GameObject ("Level").transform;

		for (int i=0; i<level; ++i) {
			int victimIndex = 0;

			if(Random.value <= WEAK_SPAWN_CHANCE) victimIndex = 1;

			GameObject eInstance = Instantiate (victims[victimIndex], new Vector3 (0f, -1.4f, 0f), Quaternion.identity) as GameObject;
			eInstance.transform.SetParent (levelHolder);
		}
	}

	public void SetupScene (int level) {
		print ("Setup: current level = " + level);
		SetupVictims (level);
	}
}
