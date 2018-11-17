using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

  public Rigidbody2D Rigidbody;
  public int Damage;
  public float Speed;

  public float DestroyTime;
  public LayerMask EnemyLayerMask;
  public LayerMask EnvironmentLayerMask;

	// Use this for initialization
	void Start () {
		SetVelocity();
    Destroy(gameObject, DestroyTime);
	}

  void SetVelocity() {
    Rigidbody.velocity = transform.rotation * Vector2.right * Speed;
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    var layer = collision.gameObject.layer;
    if (IsInLayerMask(layer, EnemyLayerMask)) {
      // TODO: Do damage
    } else if (IsInLayerMask(layer, EnvironmentLayerMask)) {
      Destroy(gameObject);
    }

  }

  private bool IsInLayerMask(int layer, LayerMask layerMask) {
    return layerMask == (layerMask | (1 << layer));
  }

}
