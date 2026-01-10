using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{
    public List<GameObject> cars = new List<GameObject>();
    private bool raceFinished = false;
    public GameObject winPanel, losePanel;
    public GameObject goalSergio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject root = other.transform.root.gameObject;

        if (root.CompareTag("Player") || root.CompareTag("Car"))
        {
            Debug.Log(root.name);
            if (!cars.Contains(root))
            {
                cars.Add(root);
            }

            if (root.CompareTag("Player") && !raceFinished)
            {
                raceFinished = true;
                goalSergio.SetActive(false);

                int playerPosition = cars.IndexOf(root) + 1;

                Debug.Log("Player finished at position: " + playerPosition);
                
                if (playerPosition == 2)
                {
                    PlayerPrefs.SetInt("Win", PlayerPrefs.GetInt("Win") + 1);
                    winPanel.SetActive(true);
                }
                else
                {
                    Debug.Log("LOSE! Player finished " + playerPosition + "th");
                    losePanel.SetActive(true);
                }
                
                root.GetComponent<PlayerMovement>().enabled = false;
            }
        }
    }
}