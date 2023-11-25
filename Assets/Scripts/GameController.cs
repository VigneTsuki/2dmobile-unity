using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public FixedJoystick joystick;
    public int totalScore = 0;
    public static GameController instance;
    public TMP_Text vidaTexto;
    public TMP_Text melanciaTexto;
    public Canvas canvas;
    public int vidas = 3;
    public bool faseFinal = false;
    public Dictionary<string, bool> melanciasColetadas = new Dictionary<string, bool>();

    /// <summary>
    /// Não perder o controller ao resetar a tela
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Alterar a vida do jogador
    /// </summary>
    /// <param name="vida"></param>
    public void AlterarVida(int vida)
    {
        vidas += vida;
        if(vidas >= 0)
            RefreshScreen();
    }

    /// <summary>
    /// Alterar os pontos do jogador
    /// </summary>
    /// <param name="ponto"></param>
    public void AlterarPontos(int ponto)
    {
        totalScore += ponto;
        RefreshScreen();
    }

    /// <summary>
    /// Atualizar a tela
    /// </summary>
    public void RefreshScreen()
    {
        vidaTexto.text = vidas.ToString();
        melanciaTexto.text = totalScore.ToString();
    }

    public void ColetarItem(string itemID)
    {
        if (!melanciasColetadas.ContainsKey(itemID))
        {
            melanciasColetadas[itemID] = true;
        }
        else
        {
            melanciasColetadas[itemID] = true;
        }
    }

    public bool ItemColetado(string itemID)
    {
        if (melanciasColetadas.ContainsKey(itemID))
        {
            return melanciasColetadas[itemID];
        }
        return false;
    }

    public void DesabilitarItensColetados()
    {
        foreach (var m in melanciasColetadas)
        {
            if (m.Value)
            {
                GameObject itemObject = GameObject.Find(m.Key);

                if (itemObject != null)
                { 
                    itemObject.transform.position = new Vector3(-1000f, -1000f, 0f);
                }
            }
        }
    }

    public void Pulo()
    {
        FindObjectOfType<PersonagemScript>().Pulo();
    }

    public void MovimentarDireita()
    {
        FindObjectOfType<PersonagemScript>().MovimentarDireita();
    }

    public void MovimentarEsquerda()
    {
        FindObjectOfType<PersonagemScript>().MovimentarEsquerda();
    }
}
