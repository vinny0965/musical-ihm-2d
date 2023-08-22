using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour

{


    public bool alive = true;
    // Start is called before the first frame update
   

    public void LoseLife()
    {
        if(alive)
        {
            alive = false;
            gameObject.GetComponent<Animator>().SetTrigger("Dead");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<PlayerController>().enabled = false;
            GameController.gc.SetLives(-1);
            GameController.gc.claves = 0;
            
            if(GameController.gc.lives >=0)
            {
                Invoke("LoadScene",1f);
                GameController.gc.timeCount = 1200;
            }
            else
            {
                GameController.gc.lives = 3;
                GameController.gc.chaves = 0;
                GameController.gc.claves = 0; 
                Invoke("LoadGamerOver",1f);
                
            }
        }

    }


    void LoadGamerOver(){
        GameController.gc.RefreshScreen();
        SceneManager.LoadScene("GameOver");

    }

    void LoadScene(){
        SceneManager.LoadScene("SampleScene");
        GameController.gc.RefreshScreen();

    }
}
