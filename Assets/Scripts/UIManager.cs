using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text level;
	public Text score;
	public Image menuBackground;
	public Text gameOverText;
	public Text resultLevelText;
	public Button tryAgainBtn;
	public Button mainMenuBtn;
	public Text nextLevelText;
	public Button resumeBtn;
	public Button restartBtn;
	public Button mainMenuBtn_2;

	bool isPaused;

	float alphaStep = 0.05f;

	void Start() {
		SetGameOverComponentsState (false);

		// Transparent color for level text area
		level.color = new Color(level.color.r, 
		                        level.color.g,
		                        level.color.b,
		                        0f);
		Time.timeScale = 1f;
		isPaused = false;
	}
	
	void Update () {
		level.text = "Level " + GameManager.level;
		score.text = "Score: " + GameManager.score;
		nextLevelText.text = "Next level score: " + GameManager.nextLevelScore;

		if (Input.GetButton("Pause")) {
			if(isPaused) {
				ClosePauseMenu();
			} else {
				ShowPauseMenu();
			}
		}
	}

	public void ShowLevel() {
		StartCoroutine (SwitchLevelTextArea());
	}

	// Show/Hide level text field
	IEnumerator SwitchLevelTextArea() {

		// Fade in
		while(level.color.a <= 1f) {
			level.color = new Color(level.color.r, 
			                        level.color.g,
			                        level.color.b,
			                        level.color.a + alphaStep);

			yield return new WaitForSeconds(0.05f);
		}

		yield return new WaitForSeconds(3f);

		// Fade out
		alphaStep *= -1;

		while(level.color.a >= 0f) {
			level.color = new Color(level.color.r, 
			                        level.color.g,
			                        level.color.b,
			                        level.color.a + alphaStep);

			yield return new WaitForSeconds(0.05f);
		}

		// Fade in
		alphaStep *= -1;
	}

	public void ShowGameOverMenu() {
		StartCoroutine (EnableGameOverComponents());
	}
	
	IEnumerator EnableGameOverComponents() {
		yield return new WaitForSeconds (1f);

		SetGameOverComponentsState (true);

		resultLevelText.text = "You reached " + GameManager.level + " level!";

		yield return new WaitForSeconds (0.5f);

		Time.timeScale = 0f;
	}

	void SetGameOverComponentsState (bool state) {
		menuBackground.enabled = state;
		gameOverText.enabled = state;
		resultLevelText.enabled = state;
		tryAgainBtn.enabled = state;
		mainMenuBtn.enabled = state;

		mainMenuBtn.GetComponentInChildren<Text> ().enabled = state;
		tryAgainBtn.GetComponentInChildren<Text> ().enabled = state;
	}

	public void ShowPauseMenu() {
		SetPauseMenuComponentsState (true);
		Time.timeScale = 0f;
		isPaused = true;
	}

	public void ClosePauseMenu() {
		SetPauseMenuComponentsState (false);
		Time.timeScale = 1f;
		isPaused = false;
	}

	void SetPauseMenuComponentsState(bool state) {
		resumeBtn.enabled = state;
		restartBtn.enabled = state;
		mainMenuBtn_2.enabled = state;

		resumeBtn.GetComponentInChildren<Text> ().enabled = state;
		restartBtn.GetComponentInChildren<Text> ().enabled = state;
		mainMenuBtn_2.GetComponentInChildren<Text> ().enabled = state;
	}
}
