using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsCount : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public int bullets = 30;
    public int magazineCapacity = 30;
    public float reloadTime = 2.0f;
    private bool isReloading = false;
    public Text ammoText;

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
            }
        }

        if (Input.GetKeyDown("r"))
        {
            Reload();
        }

        UpdateAmmoText();
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletSpawnPoint.position, bulletSpawnPoint.forward, out hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);
            }
        }

        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        bullets--;
    }

    void Reload()
    {
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

    void UpdateAmmoText()
    {
        if (bullets == 0)
        {
            ammoText.text = "Presiona R para recargar";
        }
        else
        {
            ammoText.text = bullets + "/" + magazineCapacity;
        }
    }
}