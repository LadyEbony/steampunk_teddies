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
		Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
		if (playerCollider != null) {
			GameObject player = playerCollider.gameObject;

			order = () => {
				//While the player is in range, we try to attack
				if ((player.transform.position - transform.position).magnitude < radius) {
					//Check that there's no environment in our way (since it blocks our sight)
					if (Physics2D.Raycast (transform.position, player.transform.position - transform.position, radius, environmentLayer).collider != null) {
						
					}
				} else {
					//Otherwise, we go back to being idle
					order = UpdateIdle;
				}
			};
		} else {
			int timeLeft = 30 + r.Next(90);
			//Let's wait for a second
			if (r.NextDouble() < 0.5) {
				order = () => {
					timeLeft--;
					if (timeLeft < 1) {
						order = UpdateIdle;
					}
				};
			} else {
				bool right = r.NextDouble () < 0.5;
				order = () => {
					timeLeft--;
					if(timeLeft > 0) {
						if(right) {

						}
					} else {
						order = UpdateIdle;
					}
				};
			}
		}
	}
}
