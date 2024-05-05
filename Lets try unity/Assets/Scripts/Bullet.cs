using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /*
    public int damage;      // Damage the bullet does
    public float lifetime;  // How long the bullet lasts
    private float shootTime;

    void OnEnable()
    {
        shootTime = Time.time;
    }

    void Update()
    {
        // Disables the bullet after "lifetime" (in seconds)
        if (Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
    }
    */
    /*void OnTriggerEnter(Collider other)
    {
        // Was the player hit?
        if (other.CompareTag("Player"))
            other.GetComponent<Player>().TakeDamage(damage);
        else if (other.CompareTag("Enemy"))
            other.GetComponent<Enemy>().TakeDamage(damage);


        // Disables the bullets
        gameObject.SetActive(false) ;
    }
    */
}
