using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{
    public List<GameObject> cars = new List<GameObject>();
    private bool raceFinished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject root = other.transform.root.gameObject;

        if (root.CompareTag("Player") || root.CompareTag("Car"))
        {
            if (!cars.Contains(root))
            {
                cars.Add(root);
            }

            if (root.CompareTag("Player") && !raceFinished)
            {
                raceFinished = true;

                int playerPosition = cars.IndexOf(root) + 1;

                Debug.Log("Player finished at position: " + playerPosition);

                if (playerPosition == 2)
                {
                    Debug.Log("WIN! Player finished 2nd!");
                }
                else
                {
                    Debug.Log("LOSE! Player finished " + playerPosition + "th");
                }
            }
        }
    }
}