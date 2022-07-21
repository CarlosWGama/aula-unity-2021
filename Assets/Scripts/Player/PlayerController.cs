using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
      
    public float velocidade = 4f; //Valor padrão inicial
    private Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update() {

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
    }
}
