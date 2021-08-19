using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviorforBomb : MonoBehaviour
{
	// target impact on game
	public int scoreAmount = 0;
	public float timeAmount = 0.0f;

	// explosion when hit?
	public GameObject explosionPrefab;

	// when collided with another gameObject
	public void Destroy()
	{
		// exit if there is a game manager and the game is over
		if (GameManager.gm)
		{
			if (GameManager.gm.gameIsOver)
				return;
		}

	// only do stuff if hit by a projectile
		if (explosionPrefab)
		{
			// Instantiate an explosion effect at the gameObjects position and rotation
			Instantiate(explosionPrefab, transform.position, transform.rotation);
		}

		// if game manager exists, make adjustments based on target properties
		if (GameManager.gm)
		{
			GameManager.gm.targetHit(scoreAmount, timeAmount);
		}

		// destroy self
		Destroy(gameObject);

	}
}
