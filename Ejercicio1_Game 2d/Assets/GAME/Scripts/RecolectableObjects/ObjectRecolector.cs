using UnityEngine;

public class ObjectRecolector : MonoBehaviour
{
    // Valor de puntuación otorgado por este objeto recolectable
    public int scoreValue = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Solo reacciona si lo que entró es el jugador
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Objeto recolectado por el jugador");

            if (GameManager.instance != null)
                GameManager.instance.AddScore(scoreValue);

            // Destruye este objeto (la fruta)
            Destroy(gameObject);
        }
    }
}
