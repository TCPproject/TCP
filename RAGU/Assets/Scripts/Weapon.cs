using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{
    public AudioClip testSound;
    [SerializeField] protected FixedJoystick joystick2;
    [SerializeField] private float timeBtwShoots = 0;
    [SerializeField] private float startTimeBtwShots = 0.2f;
    [SerializeField] protected VariableJoystick joystick1;

    public int damage = 10;
    public Transform firePoint;
    public Transform weapon;
    public GameObject bulletPrefab;
    public float Speed = 10f;
    void Start()
    {
        joystick2 = FindObjectOfType<FixedJoystick>();
        joystick1 = FindObjectOfType<VariableJoystick>();
    }
    void Update()
    {
        float horizontal = joystick2.Horizontal;
        float vertical = joystick2.Vertical;
        var vector = new Vector3(horizontal, vertical, 0);
        if (joystick2.Pressed)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.right, vector);
        }
        if (joystick2.Pressed)
        {
            if (timeBtwShoots <= 0)
            {
                timeBtwShoots = startTimeBtwShots;
                Shoot();
            }
            else
            {
                timeBtwShoots -= Time.deltaTime;
            }
        }

        
        if (!joystick2.Pressed && joystick1.Horizontal > 0)
        {
            weapon.rotation = Quaternion.identity;
        }
        if (!joystick2.Pressed && joystick1.Horizontal < 0)
        {
            weapon.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (!joystick2.Pressed && joystick2.Horizontal < 0)
        {
            weapon.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (!joystick2.Pressed && !joystick1.Pressed)
        {
            weapon.rotation = Quaternion.identity;
        }
    }
    void Shoot()
    {
        Vector3 lookVec = new Vector3(joystick2.Horizontal, joystick2.Vertical, 4000);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); // firepoint.rotation
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * Speed, ForceMode2D.Impulse);
        AudioSource.PlayClipAtPoint(testSound, rb.position);
    }
}