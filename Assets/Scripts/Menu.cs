using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public SoundPlayer soundPlayer; // Referência ao script SoundPlayer
    
    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene(cena);
        // GameController.gc.timeCount = 1200;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void resetarPlayerPrefs()
    {
        PlayerPrefs.SetInt("faseCompletada", 1);
    }

    public void desativarAudio()
    {
        // Encontra o objeto que contém o AudioManager na cena
        MusicController audioManager = FindObjectOfType<MusicController>();

        if (audioManager != null)
        {
            // Chama a função SetAudioEnabled no AudioManager
            audioManager.SetAudioEnabled(false);
        }
    }
    public void ExitFullscreen()
    {
        // Verifica se o jogo está em tela cheia antes de tentar sair
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
    }

    public void playSoundsWithInterval()
    {
        // Chama a função PlaySoundsWithInterval no SoundPlayer
        if (soundPlayer != null)
        {
            soundPlayer.PlaySoundsWithInterval();
        }
    }
}
