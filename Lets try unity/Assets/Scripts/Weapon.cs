using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float bulletSpeed;

    public float shootRate;
    private float lastShootTime;
    private bool isPlayer;

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

        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);

        // Sets the velocity
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
}
