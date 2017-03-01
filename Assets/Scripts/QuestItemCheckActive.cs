using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemCheckActive : MonoBehaviour {

	public GameObject checkCrystal;

	// Use this for initialization
	void Start () {
		if (gameObject.tag == "ItemCheck") {
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	/*
	 * Methods that get called from "QuestItem" depending on what item is picked up 
	 * Methods set the item check active that corresponds to the item that was picked up 
	 */ 
	public void crystalPickUp(){
		checkCrystal.SetActive (true);
	}

	void OnLevelWasLoaded(int level){
		/*
		 * set variables that point to the item check objects 
		 */ 
		var crystalCheck = GameObject.Find ("QuestTriggers/CrystalCheck");

		/*
		 * set variables that point to the actual item 
		 */ 
		var crystal = GameObject.Find ("QuestTriggers/Crystal");
	
		/*
		 * if item check is active that means coin was picked up so destroy the item
		 */
		if (crystalCheck.activeSelf) {
		//	Destroy (crystal);
		}
	}
}
