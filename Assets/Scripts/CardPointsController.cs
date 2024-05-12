using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPointsController : MonoBehaviour
{
    public static CardPointsController instance;

    void Awake()
    {
        instance = this;
    }

    public CardPlacePoint[] playerCardPoints, enemyCardPoints;

    public float timeBetweenAttacks = .25f;

    void Start()
    {

    }

    void Update()
    {

    }

    public void PlayerAttack()
    {
        StartCoroutine(PlayerAttackCo());
    }

    IEnumerator PlayerAttackCo()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);

        for (int i = 0; i < playerCardPoints.Length; i++)
        {
            if (playerCardPoints[i].activeCard != null)
            {
                if (enemyCardPoints[i].activeCard != null)
                {
                    // Attack the enemy card
                }
                else
                {
                    // Attack the enemy's overall health
                }

                yield return new WaitForSeconds(timeBetweenAttacks);
            }
        }

        BattleController.instance.AdvanceTurn();
    }
}
