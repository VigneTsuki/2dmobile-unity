using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CarregarTela(string cena)
    {
        SceneManager.LoadScene(cena);
        GameController.instance.vidas = 3;
        GameController.instance.totalScore = 0;
        if(cena != "Menu")
            GameController.instance.canvas.enabled = true;
        GameController.instance.faseFinal = false;
    }

    public void Sair()
    {
        Application.Quit();
    }
}
