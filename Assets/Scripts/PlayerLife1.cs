using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife1 : MonoBehaviour

{


    public bool alive = true;
    // Start is called before the first frame update
   

    public void LoseLife()
    {
        if(alive)
        {
            // gameObject.GetComponent<Animator>().SetTrigger("Dead");
            // gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            // gameObject.GetComponent<BoxCollider2D>().enabled = false;
            // gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            if (GameController2.gc.lives>0)
            {
            GameController2.gc.SetLives(-1);
            GameController2.gc.RefreshScreen();
            }
            if (GameController2.gc.lives <=0)
            {
                Debug.Log("Perdeu");
                LoadScene();
            }
            

        }

    }


    void LoadGamerOver(){
        GameController2.gc.RefreshScreen();
        // SceneManager.LoadScene("GameOver");

    }

    void LoadScene(){
        SceneManager.LoadScene("GameOver");

    }
}
