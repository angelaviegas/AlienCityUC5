using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidade = 15f;
    public SpriteRenderer sr2d;
    public Animator anim;
    private Rigidbody2D rb2d;
    private PlayerController controladorDoPlayer;
    private PlayerController controladorArma;
    public bool colidiu=false;
 
    //Variável para instanciar a explosão
    public GameObject explosaoAzul;
    public GameObject explosaoLaranja;
    private void Start()
    {
        controladorDoPlayer = FindObjectOfType<PlayerController>();
        controladorArma = FindObjectOfType<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
        sr2d = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
            if (controladorDoPlayer.viradoDireita)
            {
                rb2d.velocity = transform.right * velocidade;
            }
            else
            {
                rb2d.velocity = (transform.right * -1) * velocidade;
                sr2d.flipX = true;
            }
            DestruirTiroPorTempo();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cube") //Testando qual objeto ele colidiu pelo nome do objeto
        {
            anim.SetBool("colidiu", true);
            Destroy(gameObject);
            if (controladorArma.tipoArma == 1)
            {
                GameObject azulBoom = Instantiate(explosaoAzul, transform.position, transform.rotation);
                Destroy(azulBoom, 0.5f);
            } else if(controladorArma.tipoArma ==2)
            {
                GameObject laranjaBoom = Instantiate(explosaoLaranja, transform.position, transform.rotation);
                Destroy(laranjaBoom, 0.5f);
            }
        }
    }
    private void DestruirTiroPorTempo()
    {
        Destroy(gameObject, 1f);
    }

}
