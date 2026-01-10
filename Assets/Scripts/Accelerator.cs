using UnityEngine;

public class Accelerator : MonoBehaviour
{
    public int acceleratorValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
        else if (other.CompareTag("Car"))
        {
            
        }
    }
}
