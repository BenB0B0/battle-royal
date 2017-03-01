using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrows : MonoBehaviour {

	public Text arrowText;
	public int currentArrowAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void AddArrows(int arrowsToAdd){
		currentArrowAmount += arrowsToAdd;
		//	PlayerPrefs.SetInt ("CurrentMoney", currentGold);
		arrowText.text = "Arrows: " + currentArrowAmount;
	//	sfxMan.coinPickup.Play ();
	}
}
