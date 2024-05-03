using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text scoreText;
    private int score;

    void Start()
    {
        LoadScore();
        // Suscribe la función CoinCollected a OnCoinCollected
        Coin.OnCoinCollected += CoinCollected;

        // Suscribe la función EnemyDestroyedHandler a OnEnemyDestroyed
        Enemy.OnEnemyDestroyed += EnemyDestroyedHandler;
    }

    void Update()
    {
        // Actualiza el texto de la puntuación en cada frame
        UpdateScoreText();
    }

    void LoadScore()
    {
        // Carga la puntuación desde algún lugar, si es necesario.
        // Por ejemplo, desde un archivo guardado o una base de datos.
        // Aquí simplemente inicializamos la puntuación a cero.
        score = 0;
    }

    void UpdateScoreText()
    {
        // Actualiza el texto con la puntuación actual
        scoreText.text = "Puntuación: " + score.ToString();
    }

    void CoinCollected()
    {
        // Incrementa la puntuación cuando se notifica que una moneda ha sido recolectada
        score++;
    }

    void EnemyDestroyedHandler()
    {
        // Incrementa la puntuación cuando se notifica que un enemigo ha sido destruido
        score++;
    }

    public void LoadFirstLevel()
    {
        // Carga el primer nivel
        SceneManager.LoadScene("Nivel 1");
    }

    // Asegúrate de desuscribir la función CoinCollected y EnemyDestroyedHandler cuando el script se destruye
    private void OnDestroy()
    {
        Coin.OnCoinCollected -= CoinCollected;
        Enemy.OnEnemyDestroyed -= EnemyDestroyedHandler;
    }
}