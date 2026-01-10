using UnityEngine;

public class SetPlayer : MonoBehaviour
{
    
    void Start()
    {
        transform.GetChild(PlayerPrefs.GetInt("PlayerSprite")).gameObject.SetActive(true);
    }

}
