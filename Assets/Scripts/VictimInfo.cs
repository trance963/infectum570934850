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
        GameObject go = GameObject.Find("Game");//������� ��������� ��������
        SpawnTimer spawnTimer = go.GetComponent<SpawnTimer>();// �������� ���������� �� ����
        Health = Random.Range(spawnTimer.MinHP, spawnTimer.MaxHP);//�������� ������
    }

    public void OnMouseDown() //��� ������� 
    {
        if (Health <= 1) //������� �����������
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

    public void OnDestroy()// ��� ����������
    {
        GameObject go = GameObject.Find("Game");//������� ��������� ��������
        SpawnTimer spawnTimer = go.GetComponent<SpawnTimer>();// �������� ���������� �� ����
        spawnTimer.HowMuchVictim--;//����� � ������� �������� �����
        spawnTimer.HowMuchKills++;//���� � ������� ���������
    }
}