using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public PlayerController2 playerController;
    private GameController2 gameController;


    void Awake()
    {
        // Encontre o GameController2 na cena usando FindObjectOfType
        gameController = GameObject.FindObjectOfType<GameController2>();

    }


    public void OnLeftButtonPressed()
    {
        playerController.MoveLeft();
        playerController.setMoveLeft();
        gameController.AddCommandToHistory("andar.esquerda()");


    }

    public void OnRightButtonPressed()
    {
        playerController.MoveRight();
        playerController.setMoveRigth();
        gameController.AddCommandToHistory("andar.direita()");

    }
    public void OnPlayButtonPressed()
    {
        playerController.PlayMovements();
        playerController.resetComands();
    }
    public void OnUpButtonPressed()
    {
        playerController.MoveUp();
        playerController.setMoveUp();
        gameController.AddCommandToHistory("andar.cima()");


    }

    public void onResetButtonPressed()
    {
        playerController.lixeira();
    }
    public void OnDownButtonPressed()
    {
        playerController.MoveDown();
        playerController.setMoveDown();
        gameController.AddCommandToHistory("andar.baixo()");

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
  
}
