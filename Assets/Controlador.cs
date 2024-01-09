using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;

public class Controlador : MonoBehaviour
{
    [SerializeField] Teclado[] teclados;
    public static Controlador instancia;

    int actual = 0;

    private void Start()
    {
        instancia = this;

        actual = Random.Range(0, 2);
        Nueva();
    }

    public void Nueva() 
    {
        teclados[actual].Nueva(teclados[actual].teclas[Random.Range(0, teclados[actual].teclas.Length)].codigo);
        actual = (actual == 0) ? 1 : 0;
    }
}
