using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

  public PlayerManager Player { get {return PlayerManager.instance; }}	

  public Text Health;
  public Text GunName;
  public Text GunAmmo;

	// Update is called once per frame
	void Update () {
		Health.text = Player.currentHealth > 0 ? Player.currentHealth.ToString() : "DEAD";

    if (Player.gunInHand == null) {
      GunName.text = "FISTS";
      GunAmmo.text = "0/0";
    } else {
      GunName.text = Player.gunInHand.Name;
      GunAmmo.text = string.Format("{0}/{1}", Player.gunInHand.MagazineCurrent, Player.gunInHand.MagazineSize);
    }
	}
}
