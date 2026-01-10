using TMPro;
using UnityEngine;

public class CalculateSpeed : MonoBehaviour
{
    public TMP_Text speedText;
    public GameObject player;
    Vector3 lastPosition = Vector3.zero;
    public float speed;
        void FixedUpdate()
        {
            speed = player.GetComponent<PlayerMovement>().speed;
            speed *= 10;
            speedText.text = (speed.ToString("F0") + " Km/h");
        }
}
