using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	public static LevelManager levelManager;

	private int level = 1;
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
		levelManager.SetupScene (level);
	}

	void OnLevelWasLoaded(int index) {
		level++;
		levelManager.SetupScene (level);
	}

	public void AddEnemy(Enemy enemy) {
		enemies.Add (enemy);
	}

	public void RemoveEnemy(int index) {
		enemies.RemoveAt (index);
	}

	public Enemy GetEnemy (int index) {
		return enemies[index];
	}

	public int GetEnemyListSize() {
		return enemies.Count;
	}

	public bool HasEnemies() {
		return enemies.Count > 0;
	}

	public void StartNewLevel() {
		Application.LoadLevel (Application.loadedLevel);
	}
}
