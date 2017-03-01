using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkHintTrigger : MonoBehaviour {
	public HintManager theHM;
	private static bool hintTalkTrigExists;
	// Use this for initialization
	void Start () {
		if (!hintTalkTrigExists) {
			hintTalkTrigExists = true;
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
			theHM.dialogLines [0] = "Press (Space) to talk";
			theHM.currentLine = 0;
			theHM.ShowDialogue ();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		theHM.HideDialogue();
	}
}
