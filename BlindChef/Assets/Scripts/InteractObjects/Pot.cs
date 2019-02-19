﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : InteractObject
{
    private void Start()
    {
        IsEmpty = true;
        isProcessing = false;
        currentProcessTime = 0;
        CanGetIngredient = false;
    }

    void Update()
    {
        if (isProcessing)
            Process();
    }

    protected override void Process()
    {
        currentProcessTime += Time.deltaTime;
        if(currentProcessTime > ProcessTime * 1.5f)
            currentEssen.ZutatenListe.ForEach(z => z.Zustand = ZutatZustand.Verbrannt);
        else if(currentProcessTime > ProcessTime)
        {
            currentEssen.ZutatenListe.ForEach(z => z.Zustand = ZutatZustand.Gekocht);
        }
    }

    public override void AddFood(Essen foodToAdd)
    {
        currentEssen = foodToAdd;
        IsEmpty = false;
        isProcessing = true;
        CanGetIngredient = true;
    }

    public override Essen GetFood()
    {
        IsEmpty = true;
        isProcessing = false;
        currentProcessTime = 0;
        CanGetIngredient = false;
        return currentEssen;
    }
}
