using UnityEngine;

public class UISoundReproducer : MonoBehaviour
{
    public void PlaySound()
    {
        AudioManager.instance.PlayerOneShot(FMODEvents.instance.woshProba, this.transform.position);
    }

}
