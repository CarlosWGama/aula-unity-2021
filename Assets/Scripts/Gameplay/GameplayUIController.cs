using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameplayUIController : MonoBehaviour {

    public TextMeshProUGUI pontos;
    public TextMeshProUGUI record;

    private int pontosAtuais = 0;
    private int maiorPontuacao = 0;
    public Slider vida;
    public GameObject gameOver;
    private PlayerController player;

    public AudioClip BGM;

    void Start() {
        player = FindObjectOfType<PlayerController>();
        vida.maxValue = 10;
        if (BGM != null)
            AudioController.Instance.PlayBGM(BGM);
        //Caso não exista record, pega o valor padrão (0)
        maiorPontuacao = PlayerPrefs.GetInt("record", 0); 
        record.text = maiorPontuacao.ToString();
    }

    void Update() {
        vida.value = player.hp;
    }

    public void GanharPontos() {
        pontosAtuais++;
        if (pontosAtuais > maiorPontuacao) {
            maiorPontuacao = pontosAtuais;
            record.text = maiorPontuacao.ToString();
            PlayerPrefs.SetInt("record", maiorPontuacao);
        } 

        pontos.text =  pontosAtuais.ToString();
    }

    public void GameOver() {
        gameOver.SetActive(true);
        PlayerPrefs.Save();
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AbrirMenu() {
        SceneManager.LoadScene("Menu");
    }
}
