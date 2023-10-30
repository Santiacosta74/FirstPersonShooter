using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public int bullets = 30;
    public int magazineCapacity = 30;
    public float reloadTime = 2.0f;
    private bool isReloading = false;

    private void Update()
    {
        if (!isReloading)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (bullets > 0)
                {
                    Shoot();
                }
                else if (bullets == 0)
                {
                    Reload();
                }
            }
        }

        if (Input.GetKeyDown("r"))
        {
            Reload();
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        bullets--;
    }

    void Reload()
    {
        // Lógica para recargar.
        if (bullets < magazineCapacity)
        {
            isReloading = true;
            bullets = magazineCapacity;
            StartCoroutine(StartReload());
        }
    }

    IEnumerator StartReload()
    {
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }
}