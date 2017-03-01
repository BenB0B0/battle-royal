using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbersEnemy : MonoBehaviour {

	public float moveSpeed;
	public int damageNumber;
	public Text displayNumber;
	private int currentDamage;
	private HurtPlayer hurtPl;

	// Use this for initialization
	void Start () {
		hurtPl = FindObjectOfType<HurtPlayer> ();
	}

	// Update is called once per frame
	void Update () {
		displayNumber.text = "" + hurtPl.damageToGive;
		transform.position = new Vector3 (transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
	}
}