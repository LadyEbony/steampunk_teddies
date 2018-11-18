using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {
  public int Damage;

  public float DestroyTime;
  
	// Use this for initialization
	void Start () {
    Destroy(gameObject, DestroyTime);
	}

  private void OnTriggerEnter2D(Collider2D collision) {
    var layer = collision.gameObject.layer;
    if (Global.IsInLayerMask(layer, Global.Enemy)) {
      // TODO: Do damage
      collision.gameObject.GetComponent<CharacterManager>().TakeDamage(Damage);

    } else if (Global.IsInLayerMask(layer, Global.Bullet)) {
      var temp = collision.gameObject.GetComponent<Bullet>();

      temp.transform.rotation = Quaternion.AngleAxis(
        Global.AngleBetweenOnePoint(Vector3.Reflect(
          temp.transform.rotation * Vector3.right,
          transform.rotation * Vector3.right
          )
        ), Vector3.forward);
      temp.SetVelocity();
    }
  }

}
