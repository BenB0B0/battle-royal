using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour {

	public float moveSpeed;
	public int damageNumber;
	public Text displayNumber;
	private int currentDamage;
	private HurtEnemy hurtEn;
	private EnemyHealthManager theEHM;
	private WeaponManager theWeapon;
	private PlayerStats thePlayerStats; 
	public int damageCheck;

	// Use this for initialization
	void Start () {
		thePlayerStats = FindObjectOfType<PlayerStats> ();
		hurtEn = FindObjectOfType<HurtEnemy> ();
		theEHM = FindObjectOfType<EnemyHealthManager> ();
		theWeapon = FindObjectOfType<WeaponManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentDamage = theWeapon.damageToGive + thePlayerStats.currentAttack;

		displayNumber.text = "" + currentDamage;
		transform.position = new Vector3 (transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
	}
}
