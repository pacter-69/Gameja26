using System;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject[] exclamations;
    private void Start()
    {
        switch (PlayerPrefs.GetInt("PlayerSprite"))
        {
            case 0:
                exclamations[0].SetActive(true);
                break;
            case 1:
                exclamations[1].SetActive(true);
                break;
            case 2:
                exclamations[2].SetActive(true);
                break;
            case 3:
                exclamations[3].SetActive(true);
                break;
            default:
                exclamations[0].SetActive(true);
                break;
        }
    }

    public void Activate(GameObject target)
    {
        target.SetActive(true);
    }
    public void Deactivate(GameObject target)
    {
        target.SetActive(false);
    }
}
