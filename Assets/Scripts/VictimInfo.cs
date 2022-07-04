using System.Collections;
using System.Collections.Generic;
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
            Debug.Log("Victim is dead");
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