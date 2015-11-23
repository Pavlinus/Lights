using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int score;
	public static int level;
	public static Difficulty.Level difficulty;
	public static int difficultyScore;
	public static int nextLevelScore;

	void Start () {
		score = 0;
		nextLevelScore = 0;
		level = 0;
	}
}
