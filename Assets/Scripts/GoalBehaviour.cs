using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{
    public List<GameObject> cars;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player")) || (other.gameObject.CompareTag("Car")))
        {
            cars.Add(other.gameObject);
        }

        if (cars.Count > 0)
        {
            if (other.gameObject.CompareTag("Player") && cars[1].CompareTag("Player"))
            {
                Debug.Log("WIN, player is second");
            }
        }
    }
}
