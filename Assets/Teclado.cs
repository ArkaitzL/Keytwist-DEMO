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
                Controlador.instancia.Nueva();
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

            //Añade tecla nueva
            if (pendiente != null && pendiente == tecla.codigo)
            {
                if (tecla.estado)
                {
                    mantener.Add(pendiente.Value);

                    pendiente = null;
                }
            }

            //Comprobacion
            if (mantener.Some((mantenido) => mantenido == tecla.codigo && !tecla.estado))
            {
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
