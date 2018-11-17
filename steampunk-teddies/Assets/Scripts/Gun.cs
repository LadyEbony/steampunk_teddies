using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
  public enum GunState { Standby, FireratePause, ReloadPause }
  [Header("State")]
  public GunState State = GunState.Standby;
    public bool equipped = false;
  public float StateDuration = 0.0f;

  [Header("Gun Stats")]
  public int Damage = 1;
  public float Firerate = 0.025f;
  public float Reload = 1.0f;
  public float BulletSpeed = 10.0f;

  public int MagazineSize = 4;
  public int MagazineCurrent = 4;

  [Header("Bullet Gameobject")]
  public GameObject Bullet;
  public Transform BulletTransform;
    public LayerMask playerLayerMask;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// REMOVE WHEN CHARACTER CONTROLLER IMPLEMENTATION ADDED
	void Update () {
    UpdateProcedure();
	}

  public void UpdateProcedure() {
    switch(State) {
      case GunState.Standby:
        break;

      case GunState.FireratePause:
        if (StateDuration >= Firerate) {
          SwitchState(GunState.Standby, Firerate);
        }
        break;

      case GunState.ReloadPause:
        if (StateDuration >= Reload) {
          MagazineCurrent = MagazineSize;
          SwitchState(GunState.Standby, -Reload);
        }
        break;
    }
    StateDuration += Time.deltaTime;
  }

  public void Fire() {
    if (State == GunState.Standby) {
      var temp = Instantiate(Bullet, BulletTransform.position, BulletTransform.rotation).GetComponent<Bullet>();
      temp.Damage = Damage;
      temp.Speed = BulletSpeed;

      MagazineCurrent--;
      if (MagazineCurrent > 0)
        SwitchState(GunState.FireratePause);
      else
        SwitchState(GunState.ReloadPause);
    }
  }

  public void UpdateRotation() {
    transform.rotation = Quaternion.AngleAxis(
      AngleBetweenTwoPoints(
        Camera.main.ScreenToWorldPoint(Input.mousePosition),  
        transform.position
      ), Vector3.forward
    );
  }

  void SwitchState(GunState state) {
    State = state;
    StateDuration = 0.0f;
  }

  void SwitchState(GunState state, float durationDecrease) {
    State = state;
    StateDuration -= durationDecrease;
  }

  private float AngleBetweenTwoPoints(Vector2 a, Vector2 b) {
    return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
  }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var layer = collision.gameObject.layer;
        Debug.Log("Hello");
        if (!equipped && IsInLayerMask(layer, playerLayerMask))
        {
            
            Debug.Log("Hellohello");
            if (Input.GetMouseButton(1))
            {

                collision.gameObject.GetComponent<PlayerManager>().SwitchGun(this);
                equipped = true;
                Debug.Log("Hi");
            }
        }
    }

    private bool IsInLayerMask(int layer, LayerMask layerMask)
    {
        return layerMask == (layerMask | (1 << layer));
    }
}
