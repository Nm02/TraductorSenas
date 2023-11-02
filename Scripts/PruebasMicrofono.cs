using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class PruebasMicrofono : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Button EndButton;
    [SerializeField] Text TextoSalida;

    AudioClip clip;

    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
        StartButton.onClick.RemoveAllListeners();
        StartButton.onClick.AddListener(() => startRecording());

        EndButton.onClick.RemoveAllListeners();
        EndButton.onClick.AddListener(() => StopRecording());
    }

    void startRecording()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = Microphone.Start(null, true, 5, 44100);
        }
        else
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    private void StopRecording()
    {
        
        
    }

    IEnumerable PlayNext()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        while (true)
        {
        }
    }
}
