using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherTrigger2 : MonoBehaviour {
	public Crusher crusher;
	private void OnTriggerEnter2D(Collider2D other) {
		if (Global.IsInLayerMask (other.gameObject.layer, Global.Character)) {
			crusher.activate ();
			gameObject.SetActive (false);
		}
	}

}
