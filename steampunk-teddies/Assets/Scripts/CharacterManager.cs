using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
    public int hp;
    private int currentHealth;
    public Gun gunInHand;
	// Use this for initialization
	void Start ()
    {
        currentHealth = hp;
	}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
	
}
