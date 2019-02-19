using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public string ZutatName;
}

public class Essen : MonoBehaviour
{

    public List<Zutat> ZutatenListe { get; private set; }

    void Start()
    {
        ZutatenListe = new List<Zutat>();
    }

    public void AddZutat(Zutat zutat)
    {
        ZutatenListe.Add(zutat);
    }
}
