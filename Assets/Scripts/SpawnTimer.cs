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
    private int RandomVictim; //���������� ����������
    public int HowMuchVictim;// ������� ���������, ���������� ����� �����
    public int HowMuchKills;


    void Start() // � ������� ��������!!!11
    {
        StartCoroutine(WaitAndSpawn());
    }

    public IEnumerator WaitAndSpawn() //������� ������� ����� ��������
    {
        RandomVictim = Random.Range(0, Victim.Length - 1);
        Spawn();
        yield return new WaitForSeconds(Random.Range(MinTimeWait, MaxTimeWait));
        if (HowMuchVictim >= 10)// ���� �������� ����� 10, ������������� �����
        {
            StopCoroutine(WaitAndSpawn());
            GameUI.SetActive(false);
            LoseUI.SetActive(true);
        }
        else //��� ������� �����
        {
            StartCoroutine(WaitAndSpawn());
        }
    }

    public void Spawn()// ��� ����� ������
    {
        Instantiate(Victim[RandomVictim]).tag = "clone";// ��� �������� ��������� ���, ������� �������� � ����������
        Victim[RandomVictim].transform.position = new Vector3(Random.Range(MinWidthSpawn,MaxWidthSpawn), Random.Range(MinHeightSpawn,MaxHeightSpawn), 1); // ��������� ����� � �������� ��������� � ����������
        HowMuchVictim++;// ���� � ������� �������� �����
    }
}
