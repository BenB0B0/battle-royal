using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashierDialog : MonoBehaviour {

	public DialogueManager theDM;
	private PlayerController thePlayer;
	public bool cashDialog;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		theDM = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			theDM.dialogLines = new string[1];
			theDM.dialogLines [0] = "Hi, how can I help you? \n" +
				"----------------------------------------------------------\n" +
			"(Press 1) - Buy 5 Arrows *5 Gold* \n" +
			"(Press 2) - Buy a Bow *50 Gold* \n" +
			"(Press 3) - Buy half health potion *10 Gold*\n" +
			"(Press 4) - Buy full health potion *30 Gold*";
			
			theDM.currentLine = 0;
			cashDialog = true;
			theDM.ShowDialogue2 ();
		}
	}
}
