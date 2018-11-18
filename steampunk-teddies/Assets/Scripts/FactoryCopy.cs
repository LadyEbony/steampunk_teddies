using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryCopy : MonoBehaviour {

  public GameObject FactoryBase;  
  public int FactoryAmount = 20;

  public Sprite[] sprites;

  [ContextMenu("Copy")]
  public void Copy() {
    var amount = transform.childCount;

    while(1 < transform.childCount) {
      DestroyImmediate(transform.GetChild(1).gameObject);
    }

    for (var i = 1; i < FactoryAmount; i++) {
      var temp = Instantiate(FactoryBase, new Vector3(10 * i, 0, 0), Quaternion.identity, transform).GetComponent<SpriteRenderer>();
      temp.sprite = sprites[Random.Range(0, sprites.Length)];

    }
  }
	
}
