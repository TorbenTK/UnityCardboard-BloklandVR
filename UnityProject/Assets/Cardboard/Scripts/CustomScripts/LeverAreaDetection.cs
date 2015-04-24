using UnityEngine;
using System.Collections;

public class LeverAreaDetection : MonoBehaviour {

	// Variables
	public bool isInArea = false;

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player")
		{
			isInArea = true;
		}

	}

	void OnTriggerExit (Collider col) {
		isInArea = false;
	}
}
