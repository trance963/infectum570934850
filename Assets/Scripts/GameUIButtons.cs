using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIButtons : MonoBehaviour
{
    public SpawnTimer spawnTimer; //�������� ������� ����������� ��, ��� �� ������� ��� ������������
    public GameObject RestartBut;
    public GameObject MenuBut;
    public GameObject FreezeBut;
    public int FreezeTime;//���������� ������� ������� ���������
    public int FreezePoints;
    public int ClearPoints;//���������� ��������
    public GameObject ClearBut;
    public Text HowMuchKillsText;
    public Text FreezePointsText;
    public Text ClearPointsText;

    void Start()
    {
        Button btn1 = RestartBut.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClickRestart); // ��������� restart
        Button btn2 = MenuBut.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickMenu); // ��������� menu
        Button btn3 = FreezeBut.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClickFreeze); // ��������� freeze
        Button btn4 = ClearBut.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClickClear); // ��������� freeze
        HowMuchKillsText.text = spawnTimer.HowMuchKills.ToString();//����������� � �����
        FreezePointsText.text = FreezePoints.ToString();
        ClearPointsText.text = ClearPoints.ToString();
    }

    private void Update()
    {
        HowMuchKillsText.text = spawnTimer.HowMuchKills.ToString();//��� ���������, �.�. ������������ � ��������, �������� �������� ����. ��������� �� ������ ����������� � ����� ��������
    }

    public void TaskOnClickRestart()//����� �������� ������� �����
    {
        SceneManager.LoadScene(1);//����� ���� ������
    }

    public void TaskOnClickMenu()
    {
        SceneManager.LoadScene(0);//������
    }

    public void TaskOnClickFreeze()
    {
        StartCoroutine(FreezeSpawn());
    }

    public IEnumerator FreezeSpawn() //������� ������� ����� ��������
    {
        if (FreezePoints >= 1)
        {
            FreezePoints--;
            FreezePointsText.text = FreezePoints.ToString();
            spawnTimer.StopAllCoroutines();//������������� ��� �������� � ������������
            yield return new WaitForSeconds(FreezeTime);//����� ��������� ������ ����� ���������
            StartCoroutine(spawnTimer.WaitAndSpawn());//�������� ����� �������� � ������������
        }
    }

    public void TaskOnClickClear()
    {
        if (ClearPoints >= 1)
        {
            ClearPoints--;
            ClearPointsText.text = ClearPoints.ToString();
            var clones = GameObject.FindGameObjectsWithTag("clone");
            foreach (var clone in clones)
            {
                Destroy(clone);
            }
        }
    }
}
