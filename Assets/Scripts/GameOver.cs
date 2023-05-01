using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text winText;
    public GameObject ninaSprite;
    public SFXManager sound;
    // Start is called before the first frame update
    void Start()
    {
        //Animacion final en caso de que el jugador haya ganado
        NinaAnimation();
        if (PlayerPrefs.GetInt("score", 0) >= PlayerPrefs.GetInt("PointsToWin", 3))
        {
            winText.text = "You Win :)";
        }
        //Sonido para la escena final
        sound.EndGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NinaAnimation()
    {
        //animación del sprite de la ultima escena
        ninaSprite.GetComponent<Animator>().SetTrigger("Winning");
    }
}
