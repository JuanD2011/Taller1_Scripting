using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Buy
{
    public delegate void WriteVbles();
    public static event WriteVbles OnWriteCoins;

    private void Start()
    {
        Singleton.instance.Coins = 100;
        cost = 20;
    }

    protected override void BuyItem()
    {
        Singleton.instance.Coins += cost *-1;
    }

    public void ButtonBuy() {
        BuyItem();
        OnWriteCoins();
    }
}
