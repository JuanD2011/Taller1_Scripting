using System.Collections;
using System.Collections.Generic;

public abstract class Item
{
    int id;
    public int Id
    {
        get
        {
            return id;
        }
    }

    public Dictionary<TypeCurrency, int> Costo
    {
        get
        {
            return costo;
        }

        set
        {
            costo = value;
        }
    }

    Dictionary<TypeCurrency, int> costo = new Dictionary<TypeCurrency, int>();

    public Item(int _id, int _costoCurrencyUno, int _costoCurrencyDos, int _costoCurrencyTres) {
        id = _id;
        Costo.Add(TypeCurrency.firstCurrency, _costoCurrencyUno);
        Costo.Add(TypeCurrency.secondCurrency, _costoCurrencyDos);
        Costo.Add(TypeCurrency.thirdCurrency, _costoCurrencyTres);
    }

}
