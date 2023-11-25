using UnityEngine;
using UnityEngine.SceneManagement;

public class PassarFase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            if (GameController.instance.faseFinal)
            {
                GameController.instance.vidas = 0;
                GameController.instance.totalScore = 0;
                GameController.instance.canvas.enabled = false;
                SceneManager.LoadScene("Vitoria");
            }
            else
            {
                GameController.instance.faseFinal = true;
                SceneManager.LoadScene("Tela2");
            }
        }
    }
}
