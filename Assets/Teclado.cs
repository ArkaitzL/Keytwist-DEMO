using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;

public class Teclado : MonoBehaviour
{
    [Header("Animacion")]
    [SerializeField] AnimationCurve animacion;
    [SerializeField] float recorrido = 1, duracion = .25f;

    [Header("Materiales")]
    [SerializeField] Material seleccionado;
    [SerializeField] Material mantenido;
    [SerializeField] Material perdido;

    [Header("Teclas")]
    [SerializeField] public Tecla[] teclas;

    List<KeyCode> mantener = new();
    KeyCode? pendiente = null;

    private void Start()
    {
        foreach (var tecla in teclas) 
        {
            tecla.posicion = tecla.referencia.localPosition;
        }
    }

    private void Update()
    {
        foreach (var tecla in teclas)
        {
            //Añadir
            if (Input.GetKeyDown(tecla.codigo))
            {
                tecla.estado = true;
            }
            if (Input.GetKeyUp(tecla.codigo))
            {
                tecla.estado = false;
            }

            //Animacion
            if (tecla.estado)
            {
                if (tecla.posicion != tecla.posicion.Y(-recorrido))
                    ControladorBG.Mover(tecla.referencia, new(duracion, tecla.posicion.Y(-recorrido), animacion));
            } else
            {
                if (tecla.posicion != tecla.posicion.Y(+recorrido))
                    ControladorBG.Mover(tecla.referencia, new(duracion, tecla.posicion.Y(+recorrido), animacion));
            }

            //Añade tecla pendienta si hay
            if (pendiente != null && pendiente == tecla.codigo)
            {
                if (tecla.estado)
                {
                    mantener.Add(pendiente.Value);

                    tecla.referencia.GetComponent<Renderer>().material = mantenido;
                    pendiente = null;

                    Controlador.instancia.Nueva();
                }
            }

            //Comprobacion
            if (mantener.Some((mantenido) => mantenido == tecla.codigo && !tecla.estado))
            {
                tecla.referencia.GetComponent<Renderer>().material = perdido;
                Debug.Log("Pierde");
            }


            //Pierde
            //if (tecla.estado) Debug.Log("Pierde");
        }
    }

    public void Nueva(KeyCode codigo) 
    {
        pendiente = codigo;

        foreach (var tecla in teclas)
        {
            if (tecla.codigo == codigo)
            {
                tecla.referencia.GetComponent<Renderer>().material = seleccionado;
            }
        }
    }

    [Serializable]
    public class Tecla {
        public KeyCode codigo;
        public Transform referencia;
        [HideInInspector] public Vector3 posicion;
        [HideInInspector] public bool estado;
    }
}
