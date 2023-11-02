using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnTraducir : MonoBehaviour
{
    [SerializeField] GameObject[] ObjetosActivar;
    [SerializeField] GameObject[] ObjetosDesactivar;

    [SerializeField] TraductorTextoSeñas Traductor;
    [SerializeField] Text Texto;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obj in ObjetosActivar)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Siguiente()
    {
        foreach (GameObject obj in ObjetosActivar)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in ObjetosDesactivar)
        {
            obj.SetActive(false);
        }
    }

    public void IniciarTraduccion()
    {
        Traductor.textoTraducir = Texto.text;
        Traductor.Traducir();
    }

    public void LimpiarTextoTraductor()
    {
        Texto.text = "";
    }
}
