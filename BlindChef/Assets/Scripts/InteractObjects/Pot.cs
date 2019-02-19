using System.Collections;
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
        {
            for (int i = 0; i < currentEssen.ZutatenListe.Count; i++)
            {
                var z = currentEssen.ZutatenListe[i];
                z.Zustand |= (byte)ZutatZustand.Verbrannt;
                currentEssen.ZutatenListe[i] = z;
            }
        }
        else if(currentProcessTime > ProcessTime)
        {
            for (int i = 0; i < currentEssen.ZutatenListe.Count; i++)
            {
                var z = currentEssen.ZutatenListe[i];
                z.Zustand |= (byte)ZutatZustand.Gekocht;
                currentEssen.ZutatenListe[i] = z;
            }
        }


        currentEssen.ZutatenListe.ForEach(z => print(z.Zustand));
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
