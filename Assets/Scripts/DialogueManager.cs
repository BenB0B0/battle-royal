using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;

	public GameObject dBox2;
	public Text dText2;
	public Text goldText;
	public Text hpText;

	public bool dialogActive;
	public bool bowPicked;
	public int arrowsBought;

	public string[] dialogLines;
	public int currentLine;
	private int lineCounter=1;

	private PlayerController thePlayer;
	private MoneyManager theMM;
	private Arrows addArrows;
	private Animator anim;
	private WeaponManager activateWeapon;
	private HurtEnemy hurtEn;
	private EnemyHealthManager theEHM;
	private PlayerHealthManager thePHM;
	public int halfHealthPotion;
	public int fullHealthPotion;
	public int halfHealthPotionCounter;
	public int fullHealthPotionCounter;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		theMM = FindObjectOfType<MoneyManager> ();
		addArrows = FindObjectOfType<Arrows> ();
		activateWeapon = FindObjectOfType<WeaponManager> ();
		hurtEn = FindObjectOfType<HurtEnemy> ();
		theEHM = FindObjectOfType<EnemyHealthManager> ();
		thePHM = FindObjectOfType<PlayerHealthManager> ();


		dBox.SetActive (false);
		dialogActive = false;

		dBox2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogActive && Input.GetKeyUp (KeyCode.Space)) {
		//	dBox.SetActive (false);
		//	dialogActive = false;
			currentLine++;
		}

		/*
		 *  ************************* FOR CASHIER DIALOG **************************************
		 */ 
		if (dialogActive && Input.GetKeyUp (KeyCode.Alpha1)) {
			if (theMM.currentGold >= 5) {
				dialogLines = new string[1];
				arrowsBought = arrowsBought + 5;
				dialogLines [0] = "Order Up!! - - " + arrowsBought + " arrows bought\n" +
					"----------------------------------------------------------\n" +
				"(Press 1) - Buy 5 Arrows *5 Gold* \n" +
				"(Press 2) - Buy a Bow *50 Gold* \n" +
				"(Press 3) - Buy half health potion *10 Gold* \n" +
				"(Press 4) - Buy full health potion *30 Gold*";
				currentLine = 0;
				addArrows.currentArrowAmount = addArrows.currentArrowAmount + 5;
				theMM.AddMoney (-5);
				ShowDialogue2 ();
			} else {
				dialogLines = new string[1];
				dialogLines [0] = "Sorry... You don't have enough gold";
				currentLine = 0;
				ShowDialogue2 ();
			}
		}

		if (dialogActive && Input.GetKeyUp (KeyCode.Alpha2) && lineCounter == 1) {
			if (theMM.currentGold >= 50) {
				activateWeapon.bowpickUp ();
				dialogLines = new string[1];
				dialogLines [0] = "Order Up!! Come back soon\n" +
					"----------------------------------------------------------\n" +
				"(Press 1) - Buy 5 Arrows *5 Gold* \n" +
				"(Press 2) - Buy a Bow *50 Gold* \n" +
				"(Press 3) - Buy half health potion *10 Gold* \n" +
				"(Press 4) - Buy full health potion *30 Gold*";
				currentLine = 0;
				theMM.AddMoney (-50);
				lineCounter++;
				bowPicked = true;
				ShowDialogue2 ();
			} else {
				dialogLines = new string[1];
				dialogLines [0] = "Sorry... You don't have enough gold";
				currentLine = 0;
				ShowDialogue2 ();
			}
		}

		if (dialogActive && Input.GetKeyUp (KeyCode.Alpha3)) {
			if (theMM.currentGold >= 10) {
				dialogLines = new string[1];
				halfHealthPotionCounter++;
				halfHealthPotion++;
				dialogLines [0] = "Order Up!! *" + halfHealthPotionCounter + "* half HP potions bought\n" +
					"----------------------------------------------------------\n" +
				"(Press 1) - Buy 5 Arrows *5 Gold* \n" +
				"(Press 2) - Buy a Bow *50 Gold* \n" +
				"(Press 3) - Buy half health potion *10 Gold* \n" +
				"(Press 4) - Buy full health potion *30 Gold*";
				theMM.AddMoney (-10);
				ShowDialogue2 ();
			} else {
				dialogLines = new string[1];
				dialogLines [0] = "Sorry... You don't have enough gold";
				currentLine = 0;
				ShowDialogue2 ();
			}
		}
		if (dialogActive && Input.GetKeyUp (KeyCode.Alpha4)) {
			if (theMM.currentGold >= 30) {
				dialogLines = new string[1];
				fullHealthPotionCounter++;
				fullHealthPotion++;
				dialogLines [0] = "Order Up!! *" + fullHealthPotionCounter + "* full HP potions bought\n" +
					"----------------------------------------------------------\n" +
					"(Press 1) - Buy 5 Arrows *5 Gold* \n" +
					"(Press 2) - Buy a Bow *50 Gold* \n" +
					"(Press 3) - Buy half health potion *10 Gold* \n" +
					"(Press 4) - Buy full health potion *30 Gold*";
				theMM.AddMoney (-30);
				ShowDialogue2 ();
			} else {
				dialogLines = new string[1];
				dialogLines [0] = "Sorry... You don't have enough gold";
				currentLine = 0;
				ShowDialogue2 ();
			}
		}
		//*************************************************************************************** 


		if (currentLine >= dialogLines.Length) {
			dBox.SetActive (false);
			dBox2.SetActive (false);
			dialogActive = false;
			arrowsBought = 0;
			fullHealthPotionCounter = 0;
			halfHealthPotionCounter = 0;
			lineCounter = 1;
			currentLine = 0;
			thePlayer.canMove = true;
		}


	
		dText.text = dialogLines [currentLine];
		dText2.text = dialogLines [currentLine];
	}

	public void ShowBox(string dialogue){
		dialogActive = true;
		dBox.SetActive (true);
		dText.text = dialogue;
	}

	public void ShowDialogue(){
		dialogActive = true;
		dBox.SetActive (true);
		thePlayer.canMove = false;
	}

	public void ShowBox2(string dialogue){
		dialogActive = true;
		dBox2.SetActive (true);
		dText2.text = dialogue;
		goldText.text = "Gold: " + theMM.currentGold;
	}

	public void ShowDialogue2(){
		dialogActive = true;
		dBox2.SetActive (true);
		thePlayer.canMove = false;
		goldText.text = "Gold: " + theMM.currentGold;
		hpText.text = "HP: " + thePHM.playerCurrentHealth + "/" + thePHM.playerMaxHealth;
	}
}