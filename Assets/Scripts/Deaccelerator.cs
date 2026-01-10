using UnityEngine;

public class Deaccelerator : MonoBehaviour
{
    public float deacceleratorMultiplicator;
    public int deacceleratorValue;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Car"))
        {
            other.gameObject.GetComponent<NPCmovement>().acceleration = deacceleratorMultiplicator;
            other.gameObject.GetComponent<NPCmovement>().timeToChangeAcceleration = 2f;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().speed += deacceleratorValue * Time.deltaTime;
        }
    }
}
