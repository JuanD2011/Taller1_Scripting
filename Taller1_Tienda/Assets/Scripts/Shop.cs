using System.Collections;
using System.Collections.Generic;

public class Shop
{
    public delegate void Compra();
    public static event Compra OnSatisfactoria, OnInsatisfactoria;
    public static event Compra OnExisteNonConsumable;

    Item itemUno;
    Item itemDos;

    public Shop()
    {
        itemUno = new Consumable(1,2,5,6);
        itemDos = new NonCosumable(2,4,0,0);
    }

    public void Comprar(int _id)
    {
        Item _item = null;

        switch (_id)
        {
            case 1:
                _item = itemUno;
                break;
            case 2:
                _item = itemDos;
                break;
            default:
                break;
        }

        if (Inventario.Instancia.VerificaDisponibilidadMonetaria(_item.Costo))
        {
            if (Inventario.Instancia.VerificarExistencia(_item))
            {
                OnExisteNonConsumable();
            }
            else {
                //Compra hecha
                Inventario.Instancia.Adquisicion(_item);
                Dictionary<TypeCurrency, int> cost = new Dictionary<TypeCurrency, int>();
                cost.Add(TypeCurrency.firstCurrency, _item.Costo[TypeCurrency.firstCurrency]*-1);
                cost.Add(TypeCurrency.secondCurrency, _item.Costo[TypeCurrency.secondCurrency] * -1);
                cost.Add(TypeCurrency.thirdCurrency, _item.Costo[TypeCurrency.thirdCurrency] * -1);
                Inventario.Instancia.ActualizarCurrency(cost);
                OnSatisfactoria();
            }
        }
        else {
            //no tiene pa comprar
            OnInsatisfactoria();
        }
    }

   /* public void Consumir(Item _item)
    {
        if (_item is Consumable)
        {
            Inventario.Instancia.ConsumirItem(_item);
        }
    }*/
}
