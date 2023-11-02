using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TraductorTextoSeñas : MonoBehaviour
{
    [Header ("Elementos Requeridos")]
    [SerializeField] Animator anim;

    [SerializeField] Animador[] Clips;


    public string textoTraducir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Traducir()
    {
        string[] ListaComandos = textoTraducir.Split(new char[] { ' ' });
        StartCoroutine(SiguienteSeña(ListaComandos));
    }

    IEnumerator SiguienteSeña(string[] Señas)
    {
        for (int i = 0; i < Señas.Length; i++)
        {
            for (int j = 0; j<Clips.Length; j++)
            {
                if (Señas[i].ToLower().Equals(Clips[j].key.ToLower()))
                {
                    anim.Play(Clips[j].clip.name,-1,0);

                    //anim.SetInteger("Seña", Clips[j].Value);
                    //anim.SetTrigger("Cambio");
                    //print(anim.GetCurrentAnimatorStateInfo(0).length);
                    yield return new WaitForEndOfFrame();
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + 0.1f);
                    //yield return new WaitUntil(() => !(anim.GetCurrentAnimatorStateInfo(0).length > anim.GetCurrentAnimatorStateInfo(0).normalizedTime));


                }
            }
        }
        //anim.SetInteger("Seña", 0);
        //anim.SetTrigger("Cambio");
        anim.Play("Idle", -1, 0);
    }

}

[System.Serializable]
public struct Animador
{
    public string key;
    public AnimationClip clip;
}

