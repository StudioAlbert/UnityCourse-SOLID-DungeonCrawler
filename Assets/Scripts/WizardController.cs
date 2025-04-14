using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WizardController : MonoBehaviour
{
    public float speed = 5f;
    public int health = 100;
    public GameObject fireballPrefab;
    public Transform firePoint;
    public TMP_Text healthText;

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CastFireball();
        }
        UpdateUI();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h, 0, v) * (speed * Time.deltaTime));
    }

    void CastFireball()
    {
        GameObject fireBall = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        if(fireBall.TryGetComponent(out Rigidbody2D rb))
        {
            rb.AddForce(transform.right * 100, ForceMode2D.Force);
        }
    }

    void UpdateUI()
    {
        if (healthText != null)
            healthText.text = "HP: " + health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Wizard is dead!");
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        // Simplified: assuming all harmful objects have tag "Enemy" or "EnemyProjectile"
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyProjectile"))
        {
            TakeDamage(10); // Fixed damage for demo
        }
    }
}
