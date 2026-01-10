using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalSergio : MonoBehaviour
{
    public List<GameObject> cars; 
    public List<(GameObject car, float dist)> distCars;
    public GameObject goal;
    public GameObject playerCar;
    [SerializeField] public TextMeshProUGUI textUI;  
    void Start()
    {
        // posa els cotxes a la llista type shit
        distCars = new List<(GameObject car, float dist)> {};
        foreach (GameObject car in cars)
        {
            distCars.Add((car, GetDistance(car, goal)));
        }
        distCars.Sort((a, b) => a.dist.CompareTo(b.dist));
    }

    // Update is called once per frame
    void Update()
    {
        //ordena segons la posició la llista en temps real
        for (int i = 0; i < distCars.Count; i++)
        {
            var car = distCars[i].car;
            distCars[i] = (car, GetDistance(car, goal));
        }
        distCars.Sort((a, b) => a.dist.CompareTo(b.dist));
        textUI.text = (distCars.FindIndex(a => a.car == playerCar)+1).ToString();
    }

    float GetDistance(GameObject a, GameObject b)
    {
        if (a.transform.position.y >= b.transform.position.y)
        {
            return 0f;
        }
        return Vector3.Distance (a.transform.position, b.transform.position);
    }
}

