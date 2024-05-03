using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rBody;
    public float enemySpeed = 2;
    private float enemyDirection = 1;
    public Animator anim;
    private AudioSource source;
    public AudioClip deathSound;
    public AudioClip playerDeathSound;
    private BoxCollider2D boxCollider;

    public delegate void EnemyDestroyed();
    public static event EnemyDestroyed OnEnemyDestroyed;

    // Start is called before the first frame update
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rBody.velocity = new Vector2(enemyDirection * enemySpeed, rBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3 || collision.gameObject.tag == "Slime")
        {
            // Cambia la dirección del enemigo
            enemyDirection *= -1;

            // Invierte la escala horizontal del sprite para reflejar el cambio de dirección
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        if (collision.gameObject.tag == "Player")
        {
            PlayerMove player = collision.gameObject.GetComponent<PlayerMove>(); // Obtén el componente PlayerMove del jugador
            if (player != null)
            {
                //player.PlayerDeath(); // Llama al método PlayerDeath en el script del jugador
                player.StartCoroutine("Die");
            }
            //source.PlayOneShot(playerDeathSound);
            //SceneManager.LoadScene("Game over");
        }
    }

    public void EnemyDeath()
    {
        source.PlayOneShot(deathSound); // Reproduce el sonido cuando el slime muere
        boxCollider.enabled = false;
        rBody.gravityScale = 0;
        enemyDirection = 0;
        Destroy(gameObject, 0.5f);

        // Notificar al MenuManager que el enemigo ha sido destruido
        if (OnEnemyDestroyed != null)
        {
            OnEnemyDestroyed();
        }
    }
}