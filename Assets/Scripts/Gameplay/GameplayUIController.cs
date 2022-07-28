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

    public AudioClip BGM;

    void Start() {
        player = FindObjectOfType<PlayerController>();
        vida.maxValue = 10;
        if (BGM != null)
            AudioController.Instance.PlayBGM(BGM);
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
