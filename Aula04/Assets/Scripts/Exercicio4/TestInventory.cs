using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Variáveis necessárias
        AbstractItem mainBag, secondaryBag;

        // Criar sacola principal
        mainBag = new CompositeItem();

        // Colocar três itens com um peso total de 30
        mainBag.Add(new LeafItem(12.5f));
        mainBag.Add(new LeafItem(2.5f));
        mainBag.Add(new LeafItem(15f));

        // Criar sacola secundária
        secondaryBag = new CompositeItem();

        // Colocar dois itens com um peso total de 20
        secondaryBag.Add(new LeafItem(11.3f));
        secondaryBag.Add(new LeafItem(8.7f));

        // Colocar sacola secundária na principal
        mainBag.Add(secondaryBag);

        // Imprimir o peso total dos itens na sacola principal (supostamente 50)
        Debug.Log($"Total weight in main bag = {mainBag.Weight}");

        // Mostrar todos os itens e sub-itens com um simples ToString à
        // sacola principal
        Debug.Log(mainBag.ToString());
    }
}
