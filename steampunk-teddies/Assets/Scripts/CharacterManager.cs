using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
  public int maxhp;
  public int currentHealth;
  public Gun gunInHand;
	
	void Start () {
    StartProcedure();
	}

  protected virtual void StartProcedure() {
    currentHealth = maxhp;
    gunInHand.equipped = true;
  }

  public void TakeDamage(int damage) {
    Debug.LogFormat("Took {0} damage", damage);
    currentHealth -= damage;
    if (currentHealth <= 0)
    {
      Destroy(gameObject);
    }
  }
	
}
