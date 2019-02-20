using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZutatTyp
{
    Pilze,
    Tomaten,
    Hackfleisch
}

//Byte Codierung:
// Ro|Ko|Br|Wa|Mü
// 0  0  0  0  0
// 1  2  3  4  5

public enum ZutatZustand
{
    Roh = 1,
    Gekocht = 2,
    Verbrannt = 4,
    Gewaschen = 8,
    Vermüllt = 16
}

public struct Zutat
{
    public byte Zustand;
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
