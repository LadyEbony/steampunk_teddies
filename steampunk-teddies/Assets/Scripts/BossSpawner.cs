using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {
    public GameObject boss;
    public GameObject walls;
    public bool once = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( once) {
            return;
        }
        boss.SetActive(true);
        walls.SetActive(true);
        once = true;
        Debug.Log("bitchboy");
        Instantiate(boss, transform.position, Quaternion.identity);
		gameObject.SetActive (false);
    }
}
