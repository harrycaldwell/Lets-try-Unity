using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectPool bulletPool;
    public Transform muzzle;            // Spawn position for bullets

    public int curAmmo;                 // Current ammount of ammo
    public int maxAmmo;                 // Max ammount of ammo
    public bool infiniteAmmo;           // Do we have infinite ammo (only for bots)

    public float bulletSpeed;           // Initial velocity of the bullets

    public float shootRate;             // Minimum time between the shots
    private float lastShootTime;        // Last time the player shot a bullet
    private bool isPlayer;              // Is this the players weapon?

    // Start is called before the first frame update
    void Start()
    {
        // Checks if is attached to the player
        if(GetComponent<Player>())
            isPlayer = true;
    }

    // Checks to see if the able to shoot
   public bool CanShoot()
    {
        if(Time.time - lastShootTime >=shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
                return true;
        }

        return false;
    }

    public void Shoot()
    {
        lastShootTime = Time.time;
        curAmmo--;

        GameObject bullet = bulletPool.GetObject();

        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;

        // Sets the velocity
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
}
