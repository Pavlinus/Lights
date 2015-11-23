using UnityEngine;
using System.Collections;

public class ItemsSpawner : MonoBehaviour {

	public GameObject[] islandObjectsArr;
	public GameObject[] coinObjectsArr;
	public GameObject nextLevelObject;

	// Spawn corridor vertical
	float topBound = 10f;
	float bottomBound = -10f;

	// Spawn corridor horizontal
	float startSpawnBound = 10f;
	float endSpawnBound = 20f;

	float coinIslandDistance = 50f;
	int maxCoinsPerSpawn = 5;
	float coinsOffset = 10f;

	// Last spawned item position on Z axis
	float zLastSpawn = 0f;

	// X value (the player object uses such an offset)
	float xOffset = 4f;

	// 30f - radius of the `nextLevel` spot
	float nextLevelSpotOffset = 30f + 25f;

	// Arrays of items locations
	Vector3[] islandsSpawn;
	Vector3[] coinsSpawn;
	Vector3 nextLevelSpawn;

	void Start() {
		zLastSpawn = nextLevelSpotOffset * 2;
	}

	// Generates an array of random spawn points
	public void InitSpawnPoints(int points) {
		islandsSpawn = new Vector3[points];
		coinsSpawn = new Vector3[points * maxCoinsPerSpawn];

		// Coins array index
		int cIndex = 0;

		// Islands spawn points
		for (int iIndex = 0; iIndex < islandsSpawn.Length; iIndex++) {
			islandsSpawn[iIndex] = IslandSpawnPoint();

			GameManager.nextLevelScore += IslandBonus.score;

			// Randomize number of coins between islands
			int randNum = Random.Range(0, maxCoinsPerSpawn - 2);

			// Coins spawn points
			for(int count = 0; count < maxCoinsPerSpawn - randNum; count++) {
				coinsSpawn[cIndex] = CoinSpawnPoint(islandsSpawn[iIndex], count);
				cIndex += 1;

				GameManager.nextLevelScore += CoinBonus.score;
			}
		}

		GameManager.nextLevelScore -= GameManager.difficultyScore;

		// `Next level spot` position
		nextLevelSpawn = new Vector3 (xOffset, 0f, zLastSpawn + nextLevelSpotOffset);
		zLastSpawn = nextLevelSpawn.z + nextLevelSpotOffset;
	}

	// Generates random spawn points for islands
	Vector3 IslandSpawnPoint() {
		// Y axis random value
		float ySpawn = Random.Range(bottomBound, topBound);
		// Distance between last and next spawn by Z axis
		float zSpawnDist = Random.Range (startSpawnBound, endSpawnBound);

		zLastSpawn += zSpawnDist;

		return new Vector3(0f, ySpawn, zLastSpawn);
	}

	// Generates random spawn points for coins
	Vector3 CoinSpawnPoint(Vector3 islandSpawn, int coinNumber) {
		float randY = Random.Range(-3, 3);

		// Z position of current coin
		float nextZ = coinIslandDistance + coinsOffset * coinNumber;

		Vector3 spawnPoint = islandSpawn + new Vector3 (xOffset, randY, nextZ);

		// Coin Z axis position
		zLastSpawn = spawnPoint.z;

		return spawnPoint;
	}

	// Instantiates game objects at random locations
	public void InstantiateItems() {

		// Instantiate coins
		foreach (Vector3 spawn in coinsSpawn) {
			if(!spawn.Equals(new Vector3(0f, 0f, 0f))) {
				Instantiate(coinObjectsArr[0], spawn, Quaternion.identity);
			}
		}

		// Instantiate islands
		foreach (Vector3 spawn in islandsSpawn) {
			Instantiate(islandObjectsArr[0], spawn, Quaternion.identity);
		}

		// Instantiate next level spot
		Instantiate(nextLevelObject, nextLevelSpawn, Quaternion.identity);
	}
}
