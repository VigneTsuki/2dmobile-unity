using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("oi");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PersonagemScript>().SuperPulo();
        }
    }
}
