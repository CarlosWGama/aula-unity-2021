using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    
    public GameObject inimigo;

    //O tempo que demora para spawnar um novo inimigo
    public float cooldown = 3f;
    private float timer;
    private PlayerController player;
    // Update is called once per frame

    void Awake() {
        timer = cooldown;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update() {
        if (player.vivo) {
            timer -= Time.deltaTime;
            //Instancia o inimigo
            if (timer < 0) {
                timer = cooldown;
                Instantiate(inimigo, transform.position, Quaternion.identity);
            }
        }
    }
}
