using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarEscena(string Escena)
    {
        SceneManager.LoadScene(Escena);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void AlternarPanel(GameObject panel)
    {
        panel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void RedireccionarURL(string URL)
    {
        Application.OpenURL(URL);
    }
}
