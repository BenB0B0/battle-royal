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

	public bool dashing = false;
	public int dashCounter = 0;

	private PlayerStats thePlayerStats;
	private WeaponManager weaponManager;

	// Use this for initialization
	void Start () {
		thePlayerStats = FindObjectOfType<PlayerStats> ();
		weaponManager = FindObjectOfType<WeaponManager> ();

		anim = GetComponent<Animator> ();
		myRigidBody = GetComponent<Rigidbody2D> ();

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy(gameObject); 
		}

			
	}
	
	// Update is called once per frame
	void Update () {

		playerMoving = false;

		if (!attacking) {
			// Walking 
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
				myRigidBody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * currentMoveSpeed, myRigidBody.velocity.y);
				playerMoving = true;
				lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			}
			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
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

			// Attacks
			if (Input.GetKeyDown (KeyCode.J) && weaponManager.weaponPickedUp) {
				attackTimeCounter = attackTime;
				attacking = true; 
				myRigidBody.velocity = Vector2.zero;
				if (weaponManager.weaponType == "Sword") {
					anim.SetBool ("Attack", true);
				}
				if (weaponManager.weaponType == "Cross Bow" && weaponManager.arrowAmount > 0) {
					anim.SetBool ("Arrow", true);
					weaponManager.arrowAmount--;
				}
			}
				
			// Sprinting
			if (Input.GetKey (KeyCode.Space) && thePlayerStats.currentStamina > 1) {
				moveSpeed = 7;
			} else {
				moveSpeed = 5;
			}

			// Diagnal Walking
			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && (Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f)) {
				currentMoveSpeed = moveSpeed * diagonalMoveModifier; 
			} else {
				currentMoveSpeed = moveSpeed;
			}

			// Double Tap Dashing 
			if ((Input.GetKeyDown(KeyCode.K)  && thePlayerStats.currentStamina>100)){
				while (dashCounter < 4) {
					float xPos = transform.position.x;
					float yPos = transform.position.y;

					if (lastMove.x == 1) {
						transform.position = new Vector3 (xPos + 1, transform.position.y, 0);
					}
					if (lastMove.x == -1) {
						transform.position = new Vector3 (xPos - 1, transform.position.y, 0);
					}
					if (lastMove.y == 1) {
						transform.position = new Vector3 (transform.position.x, yPos + 1, 0);
					}
					if (lastMove.y == -1) {
						transform.position = new Vector3 (transform.position.x, yPos - 1, 0);
					}
					dashCounter++;
				}
				dashing = true;
				dashCounter = 0;
			}

		}

		if (attackTimeCounter > 0) {
			attackTimeCounter -= Time.deltaTime;
		}
		if (attackTimeCounter <= 0) {
			attacking = false;
			anim.SetBool ("Attack", false);
			anim.SetBool ("Arrow", false);
		}

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}
}

