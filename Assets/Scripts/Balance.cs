using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public bool DifficultStart;
    public bool DifficultVeryLow;
    public bool DifficultLow;
    public bool DifficultNormal;
    public bool DifficultHard;
    public bool DifficultImpossible;

    public void Update()
    {
        GameDifficult();
    }
    public void GameDifficult()
    {
        GameObject go = GameObject.Find("Game");//находим владельца счетчика
        SpawnTimer spawnTimer = go.GetComponent<SpawnTimer>();// получаем переменную из гейм
        if (spawnTimer.HowMuchKills >= 10 & !DifficultVeryLow)
        {
            spawnTimer.MinTimeWait -= 0.1f;
            spawnTimer.MaxTimeWait -= 0.5f;
            spawnTimer.MinHP += 1;
            spawnTimer.MaxHP += 1;
            DifficultVeryLow = true;
        }

        else if (spawnTimer.HowMuchKills >= 20 & !DifficultLow)
        {
            spawnTimer.MinTimeWait -= 0.1f;
            spawnTimer.MaxTimeWait -= 0.4f;
            spawnTimer.MaxHP += 2;
            DifficultLow = true;
        }

        else if (spawnTimer.HowMuchKills >= 30 & !DifficultNormal)
        {
            spawnTimer.MinTimeWait -= 0.1f;
            spawnTimer.MaxTimeWait -= 0.3f;
            spawnTimer.MaxHP += 2;
            DifficultNormal = true;
        }

        else if (spawnTimer.HowMuchKills >= 40 & !DifficultHard)
        {
            spawnTimer.MinTimeWait -= 0.1f;
            spawnTimer.MaxTimeWait -= 0.3f;
            spawnTimer.MaxHP += 1;
            DifficultHard = true;
        }

        else if (spawnTimer.HowMuchKills >= 50 & !DifficultImpossible)
        {
            spawnTimer.MaxTimeWait -= 0.3f;
            spawnTimer.MinHP += 1;
            DifficultImpossible = true;
        }
    }
}