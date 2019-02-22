using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public static QuestGiver Instance;

    public List<Quest> quests;
    public PlayerScripts player;
    public OutroManager Om;
    public GameObject questWindow;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    private int randomQuest;

    private bool toggleWindowButton;

    private void Awake()
    {
        Instance = this;
        NewQuest();
    }

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

    public void NewQuest()
    {
        OpenQuestWindow();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && questWindow.activeInHierarchy)
        {
            AcceptQuest();
        }
    }
}
