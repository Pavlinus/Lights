using UnityEngine;
using System.Collections;

public class IslandBonus : MonoBehaviour {
	
	public ParticleSystem idleParticles;
	public GameObject lightsGroup;
	public GameObject parent;
	public static int score = 100;

	ParticleSystem cloneIdleParticles;
	float particlesPlaybackSpeed = 4f;

	void Start () {

	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag.Equals("Player")) {
			PlayCollisionParticles();
			MuteLights();

			GameManager.score += score;
		}
	}
	
	// controls lights group state
	void MuteLights() {
		Light[] lightsComponents = lightsGroup.GetComponentsInChildren<Light> ();
		
		// enable/disable lights of the object
		foreach (Light light in lightsComponents) {
			light.enabled = true;
		}
	}

	void PlayCollisionParticles() {
		if (idleParticles != null)
			idleParticles.Stop ();
		idleParticles.playbackSpeed = particlesPlaybackSpeed;

		// destroy parent object `flying island`
		Destroy (parent.gameObject, 5f);
	}
}
