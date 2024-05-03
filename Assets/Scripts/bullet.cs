using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float bulletSpeed = 6;
    public AudioClip destroySound; // Agrega el sonido que deseas reproducir al destruir algo
    private AudioSource audioSource; // Referencia al AudioSource para reproducir el sonido

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }

    // Método para configurar el AudioSource si es necesario
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            return;
        }
        if (collider.gameObject.tag == "Slime")
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>(); // Obtén el componente Enemy del enemigo
            if (enemy != null)
            {
                enemy.EnemyDeath(); // Llama al método EnemyDeath en el script del enemigo
            }

            // Reproduce el sonido de destrucción si está configurado
            if (destroySound != null && audioSource != null)
            {
                audioSource.PlayOneShot(destroySound);
            }
        }
        Destroy(gameObject);
    }
}
