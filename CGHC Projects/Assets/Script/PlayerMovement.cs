using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject ChargePrefab;
    
    public Rigidbody2D rb;
    public Transform firePoint;

    public float bulletSpeed = 25f;
    public float moveSpeed = 5f;
    public float attackCD;

    public bool shootCD = true;

    public Vector2 movement;
    public Vector2 mousePos;

    public Camera cam;
    private SpriteRenderer rbSprite;
    private float chargetimer;

    private void Start()
    {
        rbSprite = GetComponent<SpriteRenderer>();

        if (firePoint == null)
        {
            Debug.LogError("Fire point is not assigned. Please assign a Transform to the firePoint variable in the Inspector.");
        }
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //bool ChargePress = Input.GetMouseButton(0);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        lookDir.Normalize();

        UpdateRotation(lookDir);
        ShootCoolDown();

        if (shootCD == true)
        {
            Shoot(lookDir);
            attackCD = 0f;

        }

        if (Input.GetMouseButton(0))
        {
            chargetimer += 1f * Time.deltaTime;
            if (chargetimer > 3f)
            {
                ChargeAttack(lookDir);
                chargetimer = 0f;
            }
        }


    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    private void UpdateRotation(Vector2 lookDir)
    {
        // Calculate the angle in degrees
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        if (lookDir.x < 0f)
        {
            rbSprite.flipX = true;
        }
        else
        {
            rbSprite.flipX = false;
        }
    }

    void Shoot(Vector2 direction)
    {
        // Instantiate a projectile at the firePoint position
        GameObject projectile = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Get the Rigidbody2D component of the projectile
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

        // Set the velocity of the projectile to shoot in the calculated direction
        projectileRb.velocity = direction * bulletSpeed;
    }

    void ShootCoolDown()
    {
        if (attackCD < 180)
        {
            shootCD = false;
            attackCD++;
        }
        else
        {
            shootCD = true;
        }
 
    }
    void ChargeAttack(Vector2 direction)
    {
        // Instantiate a projectile at the firePoint position
        GameObject projectile = Instantiate(ChargePrefab, firePoint.position, Quaternion.identity);

        // Get the Rigidbody2D component of the projectile
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

        // Set the velocity of the projectile to shoot in the calculated direction
        projectileRb.velocity = direction * bulletSpeed;
    }

   
}
