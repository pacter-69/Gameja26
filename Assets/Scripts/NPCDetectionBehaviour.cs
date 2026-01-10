using UnityEngine;

public class NPCDetectionBehaviour : MonoBehaviour
{
    [SerializeField] private int currentTrackPlace;
    private GoalSergio goalManager;
    private System.Random random;
    private GameObject npcObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goalManager = GameObject.Find("GoalSergio").GetComponent<GoalSergio>();
        npcObject = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        currentTrackPlace = goalManager.distCars.FindIndex(t => t.car == transform.parent.gameObject);
        // In the tuple list, search only for the cars and specifically for
        // the car that is equal to the parent of this object (which would be the original NPC object).
        // Then, of this object, return the index and set it as it's "currentTrackPlace", as the car's index in "distCars"
        // is equal to its placement in the race.
        //
        // This should always find an index as GoalSergio has a list with all the integrants of the race.
        Debug.Log("Current Track Place: " + currentTrackPlace + ", " + transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int rnd1;
        if (other.transform.position.y >= GetComponentInParent<Transform>().position.y + 1 && (other.CompareTag("Acc") || other.CompareTag("Deacc")))
        {
            switch (currentTrackPlace)
            {
                case 0:
                    rnd1 = random.Next(101);
                    if (other.CompareTag("Acc"))
                    {
                        if (rnd1 <= random.Next(81))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(2);
                        }
                    }
                    break;
                case 1:
                    rnd1 = random.Next(101);
                    if (other.CompareTag("Acc"))
                    {
                        if (rnd1 <= random.Next(31))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(2);
                        }
                    }
                    else if (other.CompareTag("Deacc"))
                    {
                        rnd1 = random.Next(101);
                        if (rnd1 <= random.Next(31))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(2);
                        }
                    }
                    break;
                case 2:
                    rnd1 = random.Next(101);
                    if (other.CompareTag("Deacc"))
                    {
                        if (rnd1 <= random.Next(81))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(2);
                        }
                    }
                    break;
                case 3:
                    if (other.CompareTag("Deacc"))
                    {
                        npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(2);
                    }
                    break;
                case 4:
                    if (other.CompareTag("Deacc"))
                    {
                        npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(2);
                    }
                    break;
            }


        }
        if (other.transform.position.x >= GetComponentInParent<Transform>().position.x + 0.25 &&
            (other.CompareTag("Acc") || other.CompareTag("Deacc")))
        {
            switch (currentTrackPlace)
            {
                case 0:
                    rnd1 = random.Next(101);
                    if (other.CompareTag("Acc"))
                    {
                        if (rnd1 <= random.Next(21))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(1);
                        }
                    }
                    else if (other.CompareTag("Deacc"))
                    {
                        rnd1 = random.Next(101);
                        if (rnd1 <= random.Next(81))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(1);
                        }
                    }
                    break;
                case 1:
                    rnd1 = random.Next(101);
                    if (other.CompareTag("Acc"))
                    {
                        if (rnd1 <= random.Next(31))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(1);
                        }
                    }
                    else if (other.CompareTag("Deacc"))
                    {
                        rnd1 = random.Next(101);
                        if (rnd1 <= random.Next(31))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(1);
                        }
                    }
                    break;
                case 2:
                    rnd1 = random.Next(101);
                    if (other.CompareTag("Acc"))
                    {
                        if (rnd1 <= random.Next(81))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(1);
                        }
                    }
                    else if (other.CompareTag("Deacc"))
                    {
                        rnd1 = random.Next(101);
                        if (rnd1 <= random.Next(21))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(1);
                        }
                    }
                    break;
                case 3:
                    if (other.CompareTag("Acc"))
                    {
                        npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(1);
                    }
                    break;
                case 4:
                    if (other.CompareTag("Acc"))
                    {
                        npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(1);
                    }
                    break;
            }
        }

        if (other.transform.position.x <= GetComponentInParent<Transform>().position.x - 0.25 &&
            (other.CompareTag("Acc") || other.CompareTag("Deacc")))
        {
            switch (currentTrackPlace)
            {
                case 0:
                    rnd1 = random.Next(101);
                    if (other.CompareTag("Acc"))
                    {
                        if (rnd1 <= random.Next(21))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(-1);
                        }
                    }
                    else if (other.CompareTag("Deacc"))
                    {
                        rnd1 = random.Next(101);
                        if (rnd1 <= random.Next(81))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(-1);
                        }
                    }
                    break;
                case 1:
                    rnd1 = random.Next(101);
                    if (other.CompareTag("Acc"))
                    {
                        if (rnd1 <= random.Next(31))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(-1);
                        }
                    }
                    else if (other.CompareTag("Deacc"))
                    {
                        rnd1 = random.Next(101);
                        if (rnd1 <= random.Next(31))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(-1);
                        }
                    }
                    break;
                case 2:
                    rnd1 = random.Next(101);
                    if (other.CompareTag("Acc"))
                    {
                        if (rnd1 <= random.Next(81))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(-1);
                        }
                    }
                    else if (other.CompareTag("Deacc"))
                    {
                        rnd1 = random.Next(101);
                        if (rnd1 <= random.Next(21))
                        {
                            npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(-1);
                        }
                    }
                    break;
                case 3:
                    if (other.CompareTag("Acc"))
                    {
                        npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(-1);
                    }
                    break;
                case 4:
                    if (other.CompareTag("Acc"))
                    {
                        npcObject.GetComponent<NPCmovement>().ForceMoveLaneBy(-1);
                    }
                    break;
            }
        }
    }
}
