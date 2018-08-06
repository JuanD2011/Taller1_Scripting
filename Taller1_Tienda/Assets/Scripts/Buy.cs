using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buy : MonoBehaviour{
    [SerializeField] protected Type mType;

    /*public int Coins { get { return coins; } set { coins = value; } }
    public int Wood { get { return wood; } set { wood = value; } }
    public int Stone { get { return stone; } set { stone = value; } }*/

    protected int coins, wood, stone;
    protected abstract void BuyItem();
    protected abstract void ConsumableItem();
    protected abstract void NonConsumable();
}
