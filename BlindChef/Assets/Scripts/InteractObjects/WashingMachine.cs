using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachine : InteractObject
{

    void Update()
    {
        if (isProcessing)
            Process();
    }

    protected override void Process()
    {
        currentProcessTime += Time.deltaTime;
        if (currentProcessTime > ProcessTime)
            currentEssen.ZutatenListe.ForEach(z => z.Zustand = ZutatZustand.Gewaschen);
    }

    public override void AddFood(Essen foodToAdd)
    {
        currentEssen = foodToAdd;
        IsEmpty = false;
        isProcessing = true;
    }

    public override Essen GetFood()
    {
        return currentEssen;
    }
}