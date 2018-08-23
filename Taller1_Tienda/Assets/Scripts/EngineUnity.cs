using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineUnity : MonoBehaviour {

    [SerializeField] Text currencyUno, currencyDos, currencyTres;//currency
    [SerializeField] Text compras, descarte;
    [SerializeField] Text itemUnoTxt, itemUnoTxtInv;
    [SerializeField] Text itemDosTxt, itemDosTxtInv;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] GameObject canvasShop, canvasInventory;
    [SerializeField] GameObject InitialText;

    void Start () {

        audioClips = Resources.LoadAll<AudioClip>("Sounds");

        Shop.OnSatisfactoria += CompraTxtSatisfactoria;
        Shop.OnInsatisfactoria += CompraTxtInsatisfactoria;
        Shop.OnExisteNonConsumable += YaExisteNonConsumable;
        Inventario.OnDescarteSatisfactorio += TxtDescarteSatisfactorio;
        // Inventario.OnConsumirItem += ConsumirItem;
        canvasShop.SetActive(false);
        canvasInventory.SetActive(false);
        WriteCurrency();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            canvasShop.SetActive(true);
            canvasInventory.SetActive(false);
            InitialText.SetActive(false);
            GetComponent<AudioSource>().clip = audioClips[1];
            GetComponent<AudioSource>().Play();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            canvasInventory.SetActive(true);
            canvasShop.SetActive(false);
            InitialText.SetActive(false);
            GetComponent<AudioSource>().clip = audioClips[1];
            GetComponent<AudioSource>().Play();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvasShop.activeInHierarchy || canvasInventory.activeInHierarchy)
            {
                canvasShop.SetActive(false);
                canvasInventory.SetActive(false);
                InitialText.SetActive(true);
                GetComponent<AudioSource>().clip = audioClips[0];
                GetComponent<AudioSource>().Play();
            }
        }
    }

    private void WriteCurrency() {
        currencyUno.text = Inventario._Inventario.Billetera[TypeCurrency.firstCurrency].ToString("0");
        currencyDos.text = Inventario._Inventario.Billetera[TypeCurrency.secondCurrency].ToString("0");
        currencyTres.text = Inventario._Inventario.Billetera[TypeCurrency.thirdCurrency].ToString("0");
    }

    public void CompraTxtSatisfactoria() {
        StartCoroutine(TxtCompra());//Texto cuando compra satisfactoriamente
        WriteCurrency();//Escribe las currency actuales
        GetComponent<AudioSource>().clip = audioClips[2];
        GetComponent<AudioSource>().Play();
    }

    IEnumerator TxtCompra() {
        compras.text = "Compra hecha";
        yield return new WaitForSeconds(0.5f);
        compras.text = " ";
    }

    public void CompraTxtInsatisfactoria() {
        StartCoroutine(TxtInsatisfactoria());
        WriteCurrency();
        GetComponent<AudioSource>().clip = audioClips[3];
        GetComponent<AudioSource>().Play();
    }

    IEnumerator TxtInsatisfactoria() {
        compras.text = "No tienes disponibilidad monetaria, vuelve a intentarlo más tarde";
        yield return new WaitForSeconds(0.5f);
        compras.text = " ";
    }

    public void YaExisteNonConsumable() {
        StartCoroutine(TxtYaExiste());
        GetComponent<AudioSource>().clip = audioClips[4];
        GetComponent<AudioSource>().Play();
    }

    IEnumerator TxtYaExiste()
    {
        compras.text = "Ya posees este ítem";
        yield return new WaitForSeconds(0.5f);
        compras.text = " ";
    }

    public void TxtDescarteSatisfactorio() {
        StartCoroutine(TxtDescarte());
        GetComponent<AudioSource>().clip = audioClips[3];
        GetComponent<AudioSource>().Play();
    }

    IEnumerator TxtDescarte()
    {
        descarte.text = "Ha sido descartado";
        yield return new WaitForSeconds(0.5f);
        descarte.text = " ";
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
        itemUnoTxt.text = Inventario._Inventario.PInventario[1].ToString();
        itemUnoTxtInv.text = Inventario._Inventario.PInventario[1].ToString();
    }

    public void BtnDos() {
        GameController._GameController.mShop.Comprar(2);
        itemDosTxt.text = Inventario._Inventario.PInventario[2].ToString();
        itemDosTxtInv.text = Inventario._Inventario.PInventario[2].ToString();
    }

    #region modificarCurrency
    public void ModificarCurrencyUno(string _input) {
        int cantidad = int.Parse(_input);
        Inventario._Inventario.Billetera[TypeCurrency.firstCurrency] = cantidad;
        WriteCurrency();
    }

    public void ModificarCurrencyDos(string _input)
    {
        int cantidad = int.Parse(_input);
        Inventario._Inventario.Billetera[TypeCurrency.secondCurrency] = cantidad;
        WriteCurrency();
    }

    public void ModificarCurrencyTres(string _input)
    {
        int cantidad = int.Parse(_input);
        Inventario._Inventario.Billetera[TypeCurrency.thirdCurrency] = cantidad;
        WriteCurrency();
    }
    #endregion

    public void DescartarItem(string _descartar) {
        int cantidad = int.Parse(_descartar);
        Inventario._Inventario.DescartarItem(1 , cantidad);
        itemUnoTxtInv.text = Inventario._Inventario.PInventario[1].ToString();
    }
}
