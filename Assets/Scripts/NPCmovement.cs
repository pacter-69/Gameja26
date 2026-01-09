using UnityEngine;

public class NPCmovement : MonoBehaviour
{
    public int currentSpeed = 0;
    const int maxSpeed = 20;
    public int trackPlace;
    public int currentLane;
    
    public enum State
    {
        
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = Random.Range(8, 12);
        currentLane = 4;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, currentSpeed * Time.deltaTime, 0);
        
    }

    public void CheckForLanes()
    {
        
    }
}
