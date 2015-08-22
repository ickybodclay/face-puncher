using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioClip startSfx;
	public AudioClip punchSfx;
	public AudioClip koSfx;
	public AudioClip finisherSfx;

	private GameObject leftFist;
	private Animator leftFistAnimator;
	private GameObject rightFist;
	private Animator rightFistAnimator;

	private bool isStarting;
	private bool isRestarting;
	
	void Start () {
		leftFist = transform.Find ("LeftFist").gameObject;
		leftFistAnimator = leftFist.GetComponent<Animator> ();
		rightFist = transform.Find ("RightFist").gameObject;
		rightFistAnimator = rightFist.GetComponent<Animator> ();

		isRestarting = false;

		leftFist.GetComponent<SpriteRenderer> ().color = Color.red;
		rightFist.GetComponent<SpriteRenderer> ().color = Color.red;

		SoundManager.instance.PlaySingle (startSfx);
		isStarting = true;
		Invoke ("DelayStart", 2f);
	}

	void Update () {
		HandleInput ();
	}

	void HandleInput() {
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
		SoundManager.instance.RandomSfx (punchSfx);

		if (knockedOut) {
			if (GameManager.instance.GetEnemyListSize () == 1) {
				SoundManager.instance.PlaySingle (finisherSfx);
				isRestarting = true;
				Invoke ("Restart", 3f);
			}
			else {
				SoundManager.instance.RandomSfx (koSfx);
			}
		}
	}

	void DelayStart() {
		isStarting = false;
	}

	void Restart() {
		GameManager.instance.StartNewLevel ();
		isRestarting = false;
		SoundManager.instance.PlaySingle (startSfx);
	}
}
