using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	UIManager uiManager;
	ItemsSpawner itemsSpawner;
	SphereCollider sCollider;

	float speedStep = 2f;

	void Start () {
		sCollider = GetComponent<SphereCollider> ();

		uiManager = GameObject.FindGameObjectWithTag ("UIManager")
			.GetComponent<UIManager>();

		itemsSpawner = GameObject.FindGameObjectWithTag ("GameManager")
			.GetComponent<ItemsSpawner> ();
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag ("Player")) {

			// If current score is lower than needed for the next level
			// then game over
			if(GameManager.score < GameManager.nextLevelScore) {
				ParticleSystem ps = collider.gameObject.GetComponentInChildren<ParticleSystem>();

				if(ps.isPlaying) {
					ps.Stop();
					ps.playbackSpeed = 4f;
				}

				uiManager.ShowGameOverMenu();

				return;
			}

			// Displays level text area for few seconds
			uiManager.ShowLevel();

			sCollider.enabled = false;
			GameManager.level += 1;

			// Increase player's speed
			collider.gameObject.GetComponent<PlayerMovement>().SpeedUp(speedStep);

			// Instantiate random number of items at random positions
			int itemsToSpawn = Random.Range(4, 8);
			itemsSpawner.InitSpawnPoints(itemsToSpawn);
			itemsSpawner.InstantiateItems();
		}
	}
}
