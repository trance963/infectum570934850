using System.Collections;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    public GameObject GameUI;
    public GameObject LoseUI;
    public GameObject [] Victim; 
    public float MinTimeWait;
    public float MaxTimeWait;
    public float MaxWidthSpawn;
    public float MinWidthSpawn;
    public float MaxHeightSpawn;
    public float MinHeightSpawn;
    public int MaxHP;
    public int MinHP;
    private int RandomVictim; //определяем случайного
    public int HowMuchVictim;// условие проигрыша, количество живых жертв
    public int HowMuchKills;


    void Start() // Я СКАЗАЛА СТАРТУЕМ!!!11
    {
        StartCoroutine(WaitAndSpawn());
    }

    public IEnumerator WaitAndSpawn() //счетчик времени между спавнами
    {
        RandomVictim = Random.Range(0, Victim.Length - 1);
        Spawn();
        yield return new WaitForSeconds(Random.Range(MinTimeWait, MaxTimeWait));
        if (HowMuchVictim >= 10)// если активных целей 10, останавливаем спавн
        {
            StopCoroutine(WaitAndSpawn());
            GameUI.SetActive(false);
            LoseUI.SetActive(true);
        }
        else //или создаем новую
        {
            StartCoroutine(WaitAndSpawn());
        }
    }

    public void Spawn()// сам метод спавна
    {
        Instantiate(Victim[RandomVictim]).tag = "clone";// при создании назначаем тег, заранее сделаный в инспекторе
        Victim[RandomVictim].transform.position = new Vector3(Random.Range(MinWidthSpawn,MaxWidthSpawn), Random.Range(MinHeightSpawn,MaxHeightSpawn), 1); // рандомное место в пределах указанных в инспекторе
        HowMuchVictim++;// плюс в счетчик активных целей
    }
}
