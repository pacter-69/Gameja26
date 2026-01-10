using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1, increaseSpeed = 1, boostSpeed = 1;
    public int lane = 0;
    public int trackPosition;
    public bool canBoost = true, unboost = false;
    public float boostTimer, cooldown;
    
    public InputActionReference upAction;
    public InputActionReference leftAction;
    public InputActionReference rightAction;
    public InputActionReference boostAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.position = new Vector2(LaneController.laneValues[lane], transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Boost();
    }

    void Movement()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed * Time.deltaTime);
        
        if (upAction.action.IsPressed())
        {
            speed += increaseSpeed * Time.deltaTime;
        }
        
        if (leftAction.action.WasPressedThisFrame())
        {
            if (LaneController.CanMove(-1, lane))
            {
                lane -= 1;
                ChangeLane();
            }
        }
        if (rightAction.action.WasPressedThisFrame())
        {
            if (LaneController.CanMove(1, lane))
            {
                lane += 1;
                ChangeLane();
            }
        }
    }
    void ChangeLane()
    {
        gameObject.transform.position = new Vector2(LaneController.laneValues[lane], gameObject.transform.position.y);
    }

    void Boost()
    {
        if (boostAction.action.WasPressedThisFrame() && canBoost)
        {
            speed += boostSpeed;
            canBoost = false;
        }

        if (!canBoost && !unboost)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= cooldown)
            {
                speed -= boostSpeed;
                unboost = true;
            }
        }
    }
}
