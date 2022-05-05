using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float velocityX = -2f;
    // Start is called before the first frame update
    
   // public GameObject EnemigoNinja;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
      //  StartCoroutine("Esperar");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
    
  
}
