using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;
using System.Linq;
using System;
using Random = UnityEngine.Random;

public class Controlador : MonoBehaviour
{
    [SerializeField] Teclado[] teclados;
    [SerializeField] GameObject[] fin;

    [HideInInspector] public static Controlador instancia;

    List<Teclado.Tecla>[] desordenado = { new(), new() };
    int actual = 0;
    int[] index = { 0 , 0};

    private void Start()
    {
        instancia = this;

        for (int i = 0; i < desordenado.Length; i++)
        {
            desordenado[i] = teclados[i].teclas.OrderBy(x => Guid.NewGuid().GetHashCode()).ToList();
        }


        actual = Random.Range(0, 2);
        Nueva();
    }

    public void Nueva() 
    {
        teclados[actual].Nueva(desordenado[actual][index[actual]++].codigo);
        actual = (actual == 0) ? 1 : 0;
    }

    public void Muerto(int teclado) 
    { 
        fin[teclado].SetActive(true);
    }
}
