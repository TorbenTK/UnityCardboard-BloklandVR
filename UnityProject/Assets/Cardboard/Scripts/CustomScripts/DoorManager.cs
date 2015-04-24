using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

	// Variables
	private Vector3 pos;
	public bool isOpen = false;
	public bool invertDirection = false;
	public float distance;
	public float time;

	// Initialize
	void Start() {

		if (invertDirection) {
			distance = distance - (distance*2);
		}
		pos = transform.localPosition;
	}

	void MoveDirection() {

		if (!isOpen) {
			transform.position = new Vector3 (pos.x, pos.y + distance, pos.z);
			//transform.position += Vector3.forward * Time.deltaTime;

			isOpen = true;
		} else {
			transform.position = new Vector3(pos.x, pos.y - distance, pos.z);
			isOpen = false;
		}

		pos = transform.localPosition;
	}

	void Update() {
		GetComponent<Renderer>().material.color = isOpen ? Color.cyan : Color.blue;
	}
	
}