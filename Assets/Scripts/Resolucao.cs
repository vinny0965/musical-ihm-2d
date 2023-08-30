using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolucao : MonoBehaviour
{



    public void Resolution(){
        Screen.SetResolution(1920,1080,true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Resolution();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
