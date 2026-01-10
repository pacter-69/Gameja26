using UnityEngine;
using TMPro;

public class CalculateSpeed : MonoBehaviour
{
    public TMP_Text speedText;
    public GameObject player;

    public Transform agujaVelocimetro;

    public float velocidadMin = 10f;
    public float velocidadMax = 250f;

    public float anguloMin = 90f;
    public float anguloMax = -90f;

    private float speed;
    private float anguloActual;

    public GameObject AnimeSpeed;

    void FixedUpdate()
    {
        // Obtener velocidad del jugador
        speed = player.GetComponent<PlayerMovement>().speed;
        speed *= 10;

        // Mostrar texto
        speedText.text = speed.ToString("F0") + " Km/h";

        // --- VELOCÍMETRO ---
        // Convertir velocidad a 0–1
        float t = Mathf.InverseLerp(velocidadMin, velocidadMax, speed);

        // Calcular ángulo objetivo
        float anguloObjetivo = Mathf.Lerp(anguloMin, anguloMax, t);

        // Suavizar movimiento de la aguja
        anguloActual = Mathf.Lerp(anguloActual, anguloObjetivo, Time.deltaTime * 5f);

        // Aplicar rotación (normalmente eje Z)
        agujaVelocimetro.localEulerAngles = new Vector3(0, 0, anguloActual);

        // sale Animacion speed
        if (speed >= 200)
        {
            AnimeSpeed.SetActive(true);
            Debug.Log("mecago");
        }
        else
        {
            AnimeSpeed.SetActive(false);
        }
    }
}