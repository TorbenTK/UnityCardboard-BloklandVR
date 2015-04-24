using UnityEngine;
using System.Collections;

public class RainbowColor : MonoBehaviour {

	Color[] colors = new Color[6];
	public bool changeRandomColor;
	
	void Start()
	{
		colors [0] = Color.cyan;
		colors [1] = Color.red;
		colors [2] = Color.green;
		colors [3] = Color.blue;
		colors [4] = Color.yellow;
		colors [5] = Color.magenta;

		//ChangeColor ();
	}

	void ChangeColor()
	{
		renderer.material.color = colors[Random.Range(0, colors.Length)];

		Invoke ("ChangeColor", 0.5f);
	}
}
