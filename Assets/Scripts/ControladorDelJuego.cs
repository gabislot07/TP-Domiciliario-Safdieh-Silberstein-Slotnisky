using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorDelJuego : MonoBehaviour
{
    public GameObject[] Objetos;
    Dictionary<GameObject, int> precio = new Dictionary<GameObject, int>();
    GameObject ObjetoRandom;
    public Text txt_PreciosSuma;
    public Text Texto1;
    public Text Texto2;
    public Text Texto3;
    public Text TextoSuma;
    public Text Notificacion;
    int PrecioAleatorio;
    int SumaPrecios;
    int ObjetosUtilizados;
    int PrecioSuma;
    int Precio1;
    int Precio2;
    int Precio3;
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


        ActivarProductos(151f, 65f, 0);
        PrecioSuma = precio[ObjetoRandom];
        txt_PreciosSuma.text = "$" + PrecioSuma.ToString();
        ActivarProductos(-212f, -65f, 0);
        Precio1 = precio[ObjetoRandom];
        Texto1.text = "$" + Precio1.ToString();
        ActivarProductos(-1f, -65f, 0);
        Precio2 = precio[ObjetoRandom];
        Texto2.text = "$" + Precio2.ToString();
        ActivarProductos(204f, 230f, 0);
        Precio3 = precio[ObjetoRandom];
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
        x = Mathf.Clamp(x, 0f, Screen.width - 100f);
        y = Mathf.Clamp(y, 0f, Screen.height - 100f);
        ObjetoRandom.transform.position = new Vector3(x, y, z);
        ObjetoRandom.SetActive(true);
    }

    void PreciosCreados()
    {
        for (int i = 0; i < Objetos.Length; i++)
        {
            precio.Add(Objetos[i], Random.Range(1, 11));
        }
    }
    //PONER RTA EN NEGRITA
    public void Objeto1()
    {
        ObjetosUtilizados = 1;
        Texto1.fontStyle = FontStyle.Bold;
        Texto2.fontStyle = FontStyle.Normal;
        Texto3.fontStyle = FontStyle.Normal;
    }
    public void Objeto2()
    {
        ObjetosUtilizados = 2;
        Texto2.fontStyle = FontStyle.Bold;
        Texto1.fontStyle = FontStyle.Normal;
        Texto3.fontStyle = FontStyle.Normal;
    }
    public void Objeto3()
    {
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
                Notificacion.text = "Ganaste!!";
            }
            else
            {
                Panel_notificaciones.SetActive(true);
                Notificacion.text = "Perdiste!!";
            }
        }
        else if (ObjetosUtilizados == 2)
        {
            if (PrecioSuma + Precio2 == SumaPrecios)
            {
                Panel_notificaciones.SetActive(true);
                Notificacion.text = "Ganaste!!";
            }
            else
            {
                Panel_notificaciones.SetActive(true);
                Notificacion.text = "Perdiste!!";
            }
        }
        else if (ObjetosUtilizados == 3)
        {
            if (PrecioSuma + Precio3 == SumaPrecios)
            {
                Panel_notificaciones.SetActive(true);
                Notificacion.text = "Ganaste!!";
            }
            else
            {
                Panel_notificaciones.SetActive(true);
                Notificacion.text = "Perdiste!!";
            }
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
        SceneManager.LoadScene("EscenaPrincipal");
    }
    public void BtnConfirmar()
    {
        PanelResponder.SetActive(true);
    }


}