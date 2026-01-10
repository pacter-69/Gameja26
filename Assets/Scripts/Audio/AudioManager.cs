using UnityEngine;
using FMODUnity;
public class AudioManager : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static AudioManager instance {get; private set;}

    public void Awake()
    {
        if (instance == null)
        {
            Debug.LogError("Found more than one AudioManager in the scene.");
        }
        instance = this;
    }

    public void PlayerOneShot (EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
