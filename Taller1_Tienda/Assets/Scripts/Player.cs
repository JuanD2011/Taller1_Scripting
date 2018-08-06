using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public delegate void Consumable();
    public static event Consumable OnFirstItem;

    void Update () {
        if (Singleton.instance.FirstItem > 0) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                OnFirstItem();
            }
        }
	}
}
