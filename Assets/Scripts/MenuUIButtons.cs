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
        btn1.onClick.AddListener(TaskOnClickStartGame); // слушатель start
        Button btn2 = HallBut.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickHallofGlory); // слушатель списка рекордов
        Button btn3 = CreditBut.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClickHallofGlory); // слушатель списка рекордов
        Button btn4 = ExitBut.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClickExitGame); // слушатель qiut
    }

    public void TaskOnClickStartGame()//метод старта
    {
        SceneManager.LoadScene(1); //стоит индекс сцены
    }

    public void TaskOnClickHallofGlory()//метод вызова списка редордов
    {
        //в разработке
    }

    public void TaskOnClickCredit()//метод вызова окна создателя
    {
        //в разработке
    }

    public void TaskOnClickExitGame()//метод выхода
    {
        Application.Quit();
    }
}
