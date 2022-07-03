using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    public GameObject [] Victim;
    public float MinTimeWait;
    public float MaxTimeWait;
    public float MaxWidthSpawn;
    public float MinWidthSpawn;
    public float MaxHeightSpawn;
    public float MinHeightSpawn;
    private int RandomVictim;
    public int HowMuchVictim;

    void Start() // � ������� ��������!!!11
    {
        StartCoroutine(WaitAndSpawn());
    }

    IEnumerator WaitAndSpawn() //������� ������� ����� ��������
    {
        RandomVictim = Random.Range(0, Victim.Length - 1);
        Spawn();
        yield return new WaitForSeconds(Random.Range(MinTimeWait, MaxTimeWait));
        if (HowMuchVictim >= 10)// ���� �������� ����� 10, ������������� �����
        {
            StopCoroutine(WaitAndSpawn());
            Debug.Log("Stop WaitAndSpawn");// ����� ��������
        }
        else //��� ������� �����
        {
            StartCoroutine(WaitAndSpawn());
        }
    }

    public void Spawn()// ��� ����� ������
    {
        Instantiate(Victim[RandomVictim]);
        Victim[RandomVictim].transform.position = new Vector3(Random.Range(MinWidthSpawn,MaxWidthSpawn), Random.Range(MinHeightSpawn,MaxHeightSpawn), 1);
        HowMuchVictim++;
    }
}
