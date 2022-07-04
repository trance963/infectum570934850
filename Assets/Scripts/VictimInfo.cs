using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimInfo : MonoBehaviour
{
    public int Health;

    private void Start()
    {
        Health = Random.Range(3,5);//здоровье жертвы
    }

    public void OnMouseDown() //при нажатии 
    {
        if (Health <= 1) //условие уничтожения
        {
            Debug.Log("Victim is dead");
            Health--;
            Destroy(gameObject);
        }

        else
        {
            Health--;
        }
    }

    public void OnDestroy()// при разрушении
    {
        GameObject go = GameObject.Find("Game");//находим владельца счетчика
        SpawnTimer spawnTimer = go.GetComponent<SpawnTimer>();// получаем переменную из гейм
        spawnTimer.HowMuchVictim--;//минус в счетчик активных жертв
        spawnTimer.HowMuchKills++;//плюс в счетчик сложности
    }
}