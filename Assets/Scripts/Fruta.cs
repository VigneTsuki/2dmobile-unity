using UnityEngine;

public class Fruta : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        GameController.instance.RefreshScreen();
    }

    /// <summary>
    /// Colisão para somar score do jogador
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            collision.GetComponent<PersonagemScript>().SomarPontos();
            GameController.instance.ColetarItem(gameObject.name);
            gameObject.transform.position = new Vector3(-1000f, -1000f, 0f);
        }
    }
}
