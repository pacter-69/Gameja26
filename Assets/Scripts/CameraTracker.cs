using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    private GameObject toTrack;
    public float offset;
    public GameObject players;

    void Start()
    {
        toTrack = players.transform.GetChild(PlayerPrefs.GetInt("PlayerSprite")).gameObject;
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, toTrack.transform.position.y + offset, -10);
    }
}
