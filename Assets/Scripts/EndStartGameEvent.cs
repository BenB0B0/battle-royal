using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStartGameEvent : MonoBehaviour {

	private Animator anim; 
	private WeaponManager theWM;

	// Use this for initialization
	void Start () {
		var sister = GameObject.Find("sister");
		anim = sister.GetComponent<Animator> ();
		theWM = FindObjectOfType<WeaponManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			anim.SetBool ("Sister_Start", false);
			anim.SetBool ("Sister_Leave", true);
			theWM.thinpickUp ();
		}
	}
}
