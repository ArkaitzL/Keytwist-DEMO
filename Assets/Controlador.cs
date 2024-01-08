using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    [SerializeField] Teclado tecladoL, tecladoR;
    public static Controlador instancia;

    private void Start()
    {
        instancia = this;
        Nueva();
    }

    public void Nueva() 
    {
        tecladoL.Nueva(tecladoL.teclas[Random.Range(0, tecladoL.teclas.Length)].codigo);
    }
}
