using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // private bool audioEnabled = true;

    private AudioSource musicMenu;
    private bool desativarAudio;

    private void Start()
    {
        // Inicialmente, garantimos que o áudio esteja ativado
         musicMenu = GameObject.Find("MusicMenu").GetComponent<AudioSource>();

    }

    public void stopMusic()
    {
        // Toca a música utilizando o AudioSource
        if (musicMenu != null)
        {
            musicMenu.Stop();
        }
        else
        {
            Debug.LogError("AudioSource não encontrado no objeto musicTeste.");
        }
    }

    public void PlayMusic()
    {
        if (musicMenu != null)
        {
            if (!musicMenu.isPlaying)
            {
                musicMenu.Play();
            }
            else
            {
                PausarAudio();
            }
        }
        else
        {
            Debug.LogError("AudioSource não encontrado no objeto musicTeste.");
        }
    }

    private void PausarAudio()
    {
        if (musicMenu != null && musicMenu.isPlaying)
        {
            musicMenu.Pause();
        }
    }

    // Função para despausar o áudio
    private void DespausarAudio()
    {
        if (musicMenu != null && !musicMenu.isPlaying)
        {
            musicMenu.UnPause();
        }
    }
}

    // public void ToggleAudio()
    // {
    //     audioEnabled = !audioEnabled;
    //     SetAudioEnabled(audioEnabled);
    // }

    // public void SetAudioEnabled(bool enable)
    // {
    //     // Obtém o componente AudioListener da câmera principal
    //     AudioListener audioListener = Camera.main.GetComponent<AudioListener>();

    //     // Define a propriedade volumeEnabled do AudioListener
    //     audioListener.enabled = enable;
    // }
    
