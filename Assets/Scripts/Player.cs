using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

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
		if (Input.GetMouseButtonDown (0)) {
			punchLeft();
		}

		if (Input.GetMouseButtonDown (1)) {
			punchRight();
		}
	}

	void punchLeft() {
		leftFistAnimator.SetTrigger ("punch");
		GameManager.instance.GetEnemy (0).TakeDamage (true);
	}

	void punchRight() {
		rightFistAnimator.SetTrigger ("punch");
		GameManager.instance.GetEnemy (0).TakeDamage (false);
	}
}
