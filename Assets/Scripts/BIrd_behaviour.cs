using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIrd_behaviour : MonoBehaviour
{
    public BirdName nameBird = BirdName.bird1;

    //Slider para cambiar la cantidad de puntos que otorga cada  pajaro
    [Range(0, 10)] public int points = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Funcion la cual se llama en caso de colision de un objeto pajaro con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            //Añadir puntos, llamar un sonido, destruir el objeto pajaro
            GameControl.Instance.UIController.AddPoints(points);
            GameControl.Instance.SFXManager.getCoin();
            GameObject.Destroy(this.gameObject);
        }
    }
    //Difirente tipos de objeto pajaro
    public enum BirdName
    {
        bird1, bird2, bird3, bird4, bird5
    }
}
