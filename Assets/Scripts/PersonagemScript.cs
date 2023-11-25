using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonagemScript : MonoBehaviour
{
    public float movimentoHorizontal;
    public float movimentoVertical;
    public float velocidade;
    public float forcaPulo;
    private Rigidbody2D rb;
    private Animator anim;
    public bool noChao = true;
    private bool vivo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //joystick = GetComponent<FixedJoystick>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameController.instance.DesabilitarItensColetados();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void FixedUpdate()
    {
        Movimentacao();
    }

    void Update()
    {
        GameController.instance.RefreshScreen();
    }

    void Movimentacao()
    {
        movimentoHorizontal = GameController.instance.joystick.Horizontal;

        Vector3 movimento = new Vector3(movimentoHorizontal, 0f, 0f);
        transform.position += movimento * Time.deltaTime * velocidade;

        if (movimentoHorizontal > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (movimentoHorizontal < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (movimentoHorizontal == 0f)
        {
            anim.SetBool("walk", false);
        }
    }

    public void Pulo()
    {
        if (noChao)
        {   
            rb.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
            noChao = false;
        }
    }

    public void MovimentarDireita()
    {
        Vector3 movimento = new Vector3(1, 0f, 0f);
        transform.position += movimento * Time.deltaTime * velocidade;
        anim.SetBool("walk", true);
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    public void MovimentarEsquerda()
    {
        Vector3 movimento = new Vector3(-1, 0f, 0f);
        transform.position += movimento * Time.deltaTime * velocidade;
        anim.SetBool("walk", true);
        transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }

    public void SuperPulo()
    {
        rb.AddForce(new Vector2(0f, 15), ForceMode2D.Impulse);
        anim.SetBool("jump", true);
        noChao = false;
    }

    public void EncerraAnimacaoMovimento()
    {
        anim.SetBool("walk", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            noChao = true;
        }

        anim.SetBool("jump", false);
    }

    public void DescontarVida()
    {
        if (vivo)
        {
            vivo = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<PersonagemScript>().enabled = false;
            GameController.instance.AlterarVida(-1);

            if(GameController.instance.vidas > 0)
            {
                if(SceneManager.GetActiveScene().name == "Tela1")
                {
                    SceneManager.LoadScene("Tela1");
                }

                if (SceneManager.GetActiveScene().name == "Tela2")
                {
                    SceneManager.LoadScene("Tela2");
                }
            }
            else
            {
                GameController.instance.melanciasColetadas = new System.Collections.Generic.Dictionary<string, bool>();
                CarregarGameOver();
            }
        }
    }

    public void CarregarGameOver()
    {
        SceneManager.LoadScene("GameOver");
        GameController.instance.vidas = 3;
        GameController.instance.totalScore = 0;
        GameController.instance.canvas.enabled = false;
        GameController.instance.RefreshScreen();
    }

    public void GanharVida()
    {
        GameController.instance.AlterarVida(+1);
    }

    public void SomarPontos()
    {
        GameController.instance.AlterarPontos(+1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<SpriteRenderer>().flipY = true;
            collision.gameObject.GetComponent<Enemy>().enabled = false;
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Destroy(collision.gameObject, 1f);
        }
    }
}
