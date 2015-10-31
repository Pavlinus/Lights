using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float heightFromPlayer = 10f;
	public float distanceFromPlayer = 7f;
	float smoothMove = 0.25f;
	Transform player;
	Vector3 camMovement;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {
		Vector3 sidePosition = new Vector3 (distanceFromPlayer, heightFromPlayer, 0f);

		camMovement = player.transform.position + sidePosition;
		transform.position = Vector3.Lerp (transform.position, camMovement, smoothMove);
	}
}
