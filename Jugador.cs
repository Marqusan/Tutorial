using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float fuerzaSalto;
    //public bool saltando = false;
    public GameManager gameManager;
    public AudioSource audioPlayer;
    public AudioClip soundJump;
    public AudioClip soundDie;
    private bool puedesaltar;

    private Rigidbody2D rigidbody2;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2 = GetComponent<Rigidbody2D>();
        audioPlayer = GetComponent<AudioSource>();
        puedesaltar = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && animator.GetBool("estaSaltando") == false && puedesaltar == true) 
        {
            animator.SetBool("estaSaltando", true);
            rigidbody2.AddForce(new Vector2(0, fuerzaSalto));
            audioPlayer.clip = soundJump;
            audioPlayer.Play();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("estaSaltando", false);
            
        }

        if (collision.gameObject.tag == "Obstaculo")
        {
            gameManager.gameOver = true;
            audioPlayer.clip = soundDie;
            audioPlayer.Play();
            puedesaltar = false;
        }

    }


}

