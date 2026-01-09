using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 1, speedUp = 2;
    public int lane = 0;
    public int trackPosition;
    
    public InputActionReference upAction;
    public InputActionReference leftAction;
    public InputActionReference rightAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.position = new Vector2(LaneController.laneValues[lane], transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (upAction.action.IsPressed())
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speedUp * Time.deltaTime);
        }
        else
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed * Time.deltaTime);
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
}
