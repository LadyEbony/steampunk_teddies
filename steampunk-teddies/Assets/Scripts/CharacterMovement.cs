using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float speed;
    public float distance;
    public float jumpForce;
    public LayerMask environmentLR;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontally = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontally, 0.0f);
        rb2d.velocity = movement * speed;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance, environmentLR);

        if (hit.collider != null && Input.GetKeyDown("space"))
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime, Space.World);
        }
        
	}
}
