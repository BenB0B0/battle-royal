using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

	public int questNumber;

	private QuestManager theQM;

	public string itemName;

	private QuestItemCheckActive QICA;
	public MoneyManager theMM;

	public int coinReward;

	// Use this for initialization
	void Start () {
		theQM = FindObjectOfType<QuestManager> ();
		QICA = FindObjectOfType<QuestItemCheckActive> ();
		theMM = FindObjectOfType<MoneyManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (theQM.questCompleted [questNumber]) {
			if (gameObject.name == itemName) {
				Destroy (gameObject);
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			if (!theQM.questCompleted [questNumber] && theQM.quests [questNumber].gameObject.activeSelf) {
				theQM.itemCollected = itemName;

				/* 
				 * Checks to see what item was picked up and then calls the method in "QuestItemCheckActive" for that item  
				 */
				if (gameObject.name == "Crystal") {
				//	QICA.crystalPickUp ();
					theMM.AddMoney (coinReward);

				}
					
				Destroy (gameObject);
				//gameObject.SetActive (false);
			}
		}
	}
}
