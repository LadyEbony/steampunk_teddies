using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

  public float Speed;

  private void Update() {
    var position = Vector3.MoveTowards(transform.position, PlayerManager.instance.transform.position, Speed * Time.deltaTime);
    position.z = -10;
    transform.position = position;
  }
}
