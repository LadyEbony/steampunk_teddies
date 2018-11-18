using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
  public int hp;
  private int currentHealth;
  public Gun gunInHand;
	
  public Transform hand;

	void Start () {
    StartProcedure();
	}

  protected virtual void StartProcedure() {
    currentHealth = hp;
    gunInHand.equipped = true;
  }

  public void TakeDamage(int damage) {
    currentHealth -= damage;
    if (currentHealth <= 0)
    {
      Destroy(gameObject);
    }
  }
	
}
