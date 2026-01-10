using UnityEngine;

public class LinesCreditBehaviour : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().position = new Vector2(GetComponent<RectTransform>().position.x - 3 * Time.deltaTime, GetComponent<RectTransform>().position.y);
        Debug.Log(GetComponent<RectTransform>().position.x);
        if (GetComponent<RectTransform>().position.x < -9.5f)
        {
            GetComponent<RectTransform>().position =new Vector2(9.5f, GetComponent<RectTransform>().position.y);
        }
    }
}
