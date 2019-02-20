using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public List<Zutat> goals;

    public bool IsReached(Essen collected)
    {
        List<Zutat> current = collected.ZutatenListe;
        foreach(Zutat z1 in goals)
        {
            bool foundZ1 = false;
            for(int i= current.Count-1;i >= 0;i--)
            {
                Zutat z2 = current[i];
                if (z1.ZutatName.Equals(z2.ZutatName) && z1.Zustand == z2.Zustand)
                {
                    foundZ1 = true;
                    current.RemoveAt(i);
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
