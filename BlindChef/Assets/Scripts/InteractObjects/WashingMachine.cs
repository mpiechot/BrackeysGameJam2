using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachine : InteractObject
{
    private ParticleSystem particles;

    private void Start()
    {
        IsEmpty = true;
        isProcessing = false;
        currentProcessTime = 0;
        CanGetIngredient = false;
        particles = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (isProcessing)
            Process();
        else
        {
            particles.loop = false;
        }
    }

    protected override void Process()
    {
        if (particles.isStopped || !particles.loop)
        {
            particles.Play();
            particles.loop = true;
        }
        currentProcessTime += Time.deltaTime;
        if (currentProcessTime > ProcessTime)
        {
            for (int i = 0; i < currentEssen.ZutatenListe.Count; i++)
            {
                var z = currentEssen.ZutatenListe[i];
                z.Zustand |= (byte)ZutatZustand.Gewaschen;
                currentEssen.ZutatenListe[i] = z;
            }
        }


        //currentEssen.ZutatenListe.ForEach(z => print(z.Zustand));
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