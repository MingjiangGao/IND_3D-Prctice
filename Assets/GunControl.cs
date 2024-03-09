using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public Transform muzzlePoint;
    public float bulletSpeed = 10f;
    public float MinbulletSpeed = 5f;
    public float MaxbulletSpeed = 50f;
    public float scrollSpeed = 2f;
    public float bulletLifeSpan = 20f;
    public float scrollInput = 0;

    public GameManager gameManager;

    void Update()
    {
        ////the speed adjustment 
        scrollInput = Input.GetAxis("Mouse ScrollWheel");
        bulletSpeed += scrollInput * scrollSpeed;
        bulletSpeed = Mathf.Clamp(bulletSpeed, MinbulletSpeed, MaxbulletSpeed);

        ////the shooting
        if (!gameManager.IsGameFrozen() && Input.GetButtonDown("Fire1"))
        {
            Shoot(bulletPrefab);
        }
        if (!gameManager.IsGameFrozen() && Input.GetButtonDown("Fire2"))
        {
            Shoot(bulletPrefab2);
        }
    }

    void Shoot(GameObject bulletType)
    {
        GameObject bullet = Instantiate(bulletType, muzzlePoint.position, muzzlePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        
        if (bulletRb != null)
        {
            bulletRb.velocity = muzzlePoint.forward * bulletSpeed;
            StartCoroutine(DestroyBullet(bullet, bulletLifeSpan));
        }
    }

    IEnumerator DestroyBullet(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
