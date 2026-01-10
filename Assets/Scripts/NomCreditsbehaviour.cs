using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NomCreditsbehaviour : MonoBehaviour
{
    public float speed;

    public float timer, cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(-0.5f, 0.5f);
        cooldown = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

        if (transform.position.x > 5 && speed > 0)
        {
            speed = 0;
        }

        if (transform.position.x < -5 && speed < 0)
        {
            speed = 0;
        }
        
        timer += Time.deltaTime;
        if (timer >= cooldown)
        {
            speed = Random.Range(-0.5f, 0.5f);
            cooldown = Random.Range(1f, 3f);
            timer = 0;
        }
    }
}
