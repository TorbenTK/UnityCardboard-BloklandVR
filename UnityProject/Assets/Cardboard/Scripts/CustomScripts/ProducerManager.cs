using UnityEngine;
using System.Collections;

public class ProducerManager : MonoBehaviour {

	// Variables
	public Rigidbody _object;
	public bool initiallyOff = true;
	public bool infiniteProduction = false;
	public bool stopProduction = false; // This will permanently stop the producer
	public float resetTime;

	// Initialize the producer
	void Start() {
		if (!initiallyOff) {
			SpawnObject ();
		}
	}

	void Update() {
		if (stopProduction) {

		}
	}

	void SpawnObject() {
		// It is encapsulated in this boolean because you cannot have
		// both an infinite production and a stopped production at the
		// same time.
		if (!stopProduction) {
			Rigidbody clone;
			clone = Instantiate(_object, transform.position, transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.forward * 10);

			if (infiniteProduction) {
				Invoke ("SpawnObject", resetTime);
			}
		}
	}
}