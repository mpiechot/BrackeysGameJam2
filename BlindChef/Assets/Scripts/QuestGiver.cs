using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public List<Quest> quests;

    public PlayerScripts player;

    public GameObject questWindow;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    private int randomQuest;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        randomQuest = Random.Range(0, quests.Count);

        title.text = quests[randomQuest].title;
        description.text = quests[randomQuest].description;
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quests[randomQuest].isActive = true;
        player.quest = quests[randomQuest];
    }

    void Update()
    {
        if(player.quest == null && !questWindow.activeSelf)
        {
            OpenQuestWindow();
        }
    }
}
