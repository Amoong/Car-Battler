using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    void Awake()
    {
        instance = this;
    }

    public List<CardScriptableObject> deckToUse = new List<CardScriptableObject>();
    private List<CardScriptableObject> activeCards = new List<CardScriptableObject>();

    void Start()
    {
        SetupDeck();
    }

    void Update()
    {

    }

    public void SetupDeck()
    {
        activeCards.Clear();

        List<CardScriptableObject> tempDeck = new List<CardScriptableObject>();
        tempDeck.AddRange(deckToUse);

        int iterations = 0;
        while (tempDeck.Count > 0 && iterations < 500)
        {
            int selected = Random.Range(0, tempDeck.Count);
            activeCards.Add(tempDeck[selected]);
            tempDeck.RemoveAt(selected);
            iterations++;
        }
    }

    public void StartAction()
    {
        StartCoroutine(EnemyActionCo());
    }

    IEnumerator EnemyActionCo()
    {
        if (activeCards.Count == 0)
        {
            SetupDeck();
        }

        yield return new WaitForSeconds(.5f);

        BattleController.instance.AdvanceTurn();
    }
}
