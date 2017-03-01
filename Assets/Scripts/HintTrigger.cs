using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTrigger : MonoBehaviour {

	public HintManager theHM;
	private static bool hintTrigExists;

	// Use this for initialization
	void Start () {
		if (!hintTrigExists) {
			hintTrigExists = true;
			DontDestroyOnLoad (transform.root.gameObject);
		} else {
			Destroy(gameObject); 
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			theHM.dialogLines = new string[1];
			theHM.dialogLines [0] = "Press (E) to pick up";
			theHM.currentLine = 0;
			theHM.ShowDialogue ();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		theHM.HideDialogue();
		Destroy (gameObject);
	}
}
