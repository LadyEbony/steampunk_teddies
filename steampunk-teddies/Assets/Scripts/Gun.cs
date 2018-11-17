using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
  public enum GunState { Standby, FireratePause, ReloadPause }
  [Header("State")]
  public GunState State = GunState.Standby;
  public float StateDuration = 0.0f;

  [Header("Gun Stats")]
  public int Damage = 1;
  public float Firerate = 0.025f;
  public float Reload = 1.0f;

  public int MagazineSize = 4;
  public int MagazineCurrent = 4;

  [Header("Bullet Gameobject")]
  public GameObject Bullet;
  public Transform BulletTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch(State) {
      case GunState.Standby:
        if (Input.GetMouseButton(0)) {
          Fire();
          MagazineCurrent--;
          if (MagazineCurrent > 0)
            SwitchState(GunState.FireratePause);
          else
            SwitchState(GunState.ReloadPause);
        }
        break;

      case GunState.FireratePause:
        if (StateDuration >= Firerate) {
          SwitchState(GunState.Standby);
        }
        break;

      case GunState.ReloadPause:
        if (StateDuration >= Reload) {
          MagazineCurrent = MagazineSize;
          SwitchState(GunState.Standby);
        }
        break;
    }
    StateDuration += Time.deltaTime;
	}

  void SwitchState(GunState state) {
    State = state;
    StateDuration = 0.0f;
  }

  private void Fire() {
    Instantiate(Bullet, BulletTransform.position, BulletTransform.rotation);
    // TODO: Add bullet damage
  }
}
