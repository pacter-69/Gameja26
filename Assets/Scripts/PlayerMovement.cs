using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1, increaseSpeed = 1, boostSpeed = 1;
    public int lane = 0;
    public int trackPosition;
    public bool canBoost = true, unboost = false;
    public float boostTimer, cooldown;
    public GameObject boostSprite;
    public Animator playerAnimator;
    
    public InputActionReference upAction;
    public InputActionReference leftAction;
    public InputActionReference rightAction;
    public InputActionReference boostAction;

    private float timerAnimation = 0;

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
        if (playerAnimator.GetBool("Frenar"))
        {
            timerAnimation += Time.deltaTime;
            if (timerAnimation >= 1)
            {
                playerAnimator.SetBool("Frenar", false);
                timerAnimation = 0;
            }
        }
        if (playerAnimator.GetBool("Accelerar"))
        {
            timerAnimation += Time.deltaTime;
            if (timerAnimation >= 1)
            {
                playerAnimator.SetBool("Accelerar", false);
                timerAnimation = 0;
            }
        }
        
    }

    void Movement()
    {
        if (speed < 1)
        {
            speed = 1;
        }
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
        playerAnimator.SetBool("Accelerar", true);
        if (boostAction.action.WasPressedThisFrame() && canBoost)
        {
            speed += boostSpeed;
            canBoost = false;
            boostTimer = 0;
            boostSprite.GetComponent<RawImage>().color = new Color(1, 1, 1, 0.2f);
        }
        if (!canBoost && !unboost)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= cooldown)
            {
                boostTimer = 0;
                speed -= boostSpeed;
                unboost = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Llave"))
        {
            canBoost = true;
            unboost = false;
            Debug.Log("LLAVE");
            boostSprite.GetComponent<RawImage>().color = new Color(1, 1, 1, 1f);
        }
    }
}
