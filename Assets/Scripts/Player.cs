﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioClip[] startSfx;
	public AudioClip punchSfx;
	public AudioClip koSfx;
	public AudioClip finisherSfx;

	private GameObject leftFist;
	private Animator leftFistAnimator;
	private GameObject rightFist;
	private Animator rightFistAnimator;

	private bool hasStarted;
	private bool isStarting;
	private bool isRestarting;
	
	void Start () {
		leftFist = transform.Find ("LeftFist").gameObject;
		leftFistAnimator = leftFist.GetComponent<Animator> ();
		rightFist = transform.Find ("RightFist").gameObject;
		rightFistAnimator = rightFist.GetComponent<Animator> ();

		//leftFist.GetComponent<SpriteRenderer> ().color = Color.red;
		//rightFist.GetComponent<SpriteRenderer> ().color = Color.red;

		hasStarted = false;
		isRestarting = false;
	}

	void StartLevel() {
		SoundManager.instance.PlaySingle (startSfx[0]);
		isStarting = true;
		Invoke ("DelayStart", 2f);
	}

	void DelayStart() {
		isStarting = false;
	}

	void Restart() {
		GameManager.instance.StartNewLevel ();
		isRestarting = false;
	}

	void Update () {
		HandleInput ();
	}

	void HandleInput() {
		if (GameManager.levelManager.isStarting ()) {
			return;
		} 
		else if(!hasStarted) {
			StartLevel();
			hasStarted = true;
		}

		if (isStarting || isRestarting) {
			return;
		}

		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown(KeyCode.Q)) {
			punchLeft();
		}

		if (Input.GetMouseButtonDown (1) || Input.GetKeyDown(KeyCode.W)) {
			punchRight();
		}
	}

	void punchLeft() {
		leftFistAnimator.SetTrigger ("punch");
		bool knockedOut = false;
		if (GameManager.instance.HasEnemies ())
			GameManager.instance.GetEnemy (0).TakeDamage (true, out knockedOut);
		playSfx (knockedOut);
	}

	void punchRight() {
		rightFistAnimator.SetTrigger ("punch");
		bool knockedOut = false;
		if (GameManager.instance.HasEnemies ())
			GameManager.instance.GetEnemy (0).TakeDamage (false, out knockedOut);
		playSfx (knockedOut);
	}

	void playSfx(bool knockedOut) {
		if (knockedOut) {
			SoundManager.instance.RandomSfx (koSfx);

			if (GameManager.instance.GetEnemyListSize () == 1) {
				SoundManager.instance.PlaySingle (finisherSfx);
				isRestarting = true;
				Invoke ("Restart", 4f);
			}
		} 
		else {
			SoundManager.instance.RandomSfx (punchSfx);
		}
	}
}
