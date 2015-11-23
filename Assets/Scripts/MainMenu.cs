using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	MainMenuUI mainMenuUI;

	void Start () {
		Time.timeScale = 1f;
		mainMenuUI = GameObject.FindGameObjectWithTag ("MainMenuUI")
			.GetComponent<MainMenuUI> ();
	}

	public void PlayButtonPressed() {
		mainMenuUI.ShowDifficultyMenu ();
	}

	public void QuitButtonPressed() {
		Application.Quit ();
	}
}
