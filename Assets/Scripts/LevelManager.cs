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

		for (int i=0; i<3; ++i) {
			GameObject eInstance = Instantiate (victims[0], new Vector3 (0f, -1.4f, 0f), Quaternion.identity) as GameObject;
			eInstance.transform.SetParent (levelHolder);
		}
	}

	public void SetupScene (int level) {
		SetupLocation ();
		SetupVictims (level);
	}
}
