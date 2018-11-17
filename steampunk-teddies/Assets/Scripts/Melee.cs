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
    if (IsInLayerMask(layer, EnemyLayerMask)) {
      // TODO: Do damage
      collision.gameObject.GetComponent<CharacterManager>().TakeDamage(Damage);

    } else if (IsInLayerMask(layer, BulletLayerMask)) {
      var temp = collision.gameObject.GetComponent<Bullet>();

      var rotation = Vector3.Reflect(temp.transform.rotation.eulerAngles, transform.rotation.eulerAngles); 
      Debug.Log(rotation);

      //temp.transform.rotation = Quaternion.Angle()
    }
  }

  private bool IsInLayerMask(int layer, LayerMask layerMask) {
    return layerMask == (layerMask | (1 << layer));
  }

}
