using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float moveSpeed = 15f;
	float topBound = 20f;
	float bottomBound = -20f;

	float smoothMove = 1.5f;
	float strafeSpeed = 13f;
	float distance = 0.005f;

	void Start () {
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
}
