using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Única instancia del Game Manager en todo el juego (Singleton)
    public static GameManager instance;

    private int score = 0;
    public int Score { get => score; set => score = value; }

    // Tiempo total que lleva el jugador sumando todas las escenas
    private float totalTime = 0;
    public float TotalTime { get => totalTime; set => totalTime = value; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // sobrevive al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // solo puede existir uno
        }
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score);
    }

    // Recibe el tiempo de una escena y lo suma al tiempo total
    public void AddTime(float time)
    {
        totalTime += time;
        Debug.Log("Tiempo total: " + totalTime);
    }
}
