using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour {

	private bool accel = false;
	private float speed = 0;
	public void activate() {
		accel = true;
	}
	public void FixedUpdate() {
		if (accel) {
			speed += 1 / 30f;
			transform.position += new Vector3(0, -speed, 0);
		}

	}
	private void OnTriggerEnter2D(Collider2D collision) {
		if (Global.IsInLayerMask(collision.gameObject.layer, Global.Character)){
			collision.gameObject.GetComponent<CharacterManager>().TakeDamage(100);
		}
	}
}
