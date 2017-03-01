using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;
	private Animator anim;
	private bool playerMoving;
	public Vector2 lastMove;
	private Rigidbody2D myRigidBody;
	private static bool playerExists;
	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;
	public string startPoint;
	public bool canMove;
	private Vector2 moveInput;
	private SFXManager sfxMan;
	private Arrows currentArrows;
	private WeaponManager activateWeapon;
	private DialogueManager theDM;
	private WeaponPickUp WPU;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRigidBody = GetComponent<Rigidbody2D> ();
		sfxMan = FindObjectOfType<SFXManager> ();
		currentArrows = FindObjectOfType<Arrows> ();
		activateWeapon = FindObjectOfType<WeaponManager> ();
		theDM = FindObjectOfType<DialogueManager> ();
		WPU = FindObjectOfType<WeaponPickUp> ();

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy(gameObject); 
		}

		canMove = true;

		lastMove = new Vector2 (0, -1f);
	}
	
	// Update is called once per frame
	void Update () {

		playerMoving = false;

		if (!canMove) {
			myRigidBody.velocity = Vector2.zero;
			GetComponent<Animator> ().enabled = false;
			return;
		} else {
			GetComponent<Animator> ().enabled = true;
		}

		if (!attacking) {
			/*
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
				//	transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
				myRigidBody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * currentMoveSpeed, myRigidBody.velocity.y);
				playerMoving = true;
				lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			}
			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
				//	transform.Translate (new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, Input.GetAxisRaw ("Vertical") * currentMoveSpeed);
				playerMoving = true;
				lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
			}

			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
				myRigidBody.velocity = new Vector2 (0f, myRigidBody.velocity.y);
			}
			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, 0f);
			}
			*/
			moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

			if (moveInput != Vector2.zero) {
				myRigidBody.velocity = new Vector2 (moveInput.x * moveSpeed, moveInput.y * moveSpeed);
				playerMoving = true;
				lastMove = moveInput;
				anim.SetBool ("SwordPickUp", false);
			} else {
				myRigidBody.velocity = Vector2.zero;
			}

			if (Input.GetKeyDown (KeyCode.J)) {
				attackTimeCounter = attackTime;
				attacking = true; 
				myRigidBody.velocity = Vector2.zero;
				anim.SetBool ("Attack", true);
				sfxMan.playerAttack.Play ();
			}

			if (Input.GetKeyDown (KeyCode.K) && moveInput == Vector2.zero && currentArrows.currentArrowAmount > 0 && theDM.bowPicked) {
				currentArrows.currentArrowAmount--;
				attackTimeCounter = attackTime;
				attacking = true; 
				myRigidBody.velocity = Vector2.zero;
				anim.SetBool ("Attack1", true);
				sfxMan.playerAttack.Play ();

			}
			/*
			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && (Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f)) {
				currentMoveSpeed = moveSpeed * diagonalMoveModifier; 
			} else {
				currentMoveSpeed = moveSpeed;
			}
			*/
		}

		if (attackTimeCounter > 0) {
			attackTimeCounter -= Time.deltaTime;
		}
		if (attackTimeCounter <= 0) {
			attacking = false;
			anim.SetBool ("Attack", false);
			anim.SetBool ("Attack1", false);
		}

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}
}