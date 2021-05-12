using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform bocaDeCano;
    public GameObject tiroAzulPrefab;
    public GameObject tirolaranjaPrefab;
    //[SerializeField]private int tipoArma1 = 0;
    public int trocaArma=0;
    //atributos de UI
    public Sprite armaAzul;
    public Sprite armaLaranja;
    public Image controleMudancaArmas;
            // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            trocaArma++;
            if (trocaArma > 2)
            {
                trocaArma = 0;
            }
            Menudearmas();
        }
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Atirar();
        }
    }

    private void Atirar() {
            switch (trocaArma) 
             {
            case 0:
                break;
            case 1:
            
                Instantiate(tiroAzulPrefab, bocaDeCano.position, bocaDeCano.rotation);
                break;
            case 2:
                    Instantiate(tirolaranjaPrefab, bocaDeCano.position, bocaDeCano.rotation);
                break;
            default:
                trocaArma = 0;
                break;
             }
    }
        private void Menudearmas()
        {
            if (trocaArma == 0)
            {
                controleMudancaArmas.overrideSprite = null;
            } else
            {
                if (trocaArma == 1)
                {
                    controleMudancaArmas.overrideSprite = armaAzul;
                }
                else
                {
                    if (trocaArma == 2)
                    {
                        controleMudancaArmas.overrideSprite = armaLaranja;
                    }
                }
            }
        }
}
   
