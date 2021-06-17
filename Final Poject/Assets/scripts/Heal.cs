using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
   public int healthAmount = 25; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.tag == "Player")
        {
        PlayerMovement.instance.AddHealth(healthAmount);

        
        Destroy(gameObject);
        }
    }
}
