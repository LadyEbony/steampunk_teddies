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

  public int maxhp;
  public int currentHealth;
  public Gun gunInHand;
  public State state;
  public Transform hand;

  protected Animator animator;
  protected Rigidbody2D rb2D;

	void Start () {
    StartProcedure();
    currentHealth = maxhp;
	}

  void Update () {
    
  }

  protected virtual void StartProcedure() {
    animator = GetComponent<Animator>();
    rb2D = GetComponent<Rigidbody2D>();
	  currentHealth = maxhp;
	    if (gunInHand != null) { 
        gunInHand.equipped = true;
      }
	}

  public virtual void TakeDamage(int damage) {
    Debug.LogFormat("Took {0} damage", damage);
    currentHealth -= damage;
    if (currentHealth <= 0)
    {
      Destroy(gameObject);
    }
  }
	
}
