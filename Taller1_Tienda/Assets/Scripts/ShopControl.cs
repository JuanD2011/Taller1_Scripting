using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopControl : MonoBehaviour {
    Item item1;
    Buy mBuy;

    public delegate void Write();
    public static event Write OnPlusMats;

    void Start () {
        item1 = new Item(1,2,3);
        Player.OnFirstItem += Consumable;
    }

    public void Consumable() {
        item1.Consuming();
    }

    public void GivingMats() {
        Singleton.instance.Coins += 10;
        Singleton.instance.Wood += 10;
        Singleton.instance.Stone += 10;
        OnPlusMats();
    }

    public void BuyItem() {
        item1.ButtonBuy();
    }
}
