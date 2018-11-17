using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {
  public int Damage;

  public float DestroyTime;
  public LayerMask EnemyLayerMask;
  public LayerMask BulletLayerMask;

	// Use this for initialization
	void Start () {
    Destroy(gameObject, DestroyTime);
	}

  private void OnTriggerEnter2D(Collider2D collision) {
    var layer = collision.gameObject.layer;
    if (Global.IsInLayerMask(layer, EnemyLayerMask)) {
      // TODO: Do damage
      collision.gameObject.GetComponent<CharacterManager>().TakeDamage(Damage);

    } else if (Global.IsInLayerMask(layer, BulletLayerMask)) {
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
