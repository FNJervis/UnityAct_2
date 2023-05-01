using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    public float move_speed;
    public float jump_force;
    public Rigidbody2D rig;
    Animator animatorController;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        //inicializar animacion
        animatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //añadir fuerza de salto
            rig.AddForce(Vector2.up * jump_force, ForceMode2D.Impulse);
            //Cambiar animacion de salto
            UpdateAnimation(PlayerAnimation.jump);
        }
        //Cambiar orientacion del personaje
        if (rig.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1);
        }
        else if (rig.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1);
        }

    }
    private void FixedUpdate()
    {
        //Movimiento horizontal
        float xInput = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(xInput * move_speed, rig.velocity.y);

        //Cambiar animacion de movimiento a estatico
        if (xInput != 0)
        {
            UpdateAnimation(PlayerAnimation.wlk);
        }
        else
        {
            UpdateAnimation(PlayerAnimation.idle);
        }  
    }

    public enum PlayerAnimation
    {//Animaciones del personaje
        idle, wlk, jump
    }
    void UpdateAnimation(PlayerAnimation nameAnimation)
    {//cambiar animacion
        switch (nameAnimation)
        {//Casos condicionales para definir las animaciones del personaje
            case PlayerAnimation.idle:
                animatorController.SetBool("is_walking", false);
                animatorController.SetBool("is_jumping", false);
                break;

            case PlayerAnimation.wlk:
                animatorController.SetBool("is_walking", true);
                animatorController.SetBool("is_jumping", false);
                break;

            case PlayerAnimation.jump:
                animatorController.SetBool("is_walking", false);
                animatorController.SetBool("is_jumping", true);
                break;
        }
    }
}
