using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private bool audioEnabled = false;

    private static MusicController mc;

    // private void Awake()
    // {
    //     if (mc == null)
    //     {
    //         mc = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else if (mc != this)
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Start()
    {
        // Inicialmente, garantimos que o áudio esteja ativado
        SetAudioEnabled(true);
    }

    public void ToggleAudio()
    {
        audioEnabled = !audioEnabled;
        SetAudioEnabled(audioEnabled);
    }

    public void SetAudioEnabled(bool enable)
    {
        // Obtém todos os componentes AudioListener da cena
        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();

        foreach (AudioListener audioListener in audioListeners)
        {
            // Define a propriedade volumeEnabled do AudioListener
            audioListener.enabled = enable;
        }
    }
}
