using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {
    public GameObject boss;
    public bool once = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( once) {
            return;
        }
        Instantiate(boss, transform.position, Quaternion.identity);
        once = true;
    }
}
