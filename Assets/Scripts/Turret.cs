using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform firePoint;
    public Transform player;
    public GameObject bulletPrefab;
    Vector2 Direction;

    public float shootingDelay;
    public float ShootingInterval;

    public float bulletForce;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", shootingDelay, ShootingInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 targetPos = player.position;
        Direction = targetPos - (Vector2)transform.position;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(Direction * bulletForce);
    }
}
