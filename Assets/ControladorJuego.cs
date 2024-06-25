﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ControladorJuego : MonoBehaviour
{
    public Text textoProducto1;
    public Text txtPrecioProducto1;
    public Text textoPrecioTotal;
    public Button botonOpcion1;
    public Button botonOpcion2;
    public Button botonOpcion3;
    public Button botonResponder;

    /*private*/ int precioOpcion1;
    /*private*/ int precioTotal;
    /*private*/ int precioOpcionSeleccionada;
    /*private*/ bool opcionSeleccionada = false;

    void Start()
    {
        InicializarJuego();
    }

    void InicializarJuego()
    {
        
        precioOpcionSeleccionada = 0;

        precioOpcion1 = Random.Range(1, 25);
        precioTotal = Random.Range(precioOpcion1 + 1, 50);

        textoProducto1.text = "🍉"; // ejemplo de opcion
        txtPrecioProducto1.text = "$" + precioOpcion1.ToString();
        textoPrecioTotal.text = "$" + precioTotal.ToString();

        int opcionCorrecta = precioTotal - precioOpcion1;
        int opcionIncorrecta1 = Random.Range(1, 25);
        int opcionIncorrecta2 = Random.Range(1, 25);

        // asegurar de que las opciones incorrectas no sean iguales a la correctas
        while (opcionCorrecta == opcionIncorrecta1 || opcionCorrecta == opcionIncorrecta2)
        {
            opcionCorrecta = precioTotal - precioOpcion1;
        }

        // Mezclar las opciones aleatoriamente para los botones
        List<int> opciones = new List<int>
        {
            opcionIncorrecta1, opcionIncorrecta2, opcionCorrecta
        };
        opciones = MezclarOpciones(opciones);

        // Asignar las opciones a los botones
        botonOpcion1.GetComponentInChildren<Text>().text = "$" + opciones[0].ToString();
        botonOpcion2.GetComponentInChildren<Text>().text = "$" + opciones[1].ToString();
        botonOpcion3.GetComponentInChildren<Text>().text = "$" + opciones[2].ToString();

        List<A> MezclarOpciones<A>(List<A> lista) //lista generica: puede ser cualquier tipo de dato (lo buscamos en google para saber como hacerlo)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                A temp = lista[i]; //variable temporal :  para poder luego intercambiar valores (tambien lo buscamos en google para ver como se hacia, 
                                    //ya que no  queremos que esta variable sea definitiva en todoel juego
                int randomIndex = Random.Range(i, lista.Count); //lo hicimos asi en vez de poner 0, 3 para evitar errores
                lista[i] = lista[randomIndex];
                lista[randomIndex] = temp; //para asegurar que todos los elementos fueron mezlcados al azar
            }
            return lista;
        }
    }

    void SeleccionarOpcion(int opcion)
    {
       //FALTA o
        opcionSeleccionada = true;
    }

    void ComprobarRTA()
    {
        if (opcionSeleccionada == false)
        {
            Debug.Log("Debes seleccionar un producto");
        }
        else if (precioOpcionSeleccionada == precioTotal - precioOpcion1)
        {
            Debug.Log("Acertaste");
        }
        else
        {
            Debug.Log("No acertaste, intenta denuevo");
        }
    }

    //FALTA PROGRAMAR EL PANEL DE NOTIFICACIONES o
}