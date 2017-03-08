using UnityEngine;
using System.Collections;

public class QuestTrigger : MonoBehaviour {

    private QuestManager theQM;

    public int questNumber;

    public bool startQuest;
    public bool endQuest;
	private PlayerController thePC;

	// Use this for initialization
	void Start () {
        theQM = FindObjectOfType<QuestManager>();
		thePC = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Player" && !theQM.questCompleted[questNumber]){

            if(startQuest && !theQM.quests[questNumber].gameObject.activeSelf){
                theQM.quests[questNumber].gameObject.SetActive(true);
                theQM.quests[questNumber].StartQuest();
            }
	
            if(endQuest && theQM.quests[questNumber].gameObject.activeSelf){
                theQM.quests[questNumber].EndQuest();
            }

			if (transform.parent.GetComponent<villigerMovement> () != null) {
				transform.parent.GetComponent<villigerMovement>().canMove = false;
			}
        }
    }
}﻿