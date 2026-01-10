using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public GameObject toTrack; 

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, toTrack.transform.position.y, -10);
    }
}
