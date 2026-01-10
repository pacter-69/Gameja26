using UnityEngine;

public class SpriteSetter : MonoBehaviour
{
    public Sprite[] sprites;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("PlayerSprite")];
    }
}
