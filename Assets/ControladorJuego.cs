using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ControladorJuego : MonoBehaviour
{
    public Text textoProducto1;
    public Text txtPrecioProducto1;
    public Text textoPrecioTotal;
    public Button Btn_opcion1;
    public Button Btn_opcion2;
    public Button Btn_opcion3;
    public Button Btn_confirmacionRTA;
    public GameObject panelError;
    public GameObject panelNotificaciones;
    public Text resultadoNotificacion;
    public Button botonJugarOtraVez;
    public Button botonSalir;

    private int precioOpcion1;
    private int precioTotal;
    private int precioOpcionSeleccionada;
    private bool opcionSeleccionada = false;

    void Start()
    {
        InicializarJuego();

        // Agregar listeners a los botones de opciones
        Btn_opcion1.onClick.AddListener(() => SeleccionarOpcion(0));
        Btn_opcion2.onClick.AddListener(() => SeleccionarOpcion(1));
        Btn_opcion3.onClick.AddListener(() => SeleccionarOpcion(2));

        // Listener para el botón Responder
        Btn_confirmacionRTA.onClick.AddListener(Responder);
    }

    void InicializarJuego()
    {
        // Generar valores aleatorios para precios y opciones
        precioOpcion1 = Random.Range(1, 25);
        precioTotal = Random.Range(precioOpcion1 + 1, 50);

        int opcionCorrecta = precioTotal - precioOpcion1;
        int opcionIncorrecta1 = Random.Range(1, 25);
        int opcionIncorrecta2 = Random.Range(1, 25);

        // Asegurar que las opciones incorrectas no sean iguales a la correcta
        while (opcionCorrecta == opcionIncorrecta1 || opcionCorrecta == opcionIncorrecta2)
        {
            opcionCorrecta = precioTotal - precioOpcion1;
        }

        // Mezclar las opciones aleatoriamente para los botones
        int[] opciones = { opcionIncorrecta1, opcionIncorrecta2, opcionCorrecta };
        Mezcla(opciones);

        // Asignar precios a los botones
        Btn_opcion1.GetComponentInChildren<Text>().text = "$" + opciones[0].ToString();
        Btn_opcion2.GetComponentInChildren<Text>().text = "$" + opciones[1].ToString();
        Btn_opcion3.GetComponentInChildren<Text>().text = "$" + opciones[2].ToString();

        // Guardar el precio de la opción correcta seleccionada
        precioOpcionSeleccionada = opciones[2]; // La opción correcta está en la posición 2 después de mezclar
    }

    void SeleccionarOpcion(int opcionIndex)
    {
        string textoPrecioSeleccionado = opcionIndex == 0 ? Btn_opcion1.GetComponentInChildren<Text>().text :
                                         opcionIndex == 1 ? Btn_opcion2.GetComponentInChildren<Text>().text :
                                         Btn_opcion3.GetComponentInChildren<Text>().text;
        precioOpcionSeleccionada = int.Parse(textoPrecioSeleccionado.Substring(1));
        opcionSeleccionada = true;
    }

    void Responder()
    {
        if (!opcionSeleccionada)
        {
            panelError.SetActive(true);
            return;
        }

        if (precioOpcionSeleccionada == precioTotal - precioOpcion1)
        {
            MostrarNotificacion("Respuesta correcta");
            botonJugarOtraVez.GetComponentInChildren<Text>().text = "Reiniciar el juego";
        }
        else
        {
            MostrarNotificacion("Respuesta incorrecta");
            botonJugarOtraVez.GetComponentInChildren<Text>().text = "Volver a intentarlo";
        }

        panelNotificaciones.SetActive(true);
    }

    void MostrarNotificacion(string mensaje)
    {
        resultadoNotificacion.text = mensaje;
    }

    void Mezcla(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int a = Random.Range(0, i + 1);
            int temp = array[i];
            array[i] = array[a];
            array[a] = temp;
        }
    }

    public void CerrarPanelError()
    {
        panelError.SetActive(false);
    }

    public void JugarOtraVez()
    {
        panelNotificaciones.SetActive(false);
        InicializarJuego();
    }

    public void Salir()
    {
        // Implementar lógica para cargar la escena de selección de juegos
        // SceneManager.LoadScene("SeleccionarJuegos");
    }

    public void PanelConfirmarSeleecionarOpcion()
    {
        
    }
}
