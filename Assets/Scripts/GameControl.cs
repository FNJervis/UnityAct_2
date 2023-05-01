using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    static public GameControl Instance;
    public GameObject BIrd_behaviour;
    public Player_control Player_control;
    public UIController UIController;
    public SFXManager SFXManager;
    //Puntos para ganar el juego
    public int points2win = 7;

    private void Awake()
    {
        //Crear instancia nueva
        PlayerPrefs.SetInt("PointsToWin", points2win);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void checkGameOver(int _currentScore)
    {
        //Funcion para revisar si el jugador obtuvo los puntos suficientes para ganar
        PlayerPrefs.SetInt("score", _currentScore);
        if (_currentScore >= points2win)
        {
            ActiveEndScene();
        }
    }
    public void ActiveEndScene()
    {
        //Cambiar de escena a la escena final
        SceneManager.LoadScene("EndScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
