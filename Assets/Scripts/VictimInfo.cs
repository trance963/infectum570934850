using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimInfo : MonoBehaviour
{
    public int Health;

    private void Start()
    {
        Health = Random.Range(4,8);
    }

    public void OnMouseDown()
    {
        if (Health <= 1)
        {
            TryGetComponent(out SpawnTimer spawntimer);
            spawntimer.HowMuchVictim--;
            Debug.Log("Victim is dead");
            Health--;
            Destroy(gameObject);
        }

        else
        {
            Health--;
        }
    }
}
