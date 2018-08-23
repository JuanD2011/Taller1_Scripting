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
        currencyUno.text = Inventario.Instancia.Billetera[TypeCurrency.firstCurrency].ToString("0");
        currencyDos.text = Inventario.Instancia.Billetera[TypeCurrency.secondCurrency].ToString("0");
        currencyTres.text = Inventario.Instancia.Billetera[TypeCurrency.thirdCurrency].ToString("0");
    }

    public void CompraTxtSatisfactoria() {
        StartCoroutine(TxtCompra());
        WriteCurrency();
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

    public void Boton(int _id)
    {

        GameController._GameController.mShop.Comprar(_id);
        Item item = Inventario.Instancia.ConversorIdtoItem(_id);
        itemUnoTxt.text = Inventario.Instancia.PInventario[item].ToString();
        itemUnoTxtInv.text = Inventario.Instancia.PInventario[item].ToString();
    }

    #region modificarCurrency
    public void ModificarCurrencyUno(string _input) {
        int cantidad = int.Parse(_input);
        Inventario.Instancia.Billetera[TypeCurrency.firstCurrency] = cantidad;
        WriteCurrency();
    }

    public void ModificarCurrencyDos(string _input)
    {
        int cantidad = int.Parse(_input);
        Inventario.Instancia.Billetera[TypeCurrency.secondCurrency] = cantidad;
        WriteCurrency();
    }

    public void ModificarCurrencyTres(string _input)
    {
        int cantidad = int.Parse(_input);
        Inventario.Instancia.Billetera[TypeCurrency.thirdCurrency] = cantidad;
        WriteCurrency();
    }
    #endregion

    public void DescartarItem(int _id, string _descartar)
    {
        Item item = Inventario.Instancia.ConversorIdtoItem(_id);

        int cantidad = int.Parse(_descartar);
        Inventario.Instancia.DescartarItem(1 , cantidad);
        itemUnoTxtInv.text = Inventario.Instancia.PInventario[item].ToString();
    }
}
