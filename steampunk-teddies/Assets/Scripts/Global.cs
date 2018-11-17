using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global {
  public static bool IsInLayerMask(int layer, LayerMask layerMask) {
    return layerMask == (layerMask | (1 << layer));
  }

  public static float AngleBetweenTwoPoints(Vector2 a, Vector2 b) {
    return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
  }

  public static float AngleBetweenOnePoint(Vector2 a) {
    return Mathf.Atan2(a.y, a.x) * Mathf.Rad2Deg;
  }
}
