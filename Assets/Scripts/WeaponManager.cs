using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	private WeaponPickUp weapon;
	public GameObject weaponsName;
	//public bool weaponActive;
	public int damageToGive;
	private bool weakSword;
	public bool bowPickedUp;
	private PlayerController thePC;
	public string currentSword;
	public string theBow;
	private UIManager UIM;
	private Inventory theInv;

	// Use this for initialization
	void Start () {
		weapon = FindObjectOfType<WeaponPickUp> ();
		gameObject.SetActive (false);
		thePC = FindObjectOfType<PlayerController> ();
		UIM = FindObjectOfType<UIManager> ();
		theInv = FindObjectOfType<Inventory> ();
		//weakpickUp (1);

	}

	// Update is called once per frame
	void Update () {
	}

	public void weakpickUp(){
		deactivate ();
		var weakSword = GameObject.Find("Player/Weapon/WeakSword");
		weakSword.SetActive (true);
		weakSword.GetComponent<WeaponManager>().damageToGive = 2;
		weakSword.GetComponent<WeaponManager>().currentSword = "Grey Stone +2";
		UIM.wepDam (weakSword.GetComponent<WeaponManager> ().damageToGive);
		theInv.getSwordName (weakSword.GetComponent<WeaponManager> ().currentSword);
	}
	public void mediumpickUp(){
		deactivate ();
		var mediumSword = GameObject.Find("Player/Weapon/MediumSword");
		mediumSword.SetActive (true);
		mediumSword.GetComponent<WeaponManager>().damageToGive = 4;
		mediumSword.GetComponent<WeaponManager>().currentSword = "Blue Lightning +4";
		UIM.wepDam (mediumSword.GetComponent<WeaponManager> ().damageToGive);
		theInv.getSwordName (mediumSword.GetComponent<WeaponManager> ().currentSword);
	}
	public void thinpickUp(){
		deactivate ();
		var thinSword = GameObject.Find("Player/Weapon/ThinSword");
		thinSword.SetActive (true);
		thinSword.GetComponent<WeaponManager>().damageToGive = 1;
		thinSword.GetComponent<WeaponManager>().currentSword = "Silver Pin +1";
		UIM.wepDam (thinSword.GetComponent<WeaponManager> ().damageToGive);
		theInv.getSwordName (thinSword.GetComponent<WeaponManager> ().currentSword);
	}
	public void bowpickUp(){
		bowPickedUp = true;
		var bow = GameObject.Find("Player/Bow/bow");
		bow.GetComponent<SpriteRenderer> ().enabled = true; 
		bow.GetComponent<WeaponManager>().theBow = "Blue Bolt +Mimics Sword Damage";
		theInv.getBowName (bow.GetComponent<WeaponManager> ().theBow);
	}

	public void deactivate(){
		var weakSword = GameObject.Find("Player/Weapon/WeakSword");
		weakSword.SetActive (false);
		var mediumSword = GameObject.Find("Player/Weapon/MediumSword");
		mediumSword.SetActive (false);
		var thinSword = GameObject.Find("Player/Weapon/ThinSword");
		thinSword.SetActive (false);
	}
}
