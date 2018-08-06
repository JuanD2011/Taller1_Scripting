using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Buy
{
    public delegate void WriteVbles();
    public static event WriteVbles OnWriteCurrency, OnBuyFirstItem;

    public Item(int _coins, int _wood, int _stone)
    {
        coins = _coins;
        wood = _wood;
        stone = _stone;
    }

    protected override void BuyItem()
    {
        if (Singleton.instance.Coins >= coins && Singleton.instance.Wood >= wood && Singleton.instance.Stone >= stone)
        {
            Debug.Log("Compradoo");
            Singleton.instance.Coins += coins *-1;
            Singleton.instance.Wood += wood *-1;
            Singleton.instance.Stone += stone*-1;

            Singleton.instance.FirstItem++;
        }
        else {
            Debug.Log("No posees recursos, vuelve más tarde");
        }
    }

    public void ButtonBuy() {
        BuyItem();
        OnWriteCurrency();
        OnBuyFirstItem();
    }

    protected override void ConsumableItem()
    {
        Singleton.instance.FirstItem--;
        OnBuyFirstItem();
    }

    public void Consuming() {
        ConsumableItem();
    }

    protected override void NonConsumable()
    {
        throw new System.NotImplementedException();
    }
}
