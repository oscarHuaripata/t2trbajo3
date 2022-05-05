using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDos : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float velocityX = 2f;
    
    public GameObject EnemigoNinjaDos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine("Esperar");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
    
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("paso 5 segundos");
       
        var zombie =   EnemigoNinjaDos;
        var position = new Vector2(-11.55f, -2.45f);
        var rotation = EnemigoNinjaDos.transform.rotation;
        
        Instantiate(zombie, position, rotation);
    }
}
