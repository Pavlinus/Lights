using UnityEngine;
using System.Collections;

public class SpeedBonus : MonoBehaviour {
	
	public float speed = 10f;
	public float bonusTime = 3f;
	public int score = 15;

	Bonus.Type type = Bonus.Type.SPEED;

	public Bonus.Type getBonusType () {
		return type;
	}

	public float getSpeed() {
		return speed;
	}

	public float getBonusTime() {
		return bonusTime;
	}

	public int getScore() {
		return score;
	}
}
