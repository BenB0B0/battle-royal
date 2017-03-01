using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MonoBehaviour {

	public int value;
	public MoneyManager theMM;
	private SFXManager sfxMan;
	private CoinCheckActive CCA;

	// Use this for initialization
	void Start () {
		theMM = FindObjectOfType<MoneyManager> ();
		sfxMan = FindObjectOfType<SFXManager> ();
		CCA = FindObjectOfType<CoinCheckActive> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {

			/* 
			 * Checks to see what coin was picked up and then calls the method in "CoinCheckActive" for that coin  
			 */
			if (gameObject.name == "Coin") {
				CCA.coinPickUp ();
			}
			if (gameObject.name == "Coin1") {
				CCA.coin1PickUp ();
			}
			if (gameObject.name == "Coin2") {
				CCA.coin2PickUp ();
			}
			if (gameObject.name == "Coin3") {
				CCA.coin3PickUp ();
			}
			if (gameObject.name == "Coin4") {
				CCA.coin4PickUp ();
			}

			theMM.AddMoney (value);
			Destroy (gameObject);
			sfxMan.coinPickup.Play ();
		}

	}


}
