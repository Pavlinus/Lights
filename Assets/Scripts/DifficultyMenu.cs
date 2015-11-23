using UnityEngine;
using System.Collections;

public class DifficultyMenu : MonoBehaviour {

	public void EasyButtonPressed() {
		GameManager.difficulty = Difficulty.Level.EASY;
		GameManager.difficultyScore = 70;
		Application.LoadLevel (1);
	}
	
	public void HarderButtonPressed() {
		GameManager.difficulty = Difficulty.Level.HARDER;
		GameManager.difficultyScore = 30;
		Application.LoadLevel (1);
	}
	
	public void OMGButtonPressed() {
		GameManager.difficulty = Difficulty.Level.OMG;
		GameManager.difficultyScore = 20;
		Application.LoadLevel (1);
	}
}
