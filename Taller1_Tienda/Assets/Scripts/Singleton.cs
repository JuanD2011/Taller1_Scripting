using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

    public static Singleton instance;

    #region currency
    public int Coins {
        get { return coins; }
        set { coins = value; }
    }
    public int Stone
    {
        get { return stone; }
        set { stone = value; }
    }
    public int Wood
    {
        get { return wood; }
        set { wood = value; }
    }

    private int coins;
    private int wood;
    private int stone;
    #endregion

    public int FirstItem {
        get { return firstItem; }
        set { firstItem = value; }
    }
    private int firstItem;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

}
