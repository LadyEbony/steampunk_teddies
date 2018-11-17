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
    public LayerMask playerLayerMask;

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
    if (Global.IsInLayerMask(layer, EnemyLayerMask)) {
      // TODO: Do damage
      collision.gameObject.GetComponent<CharacterManager>().TakeDamage(Damage);

    } else if (Global.IsInLayerMask(layer, EnvironmentLayerMask)) {
      Destroy(gameObject);
    }
  }

}
