using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : InteractObject
{
    
    void Update()
    {
        if (isProcessing)
            Process();
    }

    protected override void Process()
    {
        currentProcessTime += Time.deltaTime;
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
