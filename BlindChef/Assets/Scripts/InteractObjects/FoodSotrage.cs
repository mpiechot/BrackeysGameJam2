using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSotrage : InteractObject
{
    public ZutatTyp ZutatZuHolen;

    private void Start()
    {
        IsEmpty = false;
        isProcessing = false;
        currentProcessTime = 0;
        CanGetIngredient = true;
    }

    public override Essen GetFood()
    {
        Zutat zutat = new Zutat();
        zutat.ZutatName = ZutatZuHolen;
        zutat.Zustand = (byte)ZutatZustand.Roh;
        return new Essen(new List<Zutat> { zutat });
    }
}
