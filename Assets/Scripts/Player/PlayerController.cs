using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
      
    public int hp = 10;
    public float velocidade = 4f; //Valor padrão inicial
    private Animator animator;

    private float cooldownAtaque = 0.8f;
    public bool vivo = true;

    [Header("Audios")]
    public AudioClip audioAtaque;
    public AudioClip audioDano;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    public void SofrerDano(int dano) {
        if (vivo) {
            hp -= dano;
            
            AudioController.Instance.PlaySE(audioDano);
            if (hp <= 0) {
                hp = 0;
                animator.SetTrigger("death");
                vivo = false;
                FindObjectOfType<GameplayUIController>().GameOver();
            } else {
                animator.SetTrigger("hit");
            }
        }
    }

    void Update() {

        if (vivo) {
            //Altera a animação
            animator.SetBool("walking", Input.GetButton("Horizontal") || Input.GetButton("Vertical"));
            
            //Horizontal
            if (Input.GetAxisRaw("Horizontal") > 0) {
                transform.localScale = new Vector3(1, 1, 1);
                transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            } else if (Input.GetAxisRaw("Horizontal") < 0) {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.Translate(Vector2.left * velocidade * Time.deltaTime);
            }

            //Vertical
            if (Input.GetAxisRaw("Vertical") > 0) 
                transform.Translate(Vector2.up * velocidade * Time.deltaTime);
            else if (Input.GetAxisRaw("Vertical") < 0) 
                transform.Translate(Vector2.down * velocidade * Time.deltaTime);


            //Ataque
            if (cooldownAtaque > 0) cooldownAtaque -= Time.deltaTime;
            if (Input.GetButton("Ataque") && cooldownAtaque < 0) {
                animator.SetTrigger("attack");
                cooldownAtaque = 0.8f;
                AudioController.Instance.PlaySE(audioAtaque);
            }
        }

    }
}
