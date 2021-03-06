﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {
  public enum BatState { Standby, meleePause }
  [Header("State")]
  public BatState State = BatState.Standby;
  public float StateDuration = 0.0f;

  [Header("Bat Stats")]
  public int Damage;
  public float Speed;

  [Header("Melee Gameobject")]
  public GameObject Melee;

	void Update () {
		
	}

  public void UpdateProcedure() {
    switch(State) {
      case BatState.Standby:
        break;

      case BatState.meleePause:
        if (StateDuration >= Speed) {
          SwitchState(BatState.Standby, Speed);
        }
        break;
    }
    StateDuration += Time.deltaTime;
  }

  public void Attack() {
    if (State == BatState.Standby) {
      var temp = Instantiate(Melee, transform.position, transform.rotation).GetComponent<Melee>();
      temp.Damage = Damage;

      SwitchState(BatState.meleePause);
    }
  }

  void SwitchState(BatState state) {
    State = state;
    StateDuration = 0.0f;
  }

  void SwitchState(BatState state, float durationDecrease) {
    State = state;
    StateDuration -= durationDecrease;
  }
}
