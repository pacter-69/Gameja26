using UnityEngine;

public class NPCmovement : MonoBehaviour
{
    [Header("Speed")]
    public float currentSpeed;
    public float acceleration;
    private float accelerationTimer;
    public float timeToChangeAcceleration;
    
    [Header("Lane and track place")]
    public int trackPlace;
    public int currentLane;

    [Header("Lane debug and variables")]
    [SerializeField] private float laneTimer;
    public float laneChangeCooldown;

    [Header("Crash")]
    [SerializeField] private bool hasCrashed;
    public bool playerLeft, playerRight;
    private float crashedTimer;
    private GameObject carToCrashInto;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = Random.Range(11, 14);
        InternalMoveLaneBy(0);
        laneTimer = 0;
        laneChangeCooldown = Random.Range(0.6f, 2f);
        acceleration = 1;
    }

    public void setCarToCrashInto(GameObject g)
    {
        carToCrashInto = g;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, currentSpeed * Time.deltaTime * acceleration, 0);
        switch (CheckForLanes())
        {
            case -1:
                InternalMoveLaneBy(-1);
                break;
            case 1:
                InternalMoveLaneBy(1);
                break;
            case 0:
                InternalMoveLaneBy(Random.Range(-1, 2));
                break;
            case -2:
                break;
        }
        
        accelerationTimer += Time.deltaTime;
        if (accelerationTimer >= timeToChangeAcceleration)
        {
            acceleration = Random.Range(0.8f, 1.3f);
            accelerationTimer = 0;
            if (timeToChangeAcceleration >= 1f)
            {
                timeToChangeAcceleration = 1f;
            }
        }

        if (hasCrashed)
        {
            accelerationTimer = 0.8f;
            accelerationTimer = 0;
            crashedTimer += Time.deltaTime;
            if (crashedTimer >= 1f)
            {
                hasCrashed = false;
                crashedTimer = 0f;
            }
        }
    }

    public int CheckForLanes()
    {
        laneTimer += Time.deltaTime;
        if (laneTimer >= laneChangeCooldown)
        {
            laneTimer = 0;
            laneChangeCooldown = Random.Range(0.6f, 2f);
            if (LaneController.CanMove(currentLane, -1) && LaneController.CanMove(currentLane, 1)) return 0; // This return means it can go to either direction
            if (LaneController.CanMove(currentLane, -1)) return -1; // This return means it can only go to the left
            if (LaneController.CanMove(currentLane, 1)) return 1; // This return means it can only go to the right
        }
        return -2; // This return means the cooldown hasn't ended yet
    }

    private void InternalMoveLaneBy(int whereToMove)
    {
        transform.position = new Vector3(LaneController.laneValues[currentLane + whereToMove], transform.position.y, transform.position.z);
        currentLane += whereToMove;
        laneTimer = 0;
    }

    private void InternalMoveLaneBy(int whereToMove, GameObject carToCrash)
    {
        if (whereToMove != -1 && playerLeft)
        {
            Debug.LogWarning("Warning");
            if (carToCrash.CompareTag("Car"))
            {
                carToCrash.GetComponent<NPCmovement>().MoveLaneBy(whereToMove);
            }
            hasCrashed = true;
        }
        else if (whereToMove != -1 && playerRight)
        {
            Debug.LogWarning("Warning");
            if (carToCrash.CompareTag("Car"))
            {
                carToCrash.GetComponent<NPCmovement>().MoveLaneBy(whereToMove);
            }
            hasCrashed = true;
        }
        else if(LaneController.CanMove(whereToMove, currentLane))
        {
            InternalMoveLaneBy(whereToMove);
        }
        
    }

    public void MoveLaneBy(int whereToMove)
    {
        InternalMoveLaneBy(whereToMove, carToCrashInto);
    }

    public void ForceMoveLaneBy(int whereToMove)
    {
        int laneCheck = CheckForLanes();
        if (whereToMove == 2)
        {
            if (laneCheck == 0)
            {
                laneTimer = 0;
                switch (Random.Range(0, 2))
                {
                    case 0:
                        InternalMoveLaneBy(-1);
                        break;
                    case 1:
                        InternalMoveLaneBy(1);
                        break;
                }
            }
            else if (laneCheck != -2)
            {
                laneTimer = 0;
                InternalMoveLaneBy(laneCheck);
            }
        }
        else
        {
            laneTimer = 0;
            InternalMoveLaneBy(whereToMove);
        }
    }
}
