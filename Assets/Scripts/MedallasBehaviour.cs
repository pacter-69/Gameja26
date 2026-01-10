using System;
using UnityEngine;
using UnityEngine.UI;

public class MedallasBehaviour : MonoBehaviour
{
    public GameObject[] medallas;
    public Sprite negroSprite, medallaSprite;

    private void Update()
    {
        switch (PlayerPrefs.GetInt("Win"))
        {
            case 1:
                medallas[0].GetComponent<Image>().sprite = medallaSprite;
                break;
            case 2:
                medallas[0].GetComponent<Image>().sprite = medallaSprite;
                medallas[1].GetComponent<Image>().sprite = medallaSprite;
                break;
            case 3:
                medallas[0].GetComponent<Image>().sprite = medallaSprite;
                medallas[1].GetComponent<Image>().sprite = medallaSprite;
                medallas[2].GetComponent<Image>().sprite = medallaSprite;
                break;
            case 4:
                medallas[0].GetComponent<Image>().sprite = medallaSprite;
                medallas[1].GetComponent<Image>().sprite = medallaSprite;
                medallas[2].GetComponent<Image>().sprite = medallaSprite;
                medallas[3].GetComponent<Image>().sprite = medallaSprite;
                break;
            case 5:
                medallas[0].GetComponent<Image>().sprite = medallaSprite;
                medallas[1].GetComponent<Image>().sprite = medallaSprite;
                medallas[2].GetComponent<Image>().sprite = medallaSprite;
                medallas[3].GetComponent<Image>().sprite = medallaSprite;
                medallas[4].GetComponent<Image>().sprite = medallaSprite;
                break;
        }
    }
}
