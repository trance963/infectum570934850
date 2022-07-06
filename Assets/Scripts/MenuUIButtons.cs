using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIButtons : MonoBehaviour
{
    public GameObject StartBut;
    public GameObject HallBut;
    public GameObject CreditBut;
    public GameObject ExitBut;

    void Start()
    {
        Button btn1 = StartBut.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClickStartGame); // ��������� start
        Button btn2 = HallBut.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickHallofGlory); // ��������� ������ ��������
        Button btn3 = CreditBut.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClickHallofGlory); // ��������� ������ ��������
        Button btn4 = ExitBut.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClickExitGame); // ��������� qiut
    }

    public void TaskOnClickStartGame()//����� ������
    {
        SceneManager.LoadScene(1); //����� ������ �����
    }

    public void TaskOnClickHallofGlory()//����� ������ ������ ��������
    {
        //� ����������
    }

    public void TaskOnClickCredit()//����� ������ ���� ���������
    {
        //� ����������
    }

    public void TaskOnClickExitGame()//����� ������
    {
        Application.Quit();
    }
}
