using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	public int weaponDamage;
	public bool weaponPickedUp;
	public string weaponType;
	public int arrowAmount = 0;
	public bool weaponInInventory = false;
	public List<int> weaponsList = new List<int>();
	public int inventoryNumber;
	public int CurrentSpot;

	private UIManager uiManager;

	// Use this for initialization
	void Start () {
		uiManager = FindObjectOfType<UIManager> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.Q) && weaponPickedUp) {	
			foreach (Transform child in gameObject.transform) {
				child.gameObject.SetActive (false);
			}
			if(CurrentSpot==0){
				CurrentSpot = weaponsList.Count - 1;
				makeWeaponVisible((weaponsList [CurrentSpot]).ToString(), true);
			} else{
				CurrentSpot = CurrentSpot - 1;
				makeWeaponVisible((weaponsList [CurrentSpot]).ToString(), true);
			}
		}

		/*if (Input.GetKeyUp (KeyCode.P)) {	
			weaponsList.RemoveAt (0);
			uiManager.updateWeaponsList = true;
		}*/
	}

	public void makeWeaponVisible(string weapon, bool alreadyHave) {

		weaponPickedUp = true;

		foreach (Transform child in gameObject.transform) {
			child.gameObject.SetActive (false);
		}

		/*
		 * Weapons List
		 */
		if (weapon == "Blue_Sword" || weapon == "0") {
			transform.GetChild (0).gameObject.SetActive (true);
			weaponDamage = 7;
			weaponType = "Sword";
			inventoryNumber = 0;
		}
		if (weapon == "Grey_Sword" || weapon == "1") {
			transform.GetChild (1).gameObject.SetActive (true);
			weaponDamage = 5;
			weaponType = "Sword";
			inventoryNumber = 1;
		}
		if (weapon == "Red_Sword" || weapon == "2") {
			transform.GetChild (2).gameObject.SetActive (true);
			weaponDamage = 9;
			weaponType = "Sword";
			inventoryNumber = 2;
		}
		if (weapon == "Cross_Bow" || weapon == "3") {
			transform.GetChild (3).gameObject.SetActive (true);
			weaponDamage = 3;
			weaponType = "Cross Bow";
			arrowAmount = arrowAmount + 10; //need to remove or fix
			inventoryNumber = 3;
		}

		if (!alreadyHave) {
			weaponsList.Add (inventoryNumber);
			CurrentSpot = weaponsList.Count - 1;
		}
			
		//update inventroy UI
		uiManager.updateWeaponsList = true;
	}
		
}

