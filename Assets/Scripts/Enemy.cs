using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private Animator animator;
	private bool isFlipped;
	private int health;
	
	void Start () {
		GameManager.instance.AddEnemy (this);

		Randomize ();

		animator = GetComponent<Animator> ();

		isFlipped = false;
		health = Random.Range (3, 5);
	}

	void Randomize() {
		Vector3 scale = transform.localScale;
		scale.x = Random.Range (0.65f, 0.75f);
		scale.y = Random.Range (0.65f, 0.75f);
		transform.localScale = scale;

		Vector3 position = transform.localPosition;
		position.x = Random.Range (-0.1f, 0.1f);
		position.y = 0;
		transform.localPosition = position;

		float r = Random.Range (0f, 1f);
		float g = Random.Range (0f, 1f);
		float b = Random.Range (0f, 1f);

		GetComponent<SpriteRenderer> ().color = new Color (r, g, b);
	}

	void Update () {
	
	}

	public void TakeDamage(bool isLeftPunch, out bool knockedOut) {
		if (isLeftPunch && isFlipped) {
			Flip ();
		} else if(!isLeftPunch && !isFlipped) {
			Flip ();
		}

		animator.SetTrigger ("Hit");
		health--;
		knockedOut = health <= 0;

		if (knockedOut) {
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
