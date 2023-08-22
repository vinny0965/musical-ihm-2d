using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TrocaCenario : MonoBehaviour
{

    public string nomeDaFase;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CarregarNovaFase();
        }
    }

    private void CarregarNovaFase()
    {
        GameController.gc.timeCount = 1200f;
        SceneManager.LoadScene(nomeDaFase);

    }
}
