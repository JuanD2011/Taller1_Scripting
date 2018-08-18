using System.Collections;
using System.Collections.Generic;

public class Shop
{
    public delegate void Compra();
    public static event Compra OnSatisfactoria, OnInsatisfactoria;
    public static event Compra OnExisteNonConsumable;

    Item itemUno;

    public Shop() {
        itemUno = new Consumable(1,2,5,6);
    }

    public void Comprar(int _id) {
        Item _item = null;

        if (_id == itemUno.Id) {
            _item = itemUno;
        }
        if (Inventario._Inventario.VerificaDisponibilidadMonetaria(_item.Costo))
        {
            if (Inventario._Inventario.VerificarExistencia(_item))
            {
                OnExisteNonConsumable();
            }
            else {
                //Compra hecha
                Inventario._Inventario.Adquisicion(_item);
                Dictionary<TypeCurrency, int> cost = new Dictionary<TypeCurrency, int>();
                cost.Add(TypeCurrency.firstCurrency, _item.Costo[TypeCurrency.firstCurrency]*-1);
                cost.Add(TypeCurrency.secondCurrency, _item.Costo[TypeCurrency.secondCurrency] * -1);
                cost.Add(TypeCurrency.thirdCurrency, _item.Costo[TypeCurrency.thirdCurrency] * -1);
                Inventario._Inventario.ActualizarCurrency(cost);
                OnSatisfactoria();
            }
        }
        else {
            //no tiene pa comprar
            OnInsatisfactoria();
        }
    }

    public void Consumir(Item _item) {
        if (_item is Consumable) {
            Inventario._Inventario.ConsumirItem(_item);
        }
    }
}
