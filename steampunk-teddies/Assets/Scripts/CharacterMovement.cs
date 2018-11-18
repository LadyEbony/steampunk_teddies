using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

  [Header("Speed")]
  public float speed;
  public float maxSpeed;
  public float jumpForce;
  public float gravity;

  [Header("Jump Detection")]
  public float distanceGround;
  public float distanceSides;
  
  [Header("Component")]
  public Rigidbody2D rb2d;
  public BoxCollider2D bc2d;

  // Update is called once per frame
  void Update () {
    Vector2 velocity = new Vector2(
      Mathf.Clamp((Input.GetAxis("Horizontal") * speed * Time.deltaTime) + rb2d.velocity.x, -maxSpeed, maxSpeed), 
      rb2d.velocity.y - gravity * Time.deltaTime
    );

    var hitG = Physics2D.BoxCast(transform.position, bc2d.size, 0, Vector2.down, distanceGround, Global.Ground);
    var hitL = Physics2D.BoxCast(transform.position, bc2d.size, 0, Vector2.left, distanceSides, Global.Wall);
    var hitR = Physics2D.BoxCast(transform.position, bc2d.size, 0, Vector2.right, distanceSides, Global.Wall);
    if ((hitG.collider != null || hitL.collider != null || hitR.collider != null )&& Input.GetKeyDown(KeyCode.Space)) {
      velocity.y = jumpForce;

      if (hitL.collider != null) {
        velocity.x = maxSpeed;
      } else if (hitR.collider != null) {
        velocity.x = -maxSpeed;
      }
    }

    rb2d.velocity = velocity;
  }
}
