using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	// Use this for initialization
	private Animator anim;
	private Rigidbody2D rb2d;

	public SpriteRenderer sr2d;
	public Transform posPe;
	public int tipoArma = 0;
	[HideInInspector] public bool tocaChao = false;
	[HideInInspector] public bool jump;
	//public int situacao;
	public float Velocidade;
	public float ForcaPulo = 1000f;
	public bool parado=true;
	[HideInInspector] public bool viradoDireita = true;

	public Image vida;

	void Start()
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		sr2d = GetComponent<SpriteRenderer>();
	}
	// Update is called once per frame
	void Update()
	{
		tocaChao = Physics2D.Linecast(transform.position, posPe.position, 1 << LayerMask.NameToLayer("Chao"));
		if (Input.GetKeyDown("space"))
		{
			if (tocaChao)
			{
				jump = true;
			}
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			tipoArma++;
			if (tipoArma > 2)
			{
				tipoArma = 0;
			}
			MudancaDeArma();
		}
	}

	void FixedUpdate()
	{
	//if(tipoArma==0)
       // {
		float translationY = 0;
		float translationX = Input.GetAxis("Horizontal") * Velocidade;
		if (translationX == 0)
		{
			parado = true;
		} else if (translationX != 0)
        {
			parado = false;
        }
		transform.Translate(translationX, translationY, 0);
		transform.Rotate(0, 0, 0);
				if (translationX > 0 && !viradoDireita)
				{
					Flip();
				}
				else if (translationX < 0 && viradoDireita)
				{
					Flip();
				}
			MudancaDeArma();
        //}	
	}
	void Flip()
	{
		viradoDireita = !viradoDireita;
		Vector3 escala = transform.localScale;
		escala.x *= -1;
		transform.localScale = escala;
	}
	private void MudancaDeArma()
	{
		switch (tipoArma)
		{
			case 0:
				if (!parado && tocaChao)
				{
					anim.SetTrigger("corre");
				}
				else
				{
					anim.SetTrigger("parado");
				}
				if (jump)
				{
					anim.SetTrigger("pula");
					rb2d.AddForce(new Vector2(0f, ForcaPulo));
					jump = false;
				}
				break;
			case 1:
				if (!parado && tocaChao)
				{
					anim.SetTrigger("correrAzul");
				}
				else 
				{
					anim.SetTrigger("paradoAzul");
				}
				break;
			case 2:
				if (!parado && tocaChao)
				{
					anim.SetTrigger("correrlaranja");
				}
				else 
				{
					anim.SetTrigger("paradoLaranja");
				}
				break;
			default:
				tipoArma = 0;
				parado = false;
				break;
		}
	}
}

