using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OutroManager : MonoBehaviour
{

    public TextMeshProUGUI textObj;

    public void Display(PlayerScripts player, Essen essen, bool hasWon)
    {
        GetComponent<Canvas>().enabled = true;
        string displayText = "";
        if(hasWon)
        {
            displayText += "Congratulations, you cooked the correct meal.\n" +
                "";
            essen.ZutatenListe.ForEach(z => displayText += z.ZutatName + " " + convertZustand(z.Zustand) + "\n");
            displayText += player.quest.description;
        }
        else
        {
            displayText += "Oh no, you cooked the wrong meal.\n" +
                "";
            essen.ZutatenListe.ForEach(z => displayText += z.ZutatName + " " + convertZustand(z.Zustand) + "\n");
            displayText += player.quest.description;
        }
        textObj.text = displayText;
    }

    public void Restart()
    {
        QuestGiver.Instance.NewQuest();
        GetComponent<Canvas>().enabled = false;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && GetComponent<Canvas>().enabled)
        {
            Restart();
        }
    }

    string convertZustand(byte zustand)
    {
        string zstString = "";
        if ((zustand & 1) == 1)
            zstString += "fresh ";
        if ((zustand & 2) == 2)
            zstString += "cooked ";
        if ((zustand & 4) == 4)
            zstString += "burned ";
        if ((zustand & 8) == 8)
            zstString += "washed ";
        if ((zustand & 16) == 16)
            zstString += "trashed ";

        return zstString;
    }
}
