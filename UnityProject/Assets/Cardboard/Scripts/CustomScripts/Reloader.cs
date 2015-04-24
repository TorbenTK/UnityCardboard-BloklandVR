using UnityEngine;
using System.Collections;

public class Reloader : MonoBehaviour {

	public void ResetNow()
	{
		Application.LoadLevel ("Level1");
	}
}
