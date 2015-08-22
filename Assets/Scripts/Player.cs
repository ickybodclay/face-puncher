using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioClip punchSfx;

	private GameObject leftFist;
	private Animator leftFistAnimator;
	private GameObject rightFist;
	private Animator rightFistAnimator;
	
	void Start () {
		leftFist = transform.Find ("LeftFist").gameObject;
		leftFistAnimator = leftFist.GetComponent<Animator> ();
		rightFist = transform.Find ("RightFist").gameObject;
		rightFistAnimator = rightFist.GetComponent<Animator> ();
	}

	void Update () {
		HandleInput ();
	}

	void HandleInput() {
		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown(KeyCode.Q)) {
			punchLeft();
		}

		if (Input.GetMouseButtonDown (1) || Input.GetKeyDown(KeyCode.W)) {
			punchRight();
		}
	}

	void punchLeft() {
		leftFistAnimator.SetTrigger ("punch");
		GameManager.instance.GetEnemy (0).TakeDamage (true);
		SoundManager.instance.RandomSfx (punchSfx);
	}

	void punchRight() {
		rightFistAnimator.SetTrigger ("punch");
		GameManager.instance.GetEnemy (0).TakeDamage (false);
		SoundManager.instance.RandomSfx (punchSfx);
	}
}
