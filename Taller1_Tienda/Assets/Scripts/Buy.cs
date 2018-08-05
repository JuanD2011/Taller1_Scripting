using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buy : MonoBehaviour {

    protected int cost;

    protected abstract void BuyItem();
}
