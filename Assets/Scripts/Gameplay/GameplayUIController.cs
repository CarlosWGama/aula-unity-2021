using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameplayUIController : MonoBehaviour {

    public TextMeshProUGUI pontos;
    private int pontosAtuais = 0;
    public Slider vida;
    public GameObject gameOver;
    private PlayerController player;

    void Start() {
        player = GameObject.FindObjectOfType<PlayerController>();
        vida.maxValue = 10;
    }

    void Update() {
        vida.value = player.hp;
    }

    public void GanharPontos() {
        pontosAtuais++;
        pontos.text =  pontosAtuais.ToString();
    }

    public void GameOver() {
        gameOver.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AbrirMenu() {
        SceneManager.LoadScene("Menu");
    }
}
