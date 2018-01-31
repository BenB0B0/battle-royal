using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour {

	private WeaponManager weaponManager;
	private bool playerCanPickUpWeapon = false;

	// Use this for initialization
	void Start () {
		weaponManager = FindObjectOfType<WeaponManager> ();

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E) && playerCanPickUpWeapon) {
			this.gameObject.SetActive (false);
			weaponManager.makeWeaponVisible (this.gameObject.name, false);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			this.transform.GetChild (0).gameObject.SetActive (true);
			playerCanPickUpWeapon = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		transform.GetChild (0).gameObject.SetActive (false);
		playerCanPickUpWeapon = false;
	}
}

