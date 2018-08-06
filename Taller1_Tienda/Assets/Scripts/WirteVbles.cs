using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WirteVbles : MonoBehaviour {

    [SerializeField] Text coinsText, woodText, stoneText, firstItem;
    [SerializeField] Text firstItemI;

	void Start () {
        coinsText.text = Singleton.instance.Coins.ToString("0");
        woodText.text = Singleton.instance.Wood.ToString("0");
        stoneText.text = Singleton.instance.Stone.ToString("0");
        Item.OnWriteCurrency += WriteCurrency;
        Item.OnBuyFirstItem += WriteFirstItem;
        ShopControl.OnPlusMats += WriteCurrency;
    }

    private void WriteCurrency() {
        coinsText.text = Singleton.instance.Coins.ToString("0");
        woodText.text = Singleton.instance.Wood.ToString("0");
        stoneText.text = Singleton.instance.Stone.ToString("0");
    }

    private void WriteFirstItem() {
        firstItem.text = Singleton.instance.FirstItem.ToString("0");
        firstItemI.text = Singleton.instance.FirstItem.ToString("0");
    }
}
