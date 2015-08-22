using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioSource sfxSource;
	public AudioSource musicSource;
	public static SoundManager instance = null;

	public float lowPitchRange = 0.95f;
	public float hiPitchRange = 1.05f;
	
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
	
		DontDestroyOnLoad (this);
	}

	public void PlaySingle (AudioClip clip) {
		sfxSource.pitch = 1;
		sfxSource.clip = clip;
		sfxSource.Play ();
	}

	public void RandomSfx(params AudioClip[] clips) {
		int randomIndex = Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchRange, hiPitchRange);

		sfxSource.pitch = randomPitch;
		sfxSource.PlayOneShot (clips [randomIndex]);
		//sfxSource.clip = clips [randomIndex];
		//sfxSource.Play ();
	}
}
