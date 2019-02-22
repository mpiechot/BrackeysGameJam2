using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : InteractObject
{
    private ParticleSystem particles;

    private void Start()
    {
        IsEmpty = true;
        isProcessing = false;
        currentProcessTime = 0;
        CanGetIngredient = false;
        particles = GetComponentInChildren<ParticleSystem>();
        particles.startColor = Color.red;
    }

    void Update()
    {
        if (isProcessing)
            Process();
        else{
            particles.loop = false;
        }
    }

    public byte GetRemoveZustandMask(params ZutatZustand[] zustand)
    {
        byte mask = 0;
        foreach(ZutatZustand z in zustand)
        {
            mask |= (byte)z;
        }
        return (byte)(~mask);
    }

    protected override void Process()
    {
        if(particles.isStopped || !particles.loop){
            particles.Play();
            particles.loop = true;
        }
        currentProcessTime += Time.deltaTime;
        if(currentProcessTime > ProcessTime * 1.5f)
        {
            particles.startColor = Color.gray;
            for (int i = 0; i < currentEssen.ZutatenListe.Count; i++)
            {
                var z = currentEssen.ZutatenListe[i];
                z.Zustand |= (byte)ZutatZustand.Verbrannt;
                z.Zustand &= GetRemoveZustandMask(ZutatZustand.Gekocht);
                currentEssen.ZutatenListe[i] = z;
            }
        }
        else if(currentProcessTime > ProcessTime)
        {
            particles.startColor = Color.green;
            for (int i = 0; i < currentEssen.ZutatenListe.Count; i++)
            {
                var z = currentEssen.ZutatenListe[i];
                z.Zustand |= (byte)ZutatZustand.Gekocht;
                z.Zustand &= GetRemoveZustandMask(ZutatZustand.Roh);
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
