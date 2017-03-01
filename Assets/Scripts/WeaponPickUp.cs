using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour {
	
	private WeaponManager activateWeapon;
	public HintManager theHM;
	private EnemyHealthManager theEHM;
	private HurtEnemy hurten;
	public int damageCheck;
	private static bool weaponExists;
	private HintTrigger hintTrigger;
	private SFXManager sfxMan;
	private Animator anim;
	private bool check;
	public bool swordInHand;

	//private static weakSwordCheck = false;

	// Use this for initialization
	void Start () {
		activateWeapon = FindObjectOfType<WeaponManager> ();
		theEHM = FindObjectOfType<EnemyHealthManager> ();
		hurten = FindObjectOfType<HurtEnemy> ();
		hintTrigger = FindObjectOfType<HintTrigger> ();
		sfxMan = FindObjectOfType<SFXManager> ();
		anim = FindObjectOfType<PlayerController>().GetComponent<Animator> ();
	
		//DontDestroyOnLoad (transform.gameObject);
		//gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {

		if (check) {
			if (Input.GetKey (KeyCode.E)) {

				anim.SetBool ("SwordPickUp", true);
				swordInHand = true;

				//	activateWeapon.gameObject.SetActive (false);
				sfxMan.swordSheath.Play ();
				if (gameObject.name == "weakSwordPickUp") {
					Destroy (gameObject);
					activateWeapon.weakpickUp ();
				}
				if (gameObject.name == "mediumSwordPickUp") {
					Destroy (gameObject);
					activateWeapon.mediumpickUp ();
				}
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			check = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			check = false;
		}
	}

	void OnLevelWasLoaded(int level){
		var weakSword = GameObject.Find("Player/Weapon/WeakSword");
		var weakSwordTrigger = GameObject.Find("weakSwordPickUp");
		var mediumSword = GameObject.Find("Player/Weapon/MediumSword");
		var mediumSwordTrigger = GameObject.Find ("mediumSwordPickUp");

		if (weakSword.activeSelf) {
			Destroy (weakSwordTrigger);
		}
		if (mediumSword.activeSelf) {
			Destroy (mediumSwordTrigger);
		}
	}
}
