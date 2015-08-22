using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Animator animator;
	private bool isFlipped;
	
	void Start () {
		GameManager.instance.AddEnemy (this);

		animator = GetComponent<Animator> ();

		isFlipped = false;
	}

	void Update () {
	
	}

	public void TakeDamage(bool isLeftPunch) {
		if (isLeftPunch && isFlipped) {
			Flip ();
		} else if(!isLeftPunch && !isFlipped) {
			Flip ();
		}

		animator.SetTrigger ("Hit");
	}

	public void Flip() {
		isFlipped = !isFlipped;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

}
