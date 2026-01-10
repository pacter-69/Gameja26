using UnityEngine;

public class MenuCars : MonoBehaviour
{
    public Sprite[] cars;

    public int speed;

    public Transform minX, maxX, minY, maxY;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);

        if (transform.position.y > maxY.transform.position.y)
        {
            GetComponent<SpriteRenderer>().sprite = cars[Random.Range(0, cars.Length)];
            float x = Random.Range(minX.transform.position.x, maxX.transform.position.x);
            speed = Random.Range(7, 20);
            transform.position = new Vector2(x, minY.transform.position.y);
        }
    }
}
