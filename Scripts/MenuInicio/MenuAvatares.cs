using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAvatares : Menu
{
    [SerializeField] GameObject[] avatares;
    int indice = 0;

    private void Start()
    {
        indice = PlayerPrefs.GetInt("SelectedAvatar", indice);
        if ( avatares != null)
        {
            avatares[indice].SetActive(true);
        }
        
    }

    public void PasarAvatar(bool Siguiente)
    {
        if ( avatares != null)
        {
            avatares[indice].SetActive(false);

            if (Siguiente) indice++;
            else indice--;

            while (indice >= avatares.Length)
            {
                indice = avatares.Length - indice;
            }
            while (indice < 0)
            {
                indice = avatares.Length + indice;
            }

            avatares[indice].SetActive(true);
        }
    }

    public void Select()
    {
        PlayerPrefs.SetInt("SelectedAvatar", indice);
    }
}
