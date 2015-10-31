using UnityEngine;
using System.Collections;

public class IslandScript : MonoBehaviour {

	public float floatingSpeed = 0.3f;
	public float smoothMove = 0.5f;
	public float islandShift = 5f;
	float direction = 1f;
	float distance = 0.005f;
	
	void Start () {
	
	}

	void Update () {
		Move ();
	}

	// Floating island by Y axis
	void Move() {
		Vector3 movement = new Vector3(0,
		                               floatingSpeed * Time.deltaTime * direction,
		                               0);
		movement += transform.position;
		
		transform.position = Vector3.Lerp(transform.position, 
		                                  movement, 
		                                  smoothMove);

		// Set floating direction up / down
		// if island reached bottom / top point
		if (islandShift - transform.position.y * direction <= distance) {
			direction *= -1;
		}
	}
}
