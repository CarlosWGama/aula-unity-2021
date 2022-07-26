using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour {

    private float desabilitar = 0.5f;

    void OnEnable() {
        desabilitar = 0.5f;    //Ao habilitar o objeto zera o time
    }

    void Update() {
        desabilitar -= Time.deltaTime;
        if (desabilitar < 0) {
            gameObject.SetActive(false); //Desativa o objeto
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        //Colidiu com inimigo
        if (other.gameObject.tag == "Inimigo") {

            //Só ativa se colidiu com o BoxCollider2D e não com o CircleCollider
            if (other.GetType() == typeof(BoxCollider2D)) {
                other.gameObject.GetComponent<Inimigo>().SofrerDano();
            }
        }
    }
}
