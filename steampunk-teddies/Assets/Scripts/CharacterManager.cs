using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
  public int maxhp;
  public int currentHealth;
  public Gun gunInHand;
	
  public Transform hand;

	void Start () {
    StartProcedure();
	}

  protected virtual void StartProcedure() {
    currentHealth = maxhp;
    if (gunInHand != null) { 
      gunInHand.equipped = true;
      gunInHand.friendly = this is PlayerManager ? true : false;
    }
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
