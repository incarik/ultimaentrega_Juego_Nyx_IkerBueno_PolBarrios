using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public delegate void CoinCollected();
    public static event CoinCollected OnCoinCollected;

    AudioSource source;
    public AudioClip coin;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            source.PlayOneShot(coin);
            // Notifica a todos los suscriptores que la moneda ha sido recolectada
            OnCoinCollected?.Invoke();
            Destroy(gameObject, 0.5f);
        }
    }
}