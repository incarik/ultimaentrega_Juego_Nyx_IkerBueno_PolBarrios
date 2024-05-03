using UnityEngine;
using UnityEngine.SceneManagement;

public class muertesuelo : MonoBehaviour
{
    private AudioSource source;
    public AudioClip deathSound;
    public AudioClip playerDeathSound;
    private BoxCollider2D boxCollider;

    void Start()
    {
        // Obtener el componente AudioSource adjunto al objeto
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMove player = collision.gameObject.GetComponent<PlayerMove>(); // Obtener el componente PlayerMove del jugador
            if (player != null)
            {
                //player.PlayerDeath(); // Llamar al método PlayerDeath en el script del jugador
                player.StartCoroutine("Die");
            }
            // Reproducir el sonido de la muerte del jugador
            if (source != null && playerDeathSound != null)
            {
                source.PlayOneShot(playerDeathSound);
            }
            // Cargar la escena de "Game over"
            //SceneManager.LoadScene("Game over");
        }
    }
}
