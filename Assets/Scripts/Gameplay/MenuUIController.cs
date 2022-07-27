using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
  
  public void Iniciar() {
    SceneManager.LoadScene(1);
  }

  public void Fechar() {
    Application.Quit();
  }
}
