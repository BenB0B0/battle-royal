using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petMovement : MonoBehaviour {

	public float moveSpeed;
	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;

	private Rigidbody2D myRigidBody;

	public bool isWalking;

	public float walkTime;
	public float waitTime; 
	private float walkCounter;
	private float waitCounter;

	private int WalkDirection;

	public Collider2D walkZone;
	private bool hasWalkZone;
	private Animator anim; 

	public bool canMove;
	private DialogueManager theDM;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		theDM = FindObjectOfType<DialogueManager> ();
		anim = GetComponent<Animator> ();
		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDirection ();

		if (walkZone != null) {
			minWalkPoint = walkZone.bounds.min;
			maxWalkPoint = walkZone.bounds.max;
			hasWalkZone = true;
		}

		canMove = true;
	}

	// Update is called once per frame
	void Update () {

		if (!theDM.dialogActive) {
			canMove = true;
		}

		if (!canMove) {
			myRigidBody.velocity = Vector2.zero;
			return;
		}

		if (isWalking) {
			walkCounter -= Time.deltaTime;

			switch (WalkDirection) {
			case 0://up
				myRigidBody.velocity = new Vector2 (0, moveSpeed);
				anim.SetBool ("petUp", true);
				anim.SetBool ("petRight", false);
				anim.SetBool ("petDown", false);
				anim.SetBool ("petLeft", false);
				if (hasWalkZone && transform.position.y > maxWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 1: //right
				myRigidBody.velocity = new Vector2 (moveSpeed, 0);
				anim.SetBool ("petRight", true);
				anim.SetBool ("petUp", false);
				anim.SetBool ("petDown", false);
				anim.SetBool ("petLeft", false);
				if (hasWalkZone && transform.position.x > maxWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 2: //down
				myRigidBody.velocity = new Vector2 (0, -moveSpeed);
				anim.SetBool ("petDown", true);
				anim.SetBool ("petRight", false);
				anim.SetBool ("petUp", false);
				anim.SetBool ("petLeft", false);
				if (hasWalkZone && transform.position.y < minWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 3: //left
				myRigidBody.velocity = new Vector2 (-moveSpeed, 0);
				anim.SetBool ("petLeft", true);
				anim.SetBool ("petRight", false);
				anim.SetBool ("petDown", false);
				anim.SetBool ("petUp", false);
				if (hasWalkZone && transform.position.x < minWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			}

			if (walkCounter < 0) {
				isWalking = false;
				waitCounter = waitTime;
			}


		} else {
			waitCounter -= Time.deltaTime;

			myRigidBody.velocity = Vector2.zero;

			if (waitCounter < 0) {
				ChooseDirection ();
			}
		}
	}

	public void ChooseDirection(){
		WalkDirection = Random.Range (0, 4);
		isWalking = true;
		walkCounter = walkTime;
	}
}