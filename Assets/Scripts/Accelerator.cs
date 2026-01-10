using System;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    public float acceleratorMultiplicator;
    public int acceleratorValue;
    public Animator acelerar;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Car"))
        {
            other.gameObject.GetComponent<NPCmovement>().acceleration = acceleratorMultiplicator;
            other.gameObject.GetComponent<NPCmovement>().timeToChangeAcceleration = 2f;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            acelerar.SetBool("Accelerar", true);
            other.gameObject.GetComponent<PlayerMovement>().speed += acceleratorValue * Time.deltaTime;
        }
    }
}
