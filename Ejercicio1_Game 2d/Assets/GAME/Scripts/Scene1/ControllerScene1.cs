using UnityEngine;
using TMPro;

public class ControllerScene1 : MonoBehaviour
{
    // Texto del panel donde se muestra el puntaje
    public TextMeshProUGUI scoreText;

    // Timer de la escena 1 (el que está en PanelTiempo)
    public Timer timerScene1;

    // Evita que el tiempo se envíe más de una vez
    private bool timeSent = false;

    void Update()
    {
        if (GameManager.instance != null)
        {
            scoreText.text = "Score: " + GameManager.instance.Score;
            SendTime();
        }
    }

    public void SendTime()
    {
        if (!timeSent && GameManager.instance.Score >= 100)
        {
            timerScene1.TimerStop();                 // 1. parar el tiempo
            float time = timerScene1.StopTime;       // 2. obtener el tiempo
            GameManager.instance.AddTime(time);      // 3. enviarlo al Game Manager
            timeSent = true;
        }
    }
}
