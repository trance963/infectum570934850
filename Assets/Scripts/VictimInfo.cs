using UnityEngine;

public class VictimInfo : MonoBehaviour
{
    public ParticleSystem Tap;
    public int Health;
    private void Awake()
    {
        Tap = GetComponent<ParticleSystem>();
    }
    private void Start()
    {
        GameObject go = GameObject.Find("Game");//находим владельца счетчика
        SpawnTimer spawnTimer = go.GetComponent<SpawnTimer>();// получаем переменную из гейм
        Health = Random.Range(spawnTimer.MinHP, spawnTimer.MaxHP);//здоровье жертвы
    }

    public void OnMouseDown() //при нажатии 
    {
        if (Health <= 1) //условие уничтожения
        {
            Health--;
            Destroy(gameObject);
        }

        else
        {
            Health--;
            Tap.Play();
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