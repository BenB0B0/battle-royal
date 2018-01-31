using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Slider staminaBar;
	public Text HPText;
	public Text StaminaText;
	private static bool UIExists;
	private PlayerStats thePS;
	public Text levelText;

	public Text weaponText;
	public Text ammoText;
	public Text inventoryWeapons;
	public bool updateWeaponsList=false;
	private int weaponCounter;

	public PlayerHealthManager playerHealth;
	public WeaponManager weaponManager;

	// Use this for initialization
	void Start () {
		if (!UIExists) {
			UIExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy(gameObject); 
		}

		thePS = GetComponent<PlayerStats> ();
		weaponManager = FindObjectOfType<WeaponManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	   /*
		* Health and Level UI
		*/
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		if (playerHealth.playerCurrentHealth > 0) {
			HPText.text = "Health: " + playerHealth.playerCurrentHealth + " / " + playerHealth.playerMaxHealth;
		} else {
			HPText.text = "Health: Dead";
		}
		levelText.text = "Lvl: " + thePS.currentLevel;
		StaminaText.text = "Stamina: " + Mathf.Round(thePS.currentStamina) + " / " + thePS.maxStamina;

		/*
		 * Stamina UI
		 */ 
		staminaBar.maxValue = thePS.maxStamina;
		staminaBar.value = thePS.currentStamina;

		/*
		 * Weapon UI
		 */ 
		if (weaponManager.weaponPickedUp) {
			weaponText.text = "Weapon: " + weaponManager.weaponType;
			ammoText.text = "Ammo: " + weaponManager.arrowAmount;
		} else {
			weaponText.text = "Weapon: --";
			ammoText.text = "Ammo: --";
		}
		if (weaponManager.weaponType == "Sword") {
			ammoText.text = "Ammo: ∞";
		}

		/*
		 * Inventory UI
		 */ 
		if (updateWeaponsList) {
			inventoryWeapons.text = "";
			weaponCounter = 1;
			foreach (int weapon in weaponManager.weaponsList) {
				inventoryWeapons.text += weaponCounter + ") " + weaponManager.transform.GetChild (weapon).gameObject.name + "\n";
				weaponCounter++;
			}
			updateWeaponsList = false;
		}

	}
}
