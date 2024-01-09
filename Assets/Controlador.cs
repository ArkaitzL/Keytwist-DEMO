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
    [SerializeField] GameObject fin;
    [SerializeField] float tiempo_espera = 1.5f, tiempo_muerto = 3;

    [HideInInspector] public static Controlador instancia;

    public bool jugando;
    List<Teclado.Tecla>[] desordenado = { new(), new() };
    int actual = 0;
    int[] index;

    private void Start()
    {
        instancia = this;
        Iniciar();
    }

    void Iniciar() 
    {
        for (int i = 0; i < desordenado.Length; i++)
        {
            desordenado[i] = teclados[i].teclas.OrderBy(x => Guid.NewGuid().GetHashCode()).ToList();
        }

        jugando = true;
        actual = Random.Range(0, 2);
        index = new int[] { 0, 0 };
        Nueva();
    }

    public void Nueva() 
    {
        teclados[actual].Nueva(desordenado[actual][index[actual]++].codigo);
        actual = (actual == 0) ? 1 : 0;
    }

    public void Muerto(int pos) 
    {
        jugando = false;

        //Morir
        ControladorBG.Rutina(tiempo_espera, () => {
            fin.SetActive(true);

            Transform ganador = fin.transform.Find("Ganador");
            ganador.transform.localPosition = new(ganador.transform.localPosition.x * pos, ganador.transform.localPosition.y, ganador.transform.localPosition.z);

            Transform perdedor = fin.transform.Find("Perdedor");
            perdedor.transform.localPosition = new(perdedor.transform.localPosition.x * pos, perdedor.transform.localPosition.y, perdedor.transform.localPosition.z);

            foreach (var teclado in teclados)
            {
                teclado.Reiniciar();
            }

            Iniciar();
        });
      
        //Reiniciar
        ControladorBG.Rutina(tiempo_muerto + tiempo_espera, () => {
            fin.SetActive(false);
        });
    }
}
