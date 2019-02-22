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
            essen.ZutatenListe.ForEach(z => displayText += z.ZutatName + " " + z.Zustand + "\n");
        }
        else
        {
            displayText += "Oh no, you cooked the wrong meal.\n" +
                "";
            essen.ZutatenListe.ForEach(z => displayText += z.ZutatName + " " + z.Zustand + "\n");
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


}
