using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovimentaDireita : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool pressionado = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        pressionado = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressionado = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pressionado) {
            FindObjectOfType<PersonagemScript>().MovimentarDireita();
        }
        else
        {
            FindObjectOfType<PersonagemScript>().EncerraAnimacaoMovimento();
        }
    }
}
