using UnityEngine;
using System.Collections;

public class ToggleLightColor : MonoBehaviour {

	// Variables
	public bool success;
	public Color color;

	void Awake () {
		color = Color.red;
	}

	void Update () {
		GetComponent<Light> ().color = color;
	}

	public void switchColor()
	{
		if (success) {
			color = Color.red;
			success = false;
		} else {
			color = Color.green;
			success = true;
		}
	}
}
