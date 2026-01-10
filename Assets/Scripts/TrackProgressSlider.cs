using UnityEngine;
using UnityEngine.UI;

public class TrackProgressSlider : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public Transform player;
    public Slider progressSlider;

    void Update()
    {
        if (!startPoint || !endPoint || !player || !progressSlider) return;

        float trackLength = endPoint.position.y - startPoint.position.y;
        if (Mathf.Abs(trackLength) < 0.0001f) return;

        float progress = (player.position.y - startPoint.position.y) / trackLength;

        // Clamp between 0 and 1
        progressSlider.value = Mathf.Clamp01(progress);

        Debug.Log("Progress: " + progressSlider.value);
    }
}