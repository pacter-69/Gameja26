using UnityEngine;
using FMODUnity;
public class FMODEvents : MonoBehaviour
{

    [field: Header("Wosh Proba")]
    [field: SerializeField] public EventReference woshProba { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static FMODEvents instance { get; private set; }

    public void Awake()
    {
        if (instance == null)
        {
            Debug.LogError("Found more than one FMODEvents in the scene.");
        }
        instance = this;
    }

}
