using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

	public AudioSource playerHurt;
	public AudioSource playerDead;
	public AudioSource playerAttack;
	public AudioSource coinPickup;
	public AudioSource swordSheath;
	static SFXManager instance = null;
	private static bool sfxmanExists;

	// Use this for initialization
	void Start () {
		
		if (!sfxmanExists) {
			sfxmanExists = true;
			DontDestroyOnLoad (transform.root.gameObject);
		} else {
			Destroy(gameObject); 
		}


	}
}
