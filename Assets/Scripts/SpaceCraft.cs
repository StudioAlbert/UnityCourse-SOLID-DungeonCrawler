using UnityEngine;
using UnityEngine.UI;

public class Spacecraft : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotateSpeed = 25f;
    [SerializeField] private int health = 100;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Text healthText;

    void Update()
    {
        Move();
        Shoot();
        UpdateUI();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector3(0, 0, v) * (speed * Time.deltaTime));
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laserPrefab, firePoint.position, Quaternion.identity);
        }
    }

    void UpdateUI()
    {
        healthText.text = "HP: " + health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
