using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public GameObject toTrack;
    public float offset;

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, toTrack.transform.position.y + offset, -10);
    }
}
