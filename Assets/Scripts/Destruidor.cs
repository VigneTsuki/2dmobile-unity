using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruidor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Matar personagem ao cair do mapa
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PersonagemScript>().DescontarVida();
        }
    }
}
