using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour {

	Text levelText;

	public enum Level {
		EASY,
		HARDER,
		OMG
	}

	string LevelToString(Level level) {
		string stringLevel = "";

		switch (level) {
		case Level.EASY:
			stringLevel = "Easy";
			break;

		case Level.HARDER:
			stringLevel = "Harder";
			break;

		case Level.OMG:
			stringLevel = "OMG";
			break;
		}

		return stringLevel;
	}
}
