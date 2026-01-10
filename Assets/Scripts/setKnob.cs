using UnityEngine;
using UnityEngine.UI;

public class setKnob : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
    }

    void Update()
    {
        GetComponent<Image>().sprite = player.gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}
