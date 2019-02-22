using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OutroManager : MonoBehaviour
{

    public TextMeshProUGUI textObj;
    public Sprite[] FoodSprites;
    public GameObject FoodDisplay;

    private List<GameObject> FoodItems;

    public void Display(PlayerScripts player, Essen essen, bool hasWon)
    {
        GetComponent<Canvas>().enabled = true;
        string displayText = "";
        FoodItems = new List<GameObject>();
        if (hasWon)
            displayText += "Congratulations, you cooked the correct meal.\n";
        else
            displayText += "Oh no, you cooked the wrong meal.\n";

        int zutatNum = 0;
        essen.ZutatenListe.ForEach(z =>
        {
            displayText += z.ZutatName + " " + convertZustand(z.Zustand) + "\n";
            Image img = Instantiate(FoodDisplay, transform).GetComponent<Image>();
            img.transform.localPosition = new Vector3(300, 100 - 40 * zutatNum, 0);
            img.sprite =
            z.ZutatName == ZutatTyp.Tomato ? FoodSprites[0] :
            z.ZutatName == ZutatTyp.Mushrooms ? FoodSprites[1] :
            FoodSprites[2];
            FoodItems.Add(img.gameObject);
            zutatNum++;
        }
        );
        displayText += player.quest.description;
        textObj.text = displayText;
    }

    public void Restart()
    {
        QuestGiver.Instance.NewQuest();
        GetComponent<Canvas>().enabled = false;
        if(FoodItems != null)
            FoodItems.ForEach(fi => Destroy(fi, 0.1f));
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && GetComponent<Canvas>().enabled)
        {
            Restart();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
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
