using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIButtons : MonoBehaviour
{
    public SpawnTimer spawnTimer; //пришлось сделать привязанным ГО, что бы сделать код поаккуратнее
    public GameObject RestartBut;
    public GameObject MenuBut;
    public GameObject FreezeBut;
    public int FreezeTime;//переменная времени бустера заморозки
    public int FreezePoints;
    public int ClearPoints;//количество бустеров
    public GameObject ClearBut;
    public Text HowMuchKillsText;
    public Text FreezePointsText;
    public Text ClearPointsText;

    void Start()
    {
        Button btn1 = RestartBut.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClickRestart); // слушатель restart
        Button btn2 = MenuBut.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickMenu); // слушатель menu
        Button btn3 = FreezeBut.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClickFreeze); // слушатель freeze
        Button btn4 = ClearBut.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClickClear); // слушатель freeze
        HowMuchKillsText.text = spawnTimer.HowMuchKills.ToString();//преобразуем в текст
        FreezePointsText.text = FreezePoints.ToString();
        ClearPointsText.text = ClearPoints.ToString();
    }

    private void Update()
    {
        HowMuchKillsText.text = spawnTimer.HowMuchKills.ToString();//она особенная, т.к. обменивается с жертвами, пришлось положить сюда. остальные ту стринг обновляются в своих функциях
    }

    public void TaskOnClickRestart()//метод рестарта текущей сцены
    {
        SceneManager.LoadScene(1);//здесь тоже индекс
    }

    public void TaskOnClickMenu()
    {
        SceneManager.LoadScene(0);//индекс
    }

    public void TaskOnClickFreeze()
    {
        StartCoroutine(FreezeSpawn());
    }

    public IEnumerator FreezeSpawn() //счетчик времени между спавнами
    {
        if (FreezePoints >= 1)
        {
            FreezePoints--;
            FreezePointsText.text = FreezePoints.ToString();
            spawnTimer.StopAllCoroutines();//останавливаем ВСЕ корутины в спавнтаймере
            yield return new WaitForSeconds(FreezeTime);//через инспектор задаем время заморозки
            StartCoroutine(spawnTimer.WaitAndSpawn());//включаем снова корутину в спавнтаймере
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
