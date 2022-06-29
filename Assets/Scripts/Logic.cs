using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public enum State // ������� ���������
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

    public void TooMuch() // ����� ������
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Debug.Log("GameOver!");
    }

    public void HundredPoints() // ����� ������
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Debug.Log("YouWon!");
    }
}
