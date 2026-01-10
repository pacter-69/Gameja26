using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public List<Sprite> sprites;
    public GameObject playerCars;
    public GameObject[] cars;
    
    void Start()
    {
        cars[0] = (playerCars.transform.GetChild(PlayerPrefs.GetInt("PlayerSprite")).gameObject);
        sprites.RemoveAt(PlayerPrefs.GetInt("PlayerSprite"));
        for (int i = 0; i < sprites.Count; i++)
        {
            cars[i].GetComponent<SpriteRenderer>().sprite = sprites[i];
        }
    }
    
}
