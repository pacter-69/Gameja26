using UnityEngine;

public class NPCmovement : MonoBehaviour
{
    [Header("Speed")]
    public float currentSpeed = 0;
    const int maxSpeed = 20;
    public float acceleration;
    private float accelerationTimer;
    public float timeToChangeAcceleration;
    
    [Header("Lane and track place")]
    public int trackPlace;
    public int currentLane;

    [Header("Lane debug and variables")]
    [SerializeField] private float laneTimer;
    public float laneChangeCooldown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = Random.Range(11, 14);
        MoveLaneBy(0);
        laneTimer = 0;
        laneChangeCooldown = Random.Range(0.6f, 2f);
        acceleration = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, currentSpeed * Time.deltaTime * acceleration, 0);
        switch (CheckForLanes())
        {
            case -1:
                MoveLaneBy(-1);
                break;
            case 1:
                MoveLaneBy(1);
                break;
            case 0:
                MoveLaneBy(Random.Range(-1, 2));
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

    public void MoveLaneBy(int whereToMove)
    {
        transform.position = new Vector3(LaneController.laneValues[currentLane + whereToMove], transform.position.y, transform.position.z);
        currentLane += whereToMove;
    }
}
