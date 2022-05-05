using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float velocityX = 10f;
    private Rigidbody2D rb;
    
    private const string ENEMY_TAG = "Enemy";

    
    private const int ENEMIGO = 8;
    private GameController _game;
    private PlayerController _player;
   

    private int contador ;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _game = FindObjectOfType<GameController>();
        _player = FindObjectOfType<PlayerController>();
        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
           _game.DisminuyeVidasENemigo(1); 
       
           Destroy(this.gameObject);
           
           Debug.Log("Vidas enemigo"+ _game.vidasenemigo);
            //Destroy(other.gameObject);
        }
        
        if (_game.vidasenemigo <= 0)
        {
            _game.DisminuyeEnemigos(1);
            Debug.Log("Vidas cero");
            Destroy(this.gameObject);
            Destroy(other.gameObject);

            _game.vidasenemigo = 3;
        }
        
        /*  if (_player.simpleBallRight == other.gameObject.layer.Equals(ENEMIGO) )
          {
              
                  vidasEnemigo--;
                  Destroy(this.gameObject);
                  _game.DisminuyeEnemigos(1);
                  Debug.Log("bala pequenia");
              
              
          }  */ 
          
        /*  if (_player.superBallRight == other.gameObject.layer.Equals(ENEMIGO) )
          {
              vidasEnemigo -=2;
                  Destroy(this.gameObject);
                  _game.DisminuyeEnemigos(1);
                  Debug.Log("bala super");
  
          }  */ 

       
    }
}
