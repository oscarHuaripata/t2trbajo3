using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text VidasJugador;
    public Text CantidadEnemigos;

    public int VidasPlayer = 3;

    private int CantidadEnemy = 5;

    public int vidasenemigo = 3;
    // Start is called before the first frame update
    void Start()
    {
        VidasJugador.text = "Vidas Jugador: "  + VidasPlayer;
        CantidadEnemigos.text = "Cantidad Enemigos: " + CantidadEnemy;
    }

    // Update is called once per frame
    public int GetVidasPlayer()
    {
        return VidasPlayer;
    }
    public int GetCantidadEnemy()
    {
        return CantidadEnemy;
    }

    public int Getvidasenemigo()
    {
        return vidasenemigo;
    }

    public void DisminuyeVidasENemigo(int score)
    {
        vidasenemigo -= score;
    }
    
    public void DisminuyeVidasJugador(int score)
    {
        VidasPlayer -= score;
        VidasJugador.text = "Vidas Jugador: " + VidasPlayer;
    }

    public void DisminuyeEnemigos(int score)
    {
        CantidadEnemy -= score;
        CantidadEnemigos.text = "Cantidad Enemigos: " + CantidadEnemy;
    }
}
