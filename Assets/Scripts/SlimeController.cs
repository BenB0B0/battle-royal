using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {

	public float moveSpeed;
	private bool inCamView;
	private bool moving;
	private Rigidbody2D myRigidbody;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;
	private Vector3 moveDirection;
	private Animator anim; 
	public float waitToReload;
	private bool reloading; 
	public GameObject thePlayer;
	private int moveUpOrDown;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);

		moveUpOrDown = Random.Range(0,1);
		moveSpeed = Random.Range (1, 5);

	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
				
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;

			if (timeToMoveCounter < 0f) {
				moving = false;
				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}

		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;

			if (timeBetweenMoveCounter < 0f) {
				moving = true;
				//timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);

				if (moveUpOrDown%2 == 0) {
					if (transform.position.y < thePlayer.transform.position.y) {
						moveDirection = new Vector3 ((0f) * moveSpeed, (1f) * moveSpeed, 0f);
					}
					if (transform.position.y > thePlayer.transform.position.y) {
						moveDirection = new Vector3 ((0f) * moveSpeed, (-1f) * moveSpeed, 0f);
					}
				}
				if (moveUpOrDown%2 == 1) {
					if (transform.position.x < thePlayer.transform.position.x) {
						moveDirection = new Vector3 ((1f) * moveSpeed, (0f) * moveSpeed, 0f);
					}
					if (transform.position.x > thePlayer.transform.position.x) {
						moveDirection = new Vector3 ((-1f) * moveSpeed, (0f) * moveSpeed, 0f);
					}
				}
				moveUpOrDown++;

				//moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
			
			}
		}

		anim.SetFloat ("MoveX1", transform.position.x);
		anim.SetFloat ("MoveY1", transform.position.y);
		if (!moving) {
			anim.SetFloat ("MoveX1", 0f);
			anim.SetFloat ("MoveY1", 0f);
		}

		if (reloading) {
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
				thePlayer.SetActive (true);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other){

		/*
		if (other.gameObject.name == "Player") {
			other.gameObject.SetActive (false);
			reloading = true; 
			thePlayer = other.gameObject;
		}
		*/
	}
}
