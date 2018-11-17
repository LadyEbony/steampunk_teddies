using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {

  private void Update() {
    transform.rotation = Quaternion.AngleAxis(
      Global.AngleBetweenTwoPoints(
        Camera.main.ScreenToWorldPoint(Input.mousePosition),  
        transform.position
      ), Vector3.forward
    );
  }

}
