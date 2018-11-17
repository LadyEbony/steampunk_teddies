using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager {

    private void Update() {
        if (gunInHand != null) { 
            gunInHand.UpdateProcedure();
            gunInHand.UpdateRotation();
        }
        if (Input.GetMouseButton(0)) {
            gunInHand.Fire();
        }
    }

    public void SwitchGun(Gun nearbyGun)
    {
        Destroy(gunInHand.gameObject);
        gunInHand = nearbyGun;
        gunInHand.transform.SetParent(transform);
    }
}
