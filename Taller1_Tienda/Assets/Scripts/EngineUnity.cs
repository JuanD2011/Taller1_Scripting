using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineUnity : MonoBehaviour {

    [SerializeField] Text currencyUno, currencyDos, currencyTres, firstItem;
    [SerializeField] Text compraSatisfactoriaTxt, compraInsatisfactoriaTxt, yaExisteEsteItem;
    [SerializeField] Text itemTxt;
    [SerializeField] AudioSource audioTienda;
    [SerializeField] AudioClip[] audioClips;

    Item item;

	void Start () {

        Shop.OnSatisfactoria += CompraTxtSatisfactoria;
        Shop.OnInsatisfactoria += CompraTxtInsatisfactoria;
        Shop.OnExisteNonConsumable += YaExisteNonConsumable;
       // Inventario.OnConsumirItem += ConsumirItem;

        WriteCurrency();
    }

    private void WriteCurrency() {
        currencyUno.text = Inventario._Inventario.Billetera[TypeCurrency.firstCurrency].ToString("0");
        currencyDos.text = Inventario._Inventario.Billetera[TypeCurrency.secondCurrency].ToString("0");
        currencyTres.text = Inventario._Inventario.Billetera[TypeCurrency.thirdCurrency].ToString("0");
    }

    /*private void WriteFirstItem() {
        firstItem.text = Inventario.instance.FirstItem.ToString("0");
        firstItemI.text = Inventario.instance.FirstItem.ToString("0");
    }*/

    public void CompraTxtSatisfactoria() {
        StartCoroutine(TxtCompra());
        WriteCurrency();
    }

    IEnumerator TxtCompra() {
        compraSatisfactoriaTxt.text = "Compra hecha";
        yield return new WaitForSeconds(0.5f);
        compraSatisfactoriaTxt.text = " ";
    }

    public void CompraTxtInsatisfactoria() {
        StartCoroutine(TxtInsatisfactoria());
        WriteCurrency();
    }

    IEnumerator TxtInsatisfactoria() {
        compraInsatisfactoriaTxt.text = "No tienes disponibilidad monetaria, vuelve a intentarlo más tarde";
        yield return new WaitForSeconds(0.5f);
        compraInsatisfactoriaTxt.text = " ";
    }

    public void YaExisteNonConsumable() {
        yaExisteEsteItem.text = "Ya posees este ítem";
    }


    /// <summary>
    /// Dudoso
    /// </summary>
    /// <param name="_item"></param>
    /*public void ConsumirItem(Item _item) {
        item = _item;

        switch (item.Id) {
            case 0:
                itemTxt.text = "";
                break;
            default:
                break;
        }

    }*/

    public void BtnUno() {
        GameController._GameController.mShop.Comprar(1);
        itemTxt.text = Inventario._Inventario.PInventario[1].ToString();
    }
}
