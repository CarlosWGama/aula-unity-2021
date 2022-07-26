using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {

    public int dano = 2;
    private Vector3 direcao;
    public float velocidade = 4f;
    // Start is called before the first frame update
    void Start() {
        Vector3 player = GameObject.FindGameObjectWithTag("Player").transform.position;
        direcao = (player - transform.position).normalized;
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerController>().SofrerDano(dano);
            Destroy(gameObject);
        }
    }
}
