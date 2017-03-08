using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGameEvent : MonoBehaviour {

	private Animator anim; 
	private dialogHolder theDH;
	private WeaponManager theWM;

	public string dialogue;
	private DialogueManager dMan;
	public string[] dialogLines;
	public bool check;

	// Use this for initialization
	void Start () {
		var sister = GameObject.Find("sister");
		anim = sister.GetComponent<Animator> ();
		theDH = FindObjectOfType<dialogHolder> ();
		theWM = FindObjectOfType<WeaponManager> ();
		dMan = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			anim.SetBool ("Sister_Start", true);

			dMan.dialogLines = dialogLines;
			dMan.currentLine = 0;
			dMan.ShowDialogue ();
		}
	}
}
