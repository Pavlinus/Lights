using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text level;
	public Text score;
	public Text nextLevelText;
	public Image menuBackground;

	// Game over menu elements
	public Text gameOverText;
	public Text resultLevelText;
	public Button tryAgainBtn;
	public Button mainMenuBtn;

	//Pause menu elements
	public Button resumeBtn;
	public Button restartBtn;
	public Button mainMenuBtn_2;

	// Help menu elements
	public Text helpText_1;
	public Text helpText_2;
	public Button wButtonHelp;
	public Button sButtonHelp;

	// Help buttons components
	// need to hide them during the game
	Text wButtonText;
	Text sButtonText;
	Image wButtonImg;
	Image sButtonImg;

	bool isPaused;

	float alphaStep = 0.05f;

	void Start() {
		wButtonText = wButtonHelp.GetComponentInChildren<Text> ();
		sButtonText = sButtonHelp.GetComponentInChildren<Text> ();
		wButtonImg = wButtonHelp.GetComponentInChildren<Image> ();
		sButtonImg = sButtonHelp.GetComponentInChildren<Image> ();

		SetGameOverComponentsState (false);
		SetPauseMenuComponentsState (false);

		// Transparent color for level text area
		level.color = new Color(level.color.r, 
		                        level.color.g,
		                        level.color.b,
		                        0f);
		Time.timeScale = 1f;
		isPaused = false;

		StartCoroutine (HelpMessageController());
	}
	
	void Update () {
		level.text = "Level " + GameManager.level;
		score.text = "Score: " + GameManager.score;
		nextLevelText.text = "Next level score: " + GameManager.nextLevelScore;

		if (Input.GetButtonDown("Pause")) {
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
		menuBackground.enabled = state;
		resumeBtn.enabled = state;
		restartBtn.enabled = state;
		mainMenuBtn_2.enabled = state;

		resumeBtn.GetComponentInChildren<Text> ().enabled = state;
		restartBtn.GetComponentInChildren<Text> ().enabled = state;
		mainMenuBtn_2.GetComponentInChildren<Text> ().enabled = state;
	}

	// Hides help menu
	IEnumerator HelpMessageController() {
		yield return new WaitForSeconds (3f);

		do {
			helpText_1.color = DecreaseAlpha(helpText_1.color);
			helpText_2.color = DecreaseAlpha(helpText_2.color);
			wButtonImg.color = DecreaseAlpha(wButtonImg.color);
			sButtonImg.color = DecreaseAlpha(sButtonImg.color);
			wButtonText.color = DecreaseAlpha(wButtonText.color);
			sButtonText.color = DecreaseAlpha(sButtonText.color);

			yield return new WaitForSeconds(0.1f);

		} while(helpText_1.color.a > 0);
	}

	// Decreases alpha channel's value
	Color DecreaseAlpha(Color component) {
		return new Color (component.r,
		                  component.g,
		                  component.b,
		                  component.a - alphaStep);
	}
}
