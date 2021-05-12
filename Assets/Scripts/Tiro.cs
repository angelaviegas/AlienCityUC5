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
    public bool colidiu=false;
    private void Start()
    {



        controladorDoPlayer = FindObjectOfType<PlayerController>();
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
        if (colidiu == true)
        {
            anim.SetBool("colidiu", true);
            Explosao();
            Destroy(gameObject, 0.5f);
        }

        //Destroy(gameObject);
    }

    private void Explosao()
    {
        anim.SetTrigger("colisao");
    }



    private void DestruirTiroPorTempo()
    {
        Destroy(gameObject, 1f);
    }

}
