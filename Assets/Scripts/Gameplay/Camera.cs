using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = player.transform.position;
        position.z = transform.position.z; //Mantem a mesma distancia no eixo Z

        transform.position = Vector3.MoveTowards(transform.position, position, 2f * Time.deltaTime);
    }
}
