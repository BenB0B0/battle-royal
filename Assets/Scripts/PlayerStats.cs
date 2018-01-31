using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public int currentLevel;
	public int currentExp; 

	public int[] toLevelUp;
	public int[] HPLevels;
	public int[] attackLevels;
	public int[] defenceLevels;

	public int currentHP;
	public int currentAttack;
	public int currentDefense;
	public float currentStamina;
	public int maxStamina;

	private PlayerHealthManager thePlayerHealth;
	private PlayerController thePlayerController;

	// Use this for initialization
	void Start () {
		currentHP = HPLevels [1];
		currentAttack = attackLevels [1];
		currentDefense = defenceLevels [1];

		maxStamina = 190;
		currentStamina = 100;

		thePlayerHealth = FindObjectOfType<PlayerHealthManager> ();
		thePlayerController = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentExp >= toLevelUp [currentLevel]) {
			//currentLevel++;
			LevelUp();
		}

		if (thePlayerController.moveSpeed == 7 && currentStamina > 0) {
			currentStamina--;
		} else if (thePlayerController.moveSpeed == 5 && currentStamina < maxStamina) {
			currentStamina+=.1f;
		}
		if (thePlayerController.dashing) {
			currentStamina = currentStamina - 100;
			thePlayerController.dashing = false;
		}

	}

	public void AddExperience(int experienceToAdd){
		currentExp += experienceToAdd; 
	}

	public void LevelUp(){
		currentLevel++;
		currentHP = HPLevels [currentLevel];

		thePlayerHealth.playerMaxHealth = currentHP;
		thePlayerHealth.playerCurrentHealth += currentHP - HPLevels[currentLevel - 1];

		currentAttack = attackLevels [currentLevel];
		currentDefense = defenceLevels [currentLevel];

		maxStamina += 10;
	}
}
