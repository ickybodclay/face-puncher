using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float levelStartDelay = 2f;

	public GameObject background;
	public GameObject[] victims;

	private GameObject levelStartImage;
	private Transform levelHolder; 
	private bool starting = true;

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
		starting = true;
		//levelStartImage = GameObject.Find("LevelStartImage");
		//levelStartImage.SetActive (true);
		//levelStartImage.GetComponent<Image> ().CrossFadeAlpha (0f, levelStartDelay, false);
		print ("Setup: current level = " + level);
		SetupVictims (level);
		starting = false;
		//Invoke ("HideLevelStartImage", levelStartDelay);
	}

	void HideLevelStartImage() {
		//levelStartImage.SetActive(false);
		//levelStartImage.GetComponent<Image> ().CrossFadeAlpha (1f, 0f, true);
		starting = false;
	}

	public bool isStarting() {
		return starting;
	}
}
