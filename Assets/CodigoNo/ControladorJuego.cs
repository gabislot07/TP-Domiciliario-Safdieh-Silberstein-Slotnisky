using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorJuego : MonoBehaviour
{
    public GameObject[] objetos;
    Dictionary<GameObject, int> valor = new Dictionary<GameObject, int>();
    GameObject RandomObjeto;
    public Text txt1;
    public Text txt2;
    public Text txt3;
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

    int precioOpcion1;
    int precioOpcion2;
    int precioOpcion3;
    int precioTotal;
    int precioOpcionSeleccionada;
    bool opcionSeleccionada = false;

    void Start()
    {
        InicializarJuego();
        CrearValores();
        ObjetoDesactivar();
        

        // Agregar listeners a los botones de opciones
        Btn_opcion1.onClick.AddListener(() => SeleccionarOpcion(0));
        Btn_opcion2.onClick.AddListener(() => SeleccionarOpcion(1));
        Btn_opcion3.onClick.AddListener(() => SeleccionarOpcion(2));

        // Activa los diferentes objetos en posiciones random
        ObjetoActivar(580f, 65f, 0);
        precioTotal = valor[RandomObjeto];
        textoPrecioTotal.text = "$" + precioTotal.ToString();
        ObjetoActivar(380f, 65f, 0);
        precioOpcion1 = valor[RandomObjeto];
        txt1.text = "$" + precioOpcion1.ToString();
        ObjetoActivar(180f, 65f, 0);
        precioOpcion2 = valor[RandomObjeto];
        txt2.text = "$" + precioOpcion2.ToString();
        ObjetoActivar(260f, 230f, 0);
        precioOpcion3 = valor[RandomObjeto];
        txt3.text = "$" + precioOpcion3.ToString();
        /* RandomObjeto = Random.Range(1, 4); */

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
    void CrearValores()
    {
        for (int i = 0;  i < objetos.Length; i++)
        {
            /* valor.Add(objetos[i], random.Range(1,25)); */
        }
    }
      void ObjetoActivar(float x, float y, float z)
    {
        // 
        int randomIndex;
        do{
            randomIndex = Random.Range(0, objetos.Length -1);
        } while (objetos[randomIndex].active);
        RandomObjeto = objetos[randomIndex];
        x = Mathf.Clamp(x, 0f, Screen.width - 100f);
        y = Mathf.Clamp(y, 0f, Screen.height - 100f);
        RandomObjeto.transform.position = new Vector3(x, y, z);
        RandomObjeto.SetActive(true);
    }
    void ObjetoDesactivar()
    {
     for (int i = 0;  i < objetos.Length; i++)
     {
        objetos[i].SetActive(false);
     }    
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
