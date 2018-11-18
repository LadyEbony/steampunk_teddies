using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class CharacterManager : MonoBehaviour {

  public enum State {
    Idle,
    Run,
    Jump,
    Fall,
    Hurt,
    Dead
  }

  public int hp;
  protected int currentHealth;
  public Gun gunInHand;
  public State state;

  protected Animator animator;
  protected Rigidbody2D rb2D;

	void Start () {
    currentHealth = hp;

    animator = GetComponent<Animator>();
    rb2D = GetComponent<Rigidbody2D>();
	}

  void Update () {
    
  }

  public void TakeDamage(int damage) {
    currentHealth -= damage;
    if (currentHealth <= 0)
    {
      Destroy(gameObject);
    }
  }
	
}
