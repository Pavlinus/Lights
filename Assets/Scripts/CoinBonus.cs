using UnityEngine;
using System.Collections;

public class CoinBonus : MonoBehaviour {

	public ParticleSystem collisionParticles;
	public ParticleSystem idleParticles;
	public GameObject parent;
	public static int score = 10;
	float playbackSpeed = 5f;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag.Equals("Player")) {
			PlayCollisionParticles();
			
			GameManager.score += score;
		}
	}

	void PlayCollisionParticles() {
		if (collisionParticles == null)
			return;
		
		/*ParticleSystem clone = Instantiate (collisionParticles, 
		                                    transform.position, 
		                                    Quaternion.identity) as ParticleSystem;
		
		if(!clone.isPlaying)
			clone.Play ();
		
		Destroy (clone.gameObject, 2f);*/
		
		if (idleParticles.isPlaying)
			idleParticles.Stop ();
		idleParticles.playbackSpeed = playbackSpeed;

		Destroy (parent.gameObject, 2f);
	}
}
