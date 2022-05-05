using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;
    
    private const int Idle = 0;
    private const int Run = 1;
    private const int Jump = 2;
    private const int Slide = 3;
    private const int Dead  = 4;
    private const int Shoot = 5;
    private const int RunShot = 6;
   
    /// ////////////////////////////////////////////////////////////////
    
    private bool estaSaltando = false;
    private const int PISO_SALTAR = 6;
    public float velocityX = 7;  //Gravity Scale  7
    public float jumpForce = 30;

    private float ChangeTime = 0;

    private const int ENEMIGO = 8;
    
    private  const int EnemigoChoca = 13;
    
    private const int LLAVE = 10;
    private const int LLAVEFINAL = 11;
    
    /// balassss ///////////////////////////////
    public GameObject simpleBallRight;
    public GameObject simpleBallLeft;
    public GameObject superBallRight;
    public GameObject superBallLeft;
    /// balassss ///////////////////////////////
    
    private GameController _game;

    private int contadorSimpleBall;

    private int contadorSuperBall;
    
   
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        _game = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
       CambiarAnimacion(Idle); 
       if (Input.GetKey(KeyCode.RightArrow))
       {
           rb.velocity = new Vector2(velocityX, rb.velocity.y);
           sr.flipX = false;
           CambiarAnimacion(Run);
       }
       else if (Input.GetKey(KeyCode.LeftArrow))
       {
           rb.velocity = new Vector2(- velocityX, rb.velocity.y);
           sr.flipX = true;
           CambiarAnimacion(Run);
       }
       else
       {
           rb.velocity = new Vector2(0, rb.velocity.y);
       }

       if (Input.GetKeyUp(KeyCode.Space) && !estaSaltando)
       {
           rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
           CambiarAnimacion(Jump);
           estaSaltando = true;
           
       }
       
       if (Input.GetKey(KeyCode.C))
       {
           CambiarAnimacion(Slide);
       }
       
       if (Input.GetKey(KeyCode.X))
       {
           CambiarAnimacion(Shoot);
       }
       
       if (Input.GetKey(KeyCode.A))
       {
           CambiarAnimacion(RunShot);
       }


       if (Input.GetKey(KeyCode.G))
       {
           ChangeTime += Time.deltaTime;
       }

       if (Input.GetKeyUp(KeyCode.G))
       {
           if (ChangeTime < 1)
           {
               var bullet = sr.flipX ? simpleBallLeft : simpleBallRight;
               var position = new Vector2(transform.position.x, transform.position.y);
               var rotation = simpleBallRight.transform.rotation;
               Instantiate(bullet, position, rotation);
               //Instanciar simple ball
           }
           else if (ChangeTime < 3)
           {
               var bullet = sr.flipX ? superBallLeft : superBallRight;
               var position = new Vector2(transform.position.x, transform.position.y);
               var rotation = superBallRight.transform.rotation;
               Instantiate(bullet, position, rotation);
               //instanciar super ball
           }
           
           ChangeTime = 0;
       }

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == PISO_SALTAR)
            estaSaltando = false;

        if (other.gameObject.layer == LLAVEFINAL)
        {
            Time.timeScale = 0;
            Debug.Log("--------------JUEGO FINALIZADO" );
        }
        

        if (other.gameObject.layer == LLAVE)
        {
            SceneManager.LoadScene("Escena2");
        }

       

        if (other.gameObject.layer == EnemigoChoca)
        {
            _game.DisminuyeVidasJugador(1);
            _game.DisminuyeEnemigos(1);
            Destroy(other.gameObject);
        }

        if (_game.VidasPlayer <= 0)
        {
            CambiarAnimacion(Dead);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        
        
        
    }

    
      
   

    private void OnTriggerEnter2D(Collider2D other)
    {
      
    }

    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }
}
