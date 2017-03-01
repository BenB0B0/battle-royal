using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCheckActive : MonoBehaviour {
	
	public GameObject coinCheck;
	public GameObject coinCheck1;
	public GameObject coinCheck2;
	public GameObject coinCheck3;
	public GameObject coinCheck4;

	// Use this for initialization
	void Start () {
		if (gameObject.tag == "CoinCheck") {
			gameObject.SetActive (false);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*
	 * Methods that get called from "GoldPickUp" depending on what coin is picked up 
	 * Methods set the coin check active that corresponds to the coin that was picked up 
	 */ 
	public void coinPickUp(){
		coinCheck.SetActive (true);
	}
	public void coin1PickUp(){
		coinCheck1.SetActive (true);
	}
	public void coin2PickUp(){
		coinCheck2.SetActive (true);
	}
	public void coin3PickUp(){
		coinCheck3.SetActive (true);
	}
	public void coin4PickUp(){
		coinCheck4.SetActive (true);
	}
	//--------------------------------------------------------------------------------

	//When level is loaded 
	void OnLevelWasLoaded(int level){

		/*
		 * set variables that point to the coinCheck objects 
		 */ 
		var coinCheck = GameObject.Find("Money/CoinCheck");
		var coinCheck1 = GameObject.Find("Money/CoinCheck1");
		var coinCheck2 = GameObject.Find("Money/CoinCheck2");
		var coinCheck3 = GameObject.Find("Money/CoinCheck3");
		var coinCheck4 = GameObject.Find("Money/CoinCheck4");

		/*
		 * set variables that point to the actual coins 
		 */ 
		var coin = GameObject.Find ("Money/Coin");
		var coin1 = GameObject.Find ("Money/Coin1");
		var coin2 = GameObject.Find ("Money/Coin2");
		var coin3 = GameObject.Find ("Money/Coin3");
		var coin4 = GameObject.Find ("Money/Coin4");

		/*
		 * if coin check is active that means coin was picked up so destroy the coin
		 */ 
		if (coinCheck.activeSelf) {
			Destroy (coin);
		}
		if (coinCheck1.activeSelf) {
			Destroy (coin1);
		}
		if (coinCheck2.activeSelf) {
			Destroy (coin2);
		}
		if (coinCheck3.activeSelf) {
			Destroy (coin3);
		}
		if (coinCheck4.activeSelf) {
			Destroy (coin4);
		}
		//----------------------------------------------------------------------------
	}
}
