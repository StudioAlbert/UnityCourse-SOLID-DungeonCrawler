using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Loot : MonoBehaviour
{
    [SerializeField] private GameObject potion; 
    [SerializeField] private GameObject weapon; 
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            DropLoot();
    }
    
    private void DropLoot()
    {
        if (Random.value > 0.5f)
            Instantiate(potion, transform.position, transform.rotation);
        else
            Instantiate(weapon, transform.position, transform.rotation);

        GetComponent<Collider2D>().enabled = false;

    }
}
