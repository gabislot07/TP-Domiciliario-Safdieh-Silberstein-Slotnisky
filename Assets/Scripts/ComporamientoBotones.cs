using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComporamientoBotones : MonoBehaviour
{
    int ObjetosUtilizados;
    public Text Texto1;
    public Text Texto2;
    public Text Texto3;
    // Start is called before the first frame update
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
