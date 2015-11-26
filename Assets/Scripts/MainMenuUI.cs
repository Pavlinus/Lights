using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuUI : MonoBehaviour {
	public Button easyBtn;
	public Button harderBtn;
	public Button omgBtn;
	public Image diffMenuBackground;

	void Start () {
		SetDifficultyMenuState (false);
	}

	public void ShowDifficultyMenu() {
		SetDifficultyMenuState (true);
	}

	public void CloseDifficultyMenu() {
		SetDifficultyMenuState (false);
	}

	void SetDifficultyMenuState(bool state) {
		easyBtn.enabled = state;
		easyBtn.GetComponentInChildren<Text> ().enabled = state;
		harderBtn.enabled = state;
		harderBtn.GetComponentInChildren<Text> ().enabled = state;
		omgBtn.enabled = state;
		omgBtn.GetComponentInChildren<Text> ().enabled = state;
		diffMenuBackground.enabled = state;
	}
}
