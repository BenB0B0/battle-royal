using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogHolder : MonoBehaviour {

	public string dialogue;
	private DialogueManager dMan;
	public string[] dialogLines;
	public bool check;


	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (check) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				//	dMan.ShowBox (dialogue);
				if (!dMan.dialogActive) {
					dMan.dialogLines = dialogLines;
					dMan.currentLine = 0;
					dMan.ShowDialogue ();
				}

				if (transform.parent.GetComponent<villigerMovement> () != null) {
					transform.parent.GetComponent<villigerMovement> ().canMove = false;
				}
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			check = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			check = false;
		}
	}
}