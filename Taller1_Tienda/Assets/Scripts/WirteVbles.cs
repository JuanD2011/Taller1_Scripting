using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WirteVbles : MonoBehaviour {

    [SerializeField] Text coinsText;

	void Start () {
        coinsText.text = Singleton.instance.Coins.ToString("0");
        Item.OnWriteCoins += WriteCoins;
    }

    private void WriteCoins() {
        coinsText.text = Singleton.instance.Coins.ToString("0");
    }
}
