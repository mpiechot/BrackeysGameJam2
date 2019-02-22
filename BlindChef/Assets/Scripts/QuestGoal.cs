using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public List<Zutat> goals;

    public bool IsReached(Essen collected)
    {
        Zutat[] current = new Zutat[collected.ZutatenListe.Count];
        collected.ZutatenListe.CopyTo(current);
        foreach(Zutat z1 in goals)
        {
            bool foundZ1 = false;
            for(int i= current.Length-1;i >= 0;i--)
            {
                Zutat z2 = current[i];
                if (z1.ZutatName.Equals(z2.ZutatName) && z1.Zustand == z2.Zustand)
                {
                    foundZ1 = true;
                    current[i].ZutatName = ZutatTyp.Empty;
                    break;
                }
            }
            if (!foundZ1)
            {
                return false;
            }
        }    
        return true;
    }
}
