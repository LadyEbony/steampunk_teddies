using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class Enemy : MonoBehaviour {
  public CharacterManager manager;
	public float vision = 20;
  public float bulletCheck = 0.5f;
	System.Random r = new System.Random();

	public float speed = 2;
	public float minPreferredRange = 5, maxPreferredRange = 10;

	public Gun gun { get { return manager.gunInHand; } set { manager.gunInHand = value; } }

	Action order;
	// Use this for initialization
	void Start () {
		order = UpdateIdle;

    gun = GunCache.instance.Get().GetComponent<Gun>();
    gun.equipped = true;
    gun.transform.SetParent(manager.hand);
    gun.transform.localPosition = Vector3.zero;
    gun.transform.localRotation = Quaternion.identity;
	}

  private void Update() {
    gun.UpdateProcedure ();
  }

  // Update is called once per frame
  void FixedUpdate () {
		order.Invoke ();
	}
		
	void UpdateIdle() {
		Action UpdatePlayerCheck = () => {
			Collider2D playerCollider = Physics2D.OverlapCircle (transform.position, vision, Global.Player);
			if (playerCollider != null) {
				GameObject player = playerCollider.gameObject;

				Action moveOrder = null;
				order = () => {
					//While the player is in range, we try to attack

					Vector2 displacement = player.transform.position - transform.position;
					if (displacement.magnitude < vision) {
						
						//Check that there's no environment in our way (since it blocks our sight)
						if (Physics2D.Raycast (transform.position, displacement, bulletCheck, Global.Environment).collider != null) {
							return;
						} else {
							float fireAngle = Mathf.Atan2(displacement.y, displacement.x);

							gun.transform.eulerAngles = new Vector3(0, 0, fireAngle * Mathf.Rad2Deg);

							gun.Fire(true);

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
						order();
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
						order();
					}

				};
				order();
			} else {
				UpdatePlayerCheck();
			}
		};

	}

  private void OnDestroy() {
    gun.transform.SetParent(null, true);
    gun.equipped = false;
  }
}
