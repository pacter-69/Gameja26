using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    private GameObject toTrack;
    public float offset;
    public GameObject[] player;

    void Start()
    {
        toTrack = player[PlayerPrefs.GetInt("PlayerSprite")];
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, toTrack.transform.position.y + offset, -10);
    }
}
