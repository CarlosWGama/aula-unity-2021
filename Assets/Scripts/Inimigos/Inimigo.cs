using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {

    private GameObject player;
    public float velocidade = 2f;
    private bool podeMover = true;
    public GameObject projetil;

    private float timer = 1.5f;

    private Animator animator;
    private bool vivo = true;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if (vivo) {

            //vira o personagem para o lado correto 
            if (transform.position.x < player.transform.position.x) {
                transform.localScale = new Vector3(1, 1, 1); //Direita
            } else {
                transform.localScale = new Vector3(-1, 1, 1); //Esquerda
            }

            //Avalia se é para atacar ou seguir o player
            animator.SetBool("podeMover", podeMover);
            if (podeMover)
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocidade*Time.deltaTime);
            else {
                timer -= Time.deltaTime; //Reduz o tempo do timer
                if (timer < 0) { //Chegou a 0 executa a ação
                    Ataque();
                    timer = 1.1f; //Reinicia o timer
                }
            }
        }
    }

    public void SofrerDano() {
        if (vivo) {
            animator.SetTrigger("morreu");
            vivo = false;
            Destroy(gameObject, 3f);
        }
    }

    void Ataque() {
        Instantiate(projetil, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") podeMover = false;
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") podeMover = true;
    }
}
