using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public List<Sprite> sprites;

    public GameObject[] cars;
    
    void Start()
    {
        sprites.RemoveAt(PlayerPrefs.GetInt("PlayerSprite"));
        for (int i = 0; i < sprites.Count; i++)
        {
            cars[i].GetComponent<SpriteRenderer>().sprite = sprites[i];
        }
    }
    
}
