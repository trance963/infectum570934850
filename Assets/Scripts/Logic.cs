using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public enum State // игровые состояния
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    void Start()
    {
        CurrentState = State.Playing;
    }

    public void TooMuch() // метод смерти
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Debug.Log("GameOver!");
    }

    public void HundredPoints() // метод финиша
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Debug.Log("YouWon!");
    }
}
