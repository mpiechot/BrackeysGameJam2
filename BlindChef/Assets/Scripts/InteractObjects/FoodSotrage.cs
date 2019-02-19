using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSotrage : InteractObject
{
    public ZutatTyp ZutatZuHolen;


    public override Essen GetFood()
    {
        Zutat zutat = new Zutat();
        zutat.ZutatName = ZutatZuHolen;
        return new Essen(new List<Zutat> { zutat });
    }
}
