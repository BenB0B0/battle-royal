using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public GameObject iBox;
	public Text iText;

	public bool dialogActive;

	public string[] dialogLines;
	public int currentLine;

	private PlayerController thePlayer;
	private WeaponManager theWM;
	private DialogueManager theDM;
	private PlayerHealthManager thePHM;

	private string currentSword;
	private string currentBow;
	private bool inventoryActive;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		theWM = FindObjectOfType<WeaponManager> ();
		theDM = FindObjectOfType<DialogueManager> ();
		thePHM = FindObjectOfType<PlayerHealthManager> ();

		iBox.SetActive (false);
		dialogActive = false;
	}

	// Update is called once per frame
	void Update () {

		if (inventoryActive) {
			dialogLines [0] = 
			"------------------*Weapons*------------------\n" +
			"\tSword--> " + currentSword +
			"\n\tBow--> " + currentBow +

			"\n------------------*Potions*------------------\n" +
			"\tHealth Potions:\n" +
			"\t\t(1) Full HP Potions--> " + theDM.fullHealthPotion +
			"\n\t\t(2) Half HP Potions--> " + theDM.halfHealthPotion;
		}
		if (Input.GetKeyUp (KeyCode.B)) {
			currentLine++;
			dialogLines = new string[1];
			inventoryActive = true;
			currentLine = 0;
			ShowDialogue ();
		}

		if (dialogActive && Input.GetKeyUp (KeyCode.Alpha1)) {
			if (theDM.fullHealthPotion > 0) {
				theDM.fullHealthPotion--;
				thePHM.playerCurrentHealth = thePHM.playerMaxHealth; 
			}
		}
		if (dialogActive && Input.GetKeyUp (KeyCode.Alpha2)) {
			if (theDM.halfHealthPotion > 0) {
				theDM.halfHealthPotion--;
				thePHM.playerCurrentHealth = thePHM.playerCurrentHealth + (thePHM.playerMaxHealth/2); 
				if (thePHM.playerCurrentHealth > thePHM.playerMaxHealth) {
					thePHM.playerCurrentHealth = thePHM.playerMaxHealth;
				}
			}
		}

		if (Input.GetKeyUp (KeyCode.Escape)) {
			iBox.SetActive (false);
			dialogActive = false;
			currentLine = 0;
			inventoryActive = false;
		}


		iText.text = dialogLines [currentLine];
	}

	public void ShowBox(string dialogue){
		dialogActive = true;
		iBox.SetActive (true);
		iText.text = dialogue;
	}

	public void ShowDialogue(){
		dialogActive = true;
		iBox.SetActive (true);
	}

	public void getSwordName(string swordName){
		currentSword = swordName;
	}
	public void getBowName(string bowName){
		currentBow = bowName;
	}
}
