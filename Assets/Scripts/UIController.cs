using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public TMP_Text playerManaText;
    public GameObject manaWarning;
    public float manaWarningTime;
    private float manaWarningCounter;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
    }

    void Update()
    {
        if (manaWarningCounter > 0)
        {
            manaWarningCounter -= Time.deltaTime;

            if (manaWarningCounter <= 0)
            {
                manaWarning.SetActive(false);
            }
        }
    }

    public void SetPlayerManaText(int manaAmount)
    {
        playerManaText.text = "MANA: " + manaAmount;
    }

    public void ShowManaWarning()
    {
        manaWarning.SetActive(true);
        manaWarningCounter = manaWarningTime;
    }
}
