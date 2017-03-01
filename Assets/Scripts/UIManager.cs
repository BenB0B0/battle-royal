using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Slider XP;
	public Text HPText;
	private static bool UIExists;
	public PlayerHealthManager playerHealth;
	private PlayerStats thePS;
	private WeaponManager theWeapon;
	private EnemyHealthManager theEHM;
	private HurtEnemy theHE;
	private Arrows amountOfArrows;
	public Text levelText;
	public Text attackText;
	public Text defenseText;
	public Text weaponPowerText;
	public Text amountOfArrowsText;
	private int weponDamage;

	// Use this for initialization
	void Start () {
		if (!UIExists) {
			UIExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy(gameObject); 
		}
			
		thePS = GetComponent<PlayerStats> ();
		theWeapon = FindObjectOfType<WeaponManager> ();
		amountOfArrows = FindObjectOfType<Arrows> ();
		theEHM = FindObjectOfType<EnemyHealthManager> ();
		theHE = FindObjectOfType<HurtEnemy> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		XP.maxValue = thePS.toLevelUp[thePS.currentLevel];
		XP.value = thePS.currentExp;
		HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
		levelText.text = "Lvl: " + thePS.currentLevel;
		attackText.text = "Attack: " + thePS.currentAttack;
		defenseText.text = "Defense: " + thePS.currentDefense;

		weaponPowerText.text = "Weapon Power: " + weponDamage;

		amountOfArrowsText.text = "Arrows Left: " + amountOfArrows.currentArrowAmount;
	}

	public void wepDam(int wepDamage){
		weponDamage = wepDamage;
	}
}
