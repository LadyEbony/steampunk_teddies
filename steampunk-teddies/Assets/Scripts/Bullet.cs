using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

  public Rigidbody2D Rigidbody;
  public int Damage;
  public float Speed;
  public float Dropoff;

  public bool friendly;

  public float DestroyTime;

	// Use this for initialization
	void Start () {
		SetVelocity();
    Destroy(gameObject, DestroyTime);
	}

    private void Update()
    {
        var temp = Rigidbody.velocity;
        temp.y -= Dropoff * Time.deltaTime;
        Rigidbody.velocity = temp;
    }

    public void SetVelocity() {
    Rigidbody.velocity = transform.rotation * Vector2.right * Speed;
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    var layer = collision.gameObject.layer;
    if ((Global.IsInLayerMask(layer, Global.Player) && !friendly) || (Global.IsInLayerMask(layer, Global.Enemy) && friendly)) {
      collision.gameObject.GetComponent<CharacterManager>().TakeDamage(Damage);
      Destroy(gameObject);
    } else if (Global.IsInLayerMask(layer, Global.Environment)) {
      Destroy(gameObject);
    }
  }

}
