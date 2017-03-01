using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HurtEnemy : MonoBehaviour {

	 
	private int currentDamage; 
	public GameObject damageBurst;
	public Transform hitPoint;
	public GameObject damageNumber;
	private FloatingNumbersEnemy damageToGiveHelp;
	private PlayerStats thePS;
	private WeaponManager theWeapon;
	private EnemyHealthManager theEHM;
	public int damageToGive;

	// Use this for initialization
	void Start () {
		thePS = FindObjectOfType<PlayerStats> ();
		damageToGiveHelp = FindObjectOfType<FloatingNumbersEnemy> ();
		theWeapon = FindObjectOfType<WeaponManager> ();
		theEHM = FindObjectOfType<EnemyHealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			//currentDamage = thePS.currentAttack;
		//	currentDamage = damageToGive;
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(theWeapon.damageToGive);
			Instantiate (damageBurst, hitPoint.position, hitPoint.rotation);
			var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero)); 
			clone.GetComponent<FloatingNumbers> ().damageNumber = currentDamage;
		}
	}

}
