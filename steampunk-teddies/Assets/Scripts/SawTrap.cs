using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MonoBehaviour {

	public float spinRate = 30;

	public void FixedUpdate() {
		transform.eulerAngles += new Vector3(0, 0, spinRate / 30);
	}
  private void OnTriggerEnter2D(Collider2D collision) {
    var layer = collision.gameObject.layer;
    if (Global.IsInLayerMask(layer, Global.Character)){
      collision.gameObject.GetComponent<CharacterManager>().TakeDamage(100);
    }
  }

}
