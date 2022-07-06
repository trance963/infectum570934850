using UnityEngine;

public class VictimInfo : MonoBehaviour
{
    public int Health;

    private void Start()
    {
        Health = Random.Range(3,5);//�������� ������
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