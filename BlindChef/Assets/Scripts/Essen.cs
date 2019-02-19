﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZutatTyp
{
    Pilze,
    Tomaten,
    Hackfleisch
}

public enum ZutatZustand
{
    Roh,
    Gekocht,
    Verbrannt,
    Gewaschen,
    Vermüllt
}

public struct Zutat
{
    public ZutatZustand Zustand;
    public ZutatTyp ZutatName;
}

public class Essen
{

    public List<Zutat> ZutatenListe { get; private set; }

    public Essen()
    {
        ZutatenListe = new List<Zutat>();
    }

    public Essen(List<Zutat> initZutat)
    {
        ZutatenListe = initZutat;
    }

    public void AddZutat(Zutat zutat)
    {
        ZutatenListe.Add(zutat);
    }

    public void Merge(Essen otherEssen)
    {
        ZutatenListe.AddRange(otherEssen.ZutatenListe);
    }
}
