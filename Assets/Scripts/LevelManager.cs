using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject background;
	public GameObject[] victims;

	private Transform levelHolder; 

	void SetupLocation () {
		// TODO pick location and set background
	}

	void SetupVictims (int level) {
		levelHolder = new GameObject ("Level").transform;

		for (int i=0; i<level; ++i) {
			int victimIndex = 0;

			if(Random.value > 0.8f) victimIndex = 1;

			GameObject eInstance = Instantiate (victims[victimIndex], new Vector3 (0f, -1.4f, 0f), Quaternion.identity) as GameObject;
			eInstance.transform.SetParent (levelHolder);
		}
	}

	public void SetupScene (int level) {
		print ("Setup: current level = " + level);
		SetupLocation ();
		SetupVictims (level);
	}
}
