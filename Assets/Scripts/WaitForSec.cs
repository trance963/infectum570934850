using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForSec : MonoBehaviour
{
    private Logic Logic;
    public GameObject [] Victim;
    public float MinTimeWait;
    public float MaxTimeWait;
    private int RandomVictim;
    public int HowMuchVictim;

    public object Enumenator { get; internal set; }

    void Start() // � ������� ��������!!!11
    {
        StartCoroutine(WaitAndSpawn());
    }

    private void Update()
    {
        if (HowMuchVictim <= 9)// �������, ���� �������� ����� ������ 10
        {
            StartCoroutine(WaitAndSpawn());
        }

        else
        {
            StopCoroutine(WaitAndSpawn());
            Logic.TooMuch();// ����������� ����, ���� ����� ������ 10
        }
    }

    IEnumerator WaitAndSpawn() //������� ������� ����� ��������
    {
        yield return new WaitForSeconds(Random.Range(MinTimeWait, MaxTimeWait));
        RandomVictim = Random.Range(0, Victim.Length - 1);
        Spawn();
    }


    void Spawn()// ��� ����� ������
    {
        Instantiate(Victim[RandomVictim]);
        HowMuchVictim++;
    }
}
