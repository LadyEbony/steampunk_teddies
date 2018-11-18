using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

  public Rigidbody2D Rigidbody;
  public int Damage;
  public float Speed;

  public bool friendly;

  public float DestroyTime;
  public LayerMask PlayerLayerMask;
  public LayerMask EnemyLayerMask;
  public LayerMask EnvironmentLayerMask;

	// Use this for initialization
	void Start () {
		SetVelocity();
    Destroy(gameObject, DestroyTime);
	}

  public void SetVelocity() {
    Rigidbody.velocity = transform.rotation * Vector2.right * Speed;
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    var layer = collision.gameObject.layer;
    if ((Global.IsInLayerMask(layer, PlayerLayerMask) && !friendly) || (Global.IsInLayerMask(layer, EnemyLayerMask) && friendly)) {
      collision.gameObject.GetComponent<CharacterManager>().TakeDamage(Damage);
      Destroy(gameObject);
    } else if (Global.IsInLayerMask(layer, EnvironmentLayerMask)) {
      Destroy(gameObject);
    }
  }

}
