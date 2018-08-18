using System.Collections;
using System.Collections.Generic;

public class Inventario {

    static Inventario instancia;

    Dictionary<int, int> inventario = new Dictionary<int, int>();
    public Dictionary<int, int> PInventario
    {
        get
        {
            return inventario;
        }
    }

    Dictionary<TypeCurrency, int> billetera = new Dictionary<TypeCurrency, int>();
    public Dictionary<TypeCurrency, int> Billetera
    {
        get
        {
            return billetera;
        }
    }

    public Inventario() {
        billetera.Add(TypeCurrency.firstCurrency, 40);
        billetera.Add(TypeCurrency.secondCurrency, 40);
        billetera.Add(TypeCurrency.thirdCurrency, 40);
    }

    public static Inventario _Inventario
    {
        get {
            if (instancia == null)
            {
                instancia = new Inventario();
            }
            return instancia;
        }
    }


    public void Adquisicion(Item _item) {

        if (_item is Consumable)
        {
            if (inventario.ContainsKey(_item.Id))
            {
                inventario[_item.Id] += 1;
            }
            else {
                inventario.Add(_item.Id, 1);
            }
        }
        if ((_item is NonCosumable))
        {
            inventario.Add(_item.Id, 1);
        }
    }

    public bool VerificarExistencia(Item _item) {
        bool existe = false;

        if (_item is NonCosumable && inventario.ContainsKey(_item.Id)) {
            existe = true;
        }

        return existe;
    }

    /// <summary>
    /// sólo se llama cuando se puede comprar
    /// </summary>
    /// <param name="_costo"></param>
    public void ActualizarCurrency(Dictionary<TypeCurrency, int> _costo) {
        billetera[TypeCurrency.firstCurrency] += _costo[TypeCurrency.firstCurrency];
        billetera[TypeCurrency.secondCurrency] += _costo[TypeCurrency.secondCurrency];
        billetera[TypeCurrency.thirdCurrency] += _costo[TypeCurrency.thirdCurrency];
    }

    public bool VerificaDisponibilidadMonetaria(Dictionary<TypeCurrency, int> _costo) {
        bool puedoComprarSignoPregunta = true;

        if (billetera[TypeCurrency.firstCurrency] < _costo[TypeCurrency.firstCurrency] ||
            billetera[TypeCurrency.secondCurrency] < _costo[TypeCurrency.secondCurrency] ||
            billetera[TypeCurrency.thirdCurrency] < _costo[TypeCurrency.thirdCurrency])
        {
            puedoComprarSignoPregunta = false;
        }
        return puedoComprarSignoPregunta;
    }

    public void ConsumirItem(Item _item) {
        inventario[_item.Id] -= 1;
    }
}
