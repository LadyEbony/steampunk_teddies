using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class Enemy : MonoBehaviour {
	public LayerMask playerLayer;
	public LayerMask environmentLayer;
	public float radius = 20;
	System.Random r = new System.Random();

	public float speed = 2;
	public float minPreferredRange = 5, maxPreferredRange = 10;


	public Gun gun;

	Action order;
	// Use this for initialization
	void Start () {
		order = UpdateIdle;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		order.Invoke ();
	}
		
	void UpdateIdle() {
		Action UpdatePlayerCheck = () => {
			Collider2D playerCollider = Physics2D.OverlapCircle (transform.position, radius, playerLayer);
			if (playerCollider != null) {
				GameObject player = playerCollider.gameObject;

				Action moveOrder = null;
				order = () => {
					//While the player is in range, we try to attack

					Vector2 displacement = player.transform.position - transform.position;
					if (displacement.magnitude < radius) {
						//Check that there's no environment in our way (since it blocks our sight)
						if (Physics2D.Raycast (transform.position, displacement, radius, environmentLayer).collider != null) {

						} else {
							float fireAngle = Mathf.Atan2(displacement.y, displacement.x);

							gun.transform.eulerAngles = new Vector3(0, 0, fireAngle * Mathf.Rad2Deg);

							gun.Fire();

							if(moveOrder != null) {
								moveOrder();
							} else {
								//We don't move to exactly the edges of the range. Instead, we randomly approach it.
								int timeLeft = 30 + r.Next(30);
								if(Mathf.Abs(displacement.x) < minPreferredRange) {
									moveOrder = () => {
										GetComponent<Rigidbody2D> ().velocity = new Vector2 (-Mathf.Sign(displacement.x) * speed, 0);	
										if(--timeLeft < 1)
											moveOrder = null;
									};

								} else if(Mathf.Abs(displacement.x) > maxPreferredRange) {
									moveOrder = () => {
										GetComponent<Rigidbody2D> ().velocity = new Vector2 (Mathf.Sign(displacement.x) * speed, 0);
										if(--timeLeft < 1)
											moveOrder = null;
									};
								}
							}
						}
					} else {
						//Otherwise, we go back to being idle
						order = UpdateIdle;

					}
				};
			}
		};

		int waitLeft = 30 + r.Next(30);
		//Let's wait for a second then move
		order = () => {
			waitLeft--;
			if (waitLeft < 1) {


				int timeLeft = 30 + r.Next (30);
				bool right = r.NextDouble () < 0.5;
				order = () => {
					timeLeft--;
					if (timeLeft > 0) {
						if (right) {
							GetComponent<Rigidbody2D> ().velocity = new Vector2 (2, 0);
						} else {
							GetComponent<Rigidbody2D> ().velocity = new Vector2 (-2, 0);
						}
						UpdatePlayerCheck();
					} else {
						order = UpdateIdle;
					}
				};
			} else {
				UpdatePlayerCheck();
			}
		};

	}
}
