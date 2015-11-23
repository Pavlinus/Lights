using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuUI : MonoBehaviour {
	public Text easyText;
	public Text harderText;
	public Text omgText;
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
		easyText.enabled = state;
		harderText.enabled = state;
		omgText.enabled = state;
		diffMenuBackground.enabled = state;
	}
}
