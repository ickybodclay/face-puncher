using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	public static LevelManager levelManager;

	private List<Enemy> enemies; 

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);    
		}

		DontDestroyOnLoad(gameObject);

		enemies = new List<Enemy> (); 

		InitGame ();
	}

	void InitGame() {
		enemies.Clear ();
		levelManager = GetComponent<LevelManager> ();
		levelManager.SetupScene (0);
	}

	public void AddEnemy(Enemy enemy) {
		enemies.Add (enemy);
	}

	public Enemy GetEnemy (int index) {
		return enemies[index];
	}
}
