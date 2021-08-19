using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBombBehavior : MonoBehaviour
{
	// explosion when hit?
	public GameObject explosionPrefab;

	public float radius = 10.0f;
	bool hasExploaded = false;

    // Update is called once per frame
    void OnCollisionEnter(Collision newCollision)
	{
		// exit if there is a game manager and the game is over
		if (GameManager.gm)
		{
			if (GameManager.gm.gameIsOver)
				return;
		}

		// only do stuff if hit by a projectile
		if (newCollision.gameObject.tag == "Projectile")
		{
			if (explosionPrefab && !hasExploaded)
			{
				// Instantiate an explosion effect at the gameObjects position and rotation
				Instantiate(explosionPrefab, transform.position, transform.rotation);
				hasExploaded = true;
			}

			// destroy the projectile
			Destroy(newCollision.gameObject);

			Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

			foreach(Collider nearbyObject in colliders)
            {
				TargetBehaviorforBomb ds = nearbyObject.GetComponent<TargetBehaviorforBomb>();
				if (ds != null)
                {
					ds.Destroy();
                }
            }
			// destroy the projectile
			Destroy(newCollision.gameObject);
			// destroy self
			Destroy(gameObject);
		}

	}
}
