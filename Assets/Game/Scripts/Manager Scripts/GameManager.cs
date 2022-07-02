using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int totalPhone;

    void Start()
    {
        if (LevelManager.Instance.GetGlobalLevelIndex() == 0) //if its a new start
        {
            totalPhone = 0;
            PlayerPrefs.SetInt("TotalPhone", totalPhone);
        }

        if (PlayerPrefs.GetInt("TotalPhone") >= 0) //if the total amount and level are higher than  1;
        {
            SetTotalPhone(0);
        }
    }

    private void SetTotalPhone(int collectedAmount)
    {
        totalPhone = PlayerPrefs.GetInt("TotalPhone", 0) + collectedAmount;
        PlayerPrefs.SetInt("TotalPhone", totalPhone);
        UIManager.Instance.SetTotalPhone();

        totalPhone = 0;
    }
}
