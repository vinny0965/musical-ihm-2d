using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController gc;
    public Text clavesText;
    public int claves;
    public Text lifeText;
    public int lives = 3;
    public Text chavesText;
    public int chaves = 0;
    public Text timeText;
    public float timeCount;
    public bool timeOver = false;
    


    void Awake()
    {
        if(gc==null)
        {
            gc = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(gc != this)
        {
            Destroy(gameObject);
        }
        RefreshScreen();
    }
   

    public void SetLives(int life)
    {
        lives += life;
        if(lives >=0)
        RefreshScreen();

    }

   

    public void SetClaves(int clave)
    {
        claves +=clave;
        if (claves ==20)
        {
            claves = 0;
            chaves +=1;
        }

    }

    public void RefreshScreen()
    {
        clavesText.text  = claves.ToString();
        lifeText.text = lives.ToString();
        chavesText.text = chaves.ToString();
        timeText.text = timeCount.ToString("F0");
    }

   
    private void Update()
    {
        TimeCount();
    }

    void TimeCount()
    {
        timeOver = false;
        if(!timeOver && timeCount >0)
        {
            timeCount -= Time.deltaTime;
            RefreshScreen();

            if(timeCount <=0)
            {
                timeCount = 0;
                GameObject.Find("Player").GetComponent<PlayerLife>().LoseLife();
                timeOver = true;
            }
        }
    }
}
