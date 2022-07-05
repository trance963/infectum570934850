using System.Collections;
using System.Collections.Generic;
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
        SceneManager.LoadScene("Game");
        Debug.Log("Start game!");
        Application.Quit();
    }

    public void TaskOnClickHallofGlory()//метод вызова списка редордов
    {

    }

    public void TaskOnClickCredit()//метод вызова окна создателя
    {

    }

    public void TaskOnClickExitGame()//метод выхода
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }
}
