using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	float moveSpeed = 20f;
	float topBound = 20f;
	float bottomBound = -20f;
	float smoothMove = 1.5f;
	float strafeSpeed = 13f;
	float distance = 0.005f;

	void Start () {
		SetDifficultyParameters ();
	}

	void Update () {
		Move ();
	}

	void Move() {
		Vector3 movement;
		float strafe = Input.GetAxis ("Vertical");

		// if going up / down
		if (strafe != 0f) {
			movement = new Vector3 (0f, 
			                        strafe * strafeSpeed * Time.deltaTime, 
			                        moveSpeed * Time.deltaTime);
		} else {
			// forward movement
			movement = new Vector3 (0f, 0f, moveSpeed * Time.deltaTime);
		}

		movement += transform.position;

		Vector3 nextPosition = Vector3.Lerp (transform.position, movement, smoothMove);

		// if player object is on bound
		if (topBound - nextPosition.y <= distance || nextPosition.y - bottomBound <= distance) {
			// set forward movement
			movement = new Vector3 (0f, 0f, moveSpeed * Time.deltaTime);
			movement += transform.position;
		}

		transform.position = Vector3.Lerp (transform.position, movement, smoothMove);
	}
	
	public void SpeedUp(float bonusSpeed) {
		moveSpeed += bonusSpeed;
	}

	public void StrafeSpeedUp(float bonusSpeed) {
		strafeSpeed += bonusSpeed;
	}

	// Applying difficulty level to movement parameters
	void SetDifficultyParameters() {
		switch(GameManager.difficulty) {
		case Difficulty.Level.EASY:
			SetDifficultyMovementValues(20f, 15f);
			break;

		case Difficulty.Level.HARDER:
			SetDifficultyMovementValues(25f, 25f);
			break;

		case Difficulty.Level.OMG:
			SetDifficultyMovementValues(30f, 45f);
			break;
		}
	}

	void SetDifficultyMovementValues (float speed, float strafe) {
		moveSpeed = speed;
		strafeSpeed = strafe;
	}
}
