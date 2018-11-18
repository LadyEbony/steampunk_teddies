using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCache : MonoBehaviour {

  public static GunCache instance;

  [SerializeField] private GameObject[] Cache;

  private void Awake() {
    instance = this;
  }

  public GameObject Get() {
    return Instantiate(Cache[Random.Range(0, Cache.Length)]);
  }

}
