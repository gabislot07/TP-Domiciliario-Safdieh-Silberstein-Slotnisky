using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorDelJuego : MonoBehaviour
{
    public GameObject[] ObjBtn1;
    public GameObject[] ObjBtn2;
    public GameObject[] ObjBtn3;
    public GameObject[] ObjBtnPrecio;
    public GameObject[] Objetos;
    Dictionary<GameObject, int> precio = new Dictionary<GameObject, int>();
    GameObject ObjetoRandom;
    public Text txt_PreciosSuma;
    public Text Texto1;
    public Text Texto2;
    public Text Texto3;
    public Text TextoSuma;
    public Text noti;
    int PrecioAleatorio;
    int SumaPrecios;
    int ObjetosUtilizados;
    int PrecioSuma;
    int Precio1;
    int Precio2;
    int Precio3;
    bool EstadoRespuesta;
    bool EstadoBoton = false;
    public GameObject PanelResponder;
    public bool ChequeoClickBoton;
    public GameObject Panel_notificaciones;
    // Start is called before the first frame update
    void Start()
    {
        Panel_notificaciones.SetActive(false);
        PanelResponder.SetActive(false);
        OcultarObjetos();
        PreciosCreados();
        RandomObjAparecer();

        ActivarProductos(151f, 65f, 0);
        PrecioSuma = precio[ObjetoRandom];
        txt_PreciosSuma.text = "$" + PrecioSuma.ToString();

        List<int> preciosUsados = new List<int>();



        // Asignamos y verificamos los precios para que no se repitan
        ActivarProductos(-212f, -65f, 0);
        Precio1 = precio[ObjetoRandom];
        while (preciosUsados.Contains(Precio1))
        {
            ActivarProductos(-212f, -65f, 0);
            Precio1 = precio[ObjetoRandom];
        }
        preciosUsados.Add(Precio1);
        Texto1.text = "$" + Precio1.ToString();


        ActivarProductos(-1f, -65f, 0);
        Precio2 = precio[ObjetoRandom];
        while (preciosUsados.Contains(Precio2))
        {
            ActivarProductos(-1f, -65f, 0);
            Precio2 = precio[ObjetoRandom];
        }
        preciosUsados.Add(Precio2);
        Texto2.text = "$" + Precio2.ToString();


        ActivarProductos(204f, 230f, 0);
        Precio3 = precio[ObjetoRandom];
        while (preciosUsados.Contains(Precio3))
        {
            ActivarProductos(204f, 230f, 0);
            Precio3 = precio[ObjetoRandom];
        }
        preciosUsados.Add(Precio3);
        Texto3.text = "$" + Precio3.ToString();


        PrecioAleatorio = Random.Range(1, 4);

        if (PrecioAleatorio == 1)
        {
            SumaPrecios = PrecioSuma + Precio1;
        }
        else if (PrecioAleatorio == 2)
        {
            SumaPrecios = Precio2 + PrecioSuma;
        }
        else if (PrecioAleatorio == 3)
        {
            SumaPrecios = Precio3 + PrecioSuma;
        }
        TextoSuma.text = "$" + SumaPrecios.ToString();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomObjAparecer(float x, float y, float z)
    {
        int IndexRandom1;
        do {
            IndexRandom1 = Random.Range(0, ObjBtn1.Length - 1);} 
        ObjBtn1 = ObjBtn1[IndexRandom1];
        ObjBtn1.SetActive(true);
        int IndexRandom2;
        do {
            IndexRandom2 = Random.Range(0, ObjBtn2.Length - 1);} 
        ObjBtn2 = ObjBtn2[IndexRandom2];
        ObjBtn2.SetActive(true);
        int IndexRandom3;
        do {
            IndexRandom3 = Random.Range(0, ObjBtn3.Length - 1);} 
        ObjBtn3 = ObjBtn3[IndexRandom3];
        ObjBtn3.SetActive(true);
        int IndexPrecio;
        do {
            IndexPrecio = Random.Range(0, ObjBtnPrecio.Length - 1);}
        ObjBtnPrecio= ObjBtnPrecio[IndexPrecio];
        ObjBtnPrecio.SetActive(true);
    }

    public void OcultarObjetos()
    {
        for (int i = 0; i < Objetos.Length; i++)
        {
            Objetos[i].SetActive(false);
        }
    }

    void ActivarProductos(float x, float y, float z)
    {
        //
        int IndexRandom;
        do {
            IndexRandom = Random.Range(0, Objetos.Length - 1);
        } while (Objetos[IndexRandom].active);
        ObjetoRandom = Objetos[IndexRandom];
        x = Mathf.Clamp(x, 0f, Screen.width - -212f);
        y = Mathf.Clamp(y, 0f, Screen.height - -65);
        ObjetoRandom.transform.position = new Vector3(x, y, z);
        ObjetoRandom.SetActive(true);
    }

    void PreciosCreados()
    {
        List<int> preciosDisponibles = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            preciosDisponibles.Add(i);
        }

        foreach (var objeto in Objetos)
        {
            if (preciosDisponibles.Count == 0)
            {
                break;
            }

            int randomIndex = Random.Range(0, preciosDisponibles.Count);
            int precioRandom = preciosDisponibles[randomIndex];
            preciosDisponibles.RemoveAt(randomIndex);
            precio[objeto] = precioRandom;
        }
    }

    //PONER RTA EN NEGRITA
    public void Objeto1()
    {
        ChequeoClickBoton = true;
        ObjetosUtilizados = 1;
        Texto1.fontStyle = FontStyle.Bold;
        Texto2.fontStyle = FontStyle.Normal;
        Texto3.fontStyle = FontStyle.Normal;
    }
    public void Objeto2()
    {
        ChequeoClickBoton = true;
        ObjetosUtilizados = 2;
        Texto2.fontStyle = FontStyle.Bold;
        Texto1.fontStyle = FontStyle.Normal;
        Texto3.fontStyle = FontStyle.Normal;
    }
    public void Objeto3()
    {
        ChequeoClickBoton = true;
        ObjetosUtilizados = 3;
        Texto3.fontStyle = FontStyle.Bold;
        Texto2.fontStyle = FontStyle.Normal;
        Texto1.fontStyle = FontStyle.Normal;

    }

    public void AccionBotones()
    {
        EstadoBoton = true;

        if (ObjetosUtilizados == 1)
        {
            if (PrecioSuma + Precio1 == SumaPrecios)
            {
                Panel_notificaciones.SetActive(true);
                EstadoRespuesta = true;
            }
            else
            {
                Panel_notificaciones.SetActive(true);
                EstadoRespuesta = false;
            }
        }
        else if (ObjetosUtilizados == 2)
        {
            if (PrecioSuma + Precio2 == SumaPrecios)
            {
                Panel_notificaciones.SetActive(true);
                EstadoRespuesta = true;
            }
            else
            {
                Panel_notificaciones.SetActive(true);
                EstadoRespuesta = false;
            }
        }
        else if (ObjetosUtilizados == 3)
        {
            if (PrecioSuma + Precio3 == SumaPrecios)
            {
                Panel_notificaciones.SetActive(true);
                EstadoRespuesta = true;
            }
            else
            {
                Panel_notificaciones.SetActive(true);
                EstadoRespuesta = false;
            }
        }
        CambioNotificacion();
    }

    void CambioNotificacion()
    {
        if (EstadoRespuesta)
        {
            noti.text = "Correcto!";
        }
        else
        {
            noti.text = "Incorrecto!";
        }
    }

    public void CambioDeEscenaOtraVez()
    {
        SceneManager.LoadScene("EscenaPrincipal");
    }

    public void CambioDeEscenaSalir()
    {
        SceneManager.LoadScene("EscenaInicio");
    }

    public void ChequeaSeleccionOpcion()
    {
        PanelResponder.SetActive(false);
    }
    public void BtnConfirmar()
    {
        if (ChequeoClickBoton == false)
        {
            PanelResponder.SetActive(true);
        }
        else
        {
            AccionBotones();
            Panel_notificaciones.SetActive(true);
        }
        
    }


}