using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    public Button[] botoes;
    // Start is called before the first frame update
   

    // Update is called once per frame
    private void Update()
    {
        for(int i=0;i<botoes.Length;i++)
        {
            if(i+2>PlayerPrefs.GetInt("faseCompletada"))
            {
                botoes[i].interactable = false;
            }
        }
    }
}
