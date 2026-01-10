using UnityEngine;

public class CarChooser : MonoBehaviour
{
    public void ChooseSprite(int carNum)
    {
        PlayerPrefs.SetInt("PlayerSprite", carNum);
    }
}
