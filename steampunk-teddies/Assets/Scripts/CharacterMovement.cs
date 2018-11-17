using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float speed;
    public float distance;
    public float jumpForce;
    public float wallForce;
    public bool isFacingRight;
    public LayerMask environmentLR;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    void Flip() //Flips character
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontally = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontally, 0.0f) * speed;

        movement.y = rb2d.velocity.y;

        RaycastHit2D hit1 = Physics2D.Raycast(transform.position, Vector2.down, distance, environmentLR);

        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right, distance, environmentLR);

        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, Vector2.left, distance, environmentLR);

        //Flips character with movement
        if (Input.GetKeyDown("right") && isFacingRight)
        {
            Flip();
            isFacingRight = false;
        }
        if (Input.GetKeyDown("left") && !isFacingRight)
        {
            Flip();
            isFacingRight = true;
        }

        //Jump
        if (hit1.collider != null && Input.GetKeyDown("space"))
        {
            movement.y = jumpForce;
        }



        //Wall Jump
        if ((hit2.collider != null || hit3.collider != null) && Input.GetKeyDown("space"))
        {
            movement.y = jumpForce;
            if (hit2.collider != null && isFacingRight)
            {
                //movement.x += -wallForce;
                Flip();
                isFacingRight = false;
                
            }
            if (hit3.collider != null && !isFacingRight)
            {
                //movement.x += wallForce;
                Flip();
                isFacingRight = true;
            }
        }

        rb2d.velocity = movement;
    }
}
