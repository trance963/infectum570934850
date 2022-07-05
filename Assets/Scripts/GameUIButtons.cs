using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameUIButtons : MonoBehaviour
{
    public GameObject RestartBut;
    public GameObject MenuBut;
    public Text Text;

    void Start()
    {
        Button btn1 = RestartBut.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClickRestart); // слушатель restart
        Button btn2 = MenuBut.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickMenu); // слушатель menu
    }

    public void Update()
    {
        GameObject go = GameObject.Find("Game");//находим владельца счетчика
        SpawnTimer spawnTimer = go.GetComponent<SpawnTimer>();// получаем переменную из гейм
        Text.text = spawnTimer.HowMuchKills.ToString();
    }

    public void TaskOnClickRestart()//метод рестарта текущей сцены
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart!");
    }

    public void TaskOnClickMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Menu!");
    }
}
