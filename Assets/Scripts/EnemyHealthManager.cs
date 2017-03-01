using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth; 
	private PlayerStats thePlayerStats; 
	public int expToGive;
	public string enemyQuestName;
	private QuestManager theQM;
	private WeaponManager theWeapon;
	private FloatingNumbers FN;
	private WeaponPickUp WPU;
	public int currentDamage; 
	public int damageToGive;
	private int damageFromWep;

	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;

		thePlayerStats = FindObjectOfType<PlayerStats> ();
		theQM = FindObjectOfType<QuestManager> ();
		theWeapon = FindObjectOfType<WeaponManager> ();
		FN = FindObjectOfType<FloatingNumbers> ();
		WPU = FindObjectOfType<WeaponPickUp> ();
	}

	// Update is called once per frame
	void Update () {

		if (CurrentHealth <= 0) {
			theQM.enemyKilled = enemyQuestName;

			Destroy (gameObject);

			thePlayerStats.AddExperience (expToGive);
		}

	}

	public void HurtEnemy(int damageToGive){
		damageToGive = theWeapon.damageToGive;
		Debug.Log ("EHM HE: " + damageToGive);

		currentDamage = damageToGive + thePlayerStats.currentAttack;
		CurrentHealth -= currentDamage;
	}

	public void SetMaxHealth(){
		CurrentHealth = MaxHealth;
	}
}
