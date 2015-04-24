using UnityEngine;
using System.Collections;

public class PartyManager : MonoBehaviour {


	// Possibly the best manager of this entire project. Hands down!
	void Start() {}

	public void LetThePartyCommence(){
		RainbowColor[] rbc = FindObjectsOfType(typeof(RainbowColor)) as RainbowColor[];
		foreach (RainbowColor r in rbc) {
			r.StartCoroutine("ChangeColor");
		}
	}
	

}
