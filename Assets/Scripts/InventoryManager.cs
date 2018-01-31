using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	private bool exitInv = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) {
			openOrCloseInventory ();
		}
	}

	void openOrCloseInventory(){
		if (!exitInv) {
			transform.GetChild (0).gameObject.SetActive (true);
			exitInv = true;
			return;
		}
		if (exitInv) {
			transform.GetChild (0).gameObject.SetActive (false);
			exitInv = false;
			return;
		}
	}
		
}

