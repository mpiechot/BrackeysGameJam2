using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bar : InteractObject
{

    public PlayerScripts player;
    public TextMeshProUGUI score;

    private void Start()
    {
        IsEmpty = true;
        isProcessing = false;
        currentProcessTime = 0;
        CanGetIngredient = false;
        score.text = player.score+"";
    }

    void Update()
    {
        if (isProcessing)
            Process();
    }

    protected override void Process()
    {
        print("Essen abgegeben.");
        currentEssen.ZutatenListe.ForEach(z =>
        {
            print(z.ZutatName + ": " + z.Zustand);
            if ((z.Zustand & 1) == 1)
                print("Roh");
            if ((z.Zustand & 2) == 2)
                print("Gekocht");
            if ((z.Zustand & 4) == 4)
                print("Verbrannt");
            if ((z.Zustand & 8) == 8)
                print("Gewaschen");
            if ((z.Zustand & 16) == 16)
                print("Vermüllt");
        }
        );

        if (player.quest.goal.IsReached(currentEssen))
        {
            print("Yay!");
            player.score += 10;

        }
        else
        {
            print("Nooooo!");
            player.score -= 10;
        }
        //Show Food

        score.text = player.score + "";

        IsEmpty = true;
        isProcessing = false;
        currentProcessTime = 0;
        CanGetIngredient = false;
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