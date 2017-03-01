using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour {

	public GameObject hBox;
	public Text hText;

	public bool dialogActive;

	public string[] dialogLines;
	public int currentLine;

	private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
	}

	// Update is called once per frame
	void Update () {
		//	dBox.SetActive (false);
		//	dialogActive = false;
		//currentLine++;
		

		if (currentLine >= dialogLines.Length) {
			hBox.SetActive (false);
			dialogActive = false;

			currentLine = 0;
		//	thePlayer.canMove = true;
		}

		hText.text = dialogLines [currentLine];
	}

	public void ShowBox(string dialogue){
		dialogActive = true;
		hBox.SetActive (true);
		hText.text = dialogue;
	}

	public void ShowDialogue(){
		dialogActive = true;
		hBox.SetActive (true);
	//	thePlayer.canMove = false;
	}

	public void HideDialogue(){
		dialogActive = false;
		hBox.SetActive (false);
	}
}