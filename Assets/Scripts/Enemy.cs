using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Animator animator;
	private bool isFlipped;
	private int health;
	
	void Start () {
		GameManager.instance.AddEnemy (this);

		animator = GetComponent<Animator> ();

		isFlipped = false;
		health = Random.Range (1, 3);
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
		health--;

		if (health <= 0) {
			animator.SetBool ("KnockedOut", true);
			StartCoroutine(KnockOut());
		}
	}

	private IEnumerator KnockOut () {
		yield return new WaitForSeconds(0.25f);
		GameManager.instance.RemoveEnemy (0); // cheat since first enemy is always one you are punching
		Destroy (this.gameObject);
	}

	public void Flip() {
		isFlipped = !isFlipped;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

}
