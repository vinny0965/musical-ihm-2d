using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController2 : MonoBehaviour
{

    public static GameController2 gc;
    // public Text clavesText;
    // public int claves;
    // public Text lifeText;
    // public int lives = 3;
    // public Text chavesText;
    // public int chaves = 0;
    // public Text timeText;
    // public float timeCount;
    // public bool timeOver = false;
    public Text setNotaDoText;
    public int notasDo = 0;
    public Text setNotaReText;
    public int notasRe = 0;
    public Text setNotaMiText;
    public int notasMi = 0;
    public Text setNotaFaText;
    public int notasFa = 0;
    public Text setNotaSolText;
    public int notasSol = 0;
    public Text setNotaLaText;
    public int notasLa = 0;
    public Text setNotaSiText;
    public int notasSi = 0;

    public Text setLoopRigthText;
    public int loopRigth = 0;
    public Text setLoopLeftText;
    public int loopLeft = 0;
    public Text setLoopUpText;
    public int loopUp = 0;
    public Text setLoopDownText;
    public int loopDown = 0;

    public int notasColetadas = 0;
    public int quantidadeNotasMusicais;
    public GameObject dialoguePanel;
    public GameObject canvasElementosTela;

    public Text titleText;        // Referência ao Text que exibe o título do console
    public Text historyText;      // Referência ao Text que exibe o histórico de comandos
    public Image consoleImage;    // Referência à Image que representa o visual do console
    public int lives = 3;
    public float timeCount;
    public bool timeOver = false;
    private List<string> commandHistory = new List<string>();
    public Text lifeText;

    private Vector3 initialPosition;
    public GameObject objectController;

    void Awake()
    {
        if (gc == null)
        {
            gc = this;
        }
        else if (gc != this)
        {
            Destroy(gameObject);
            return; // Adicionado return para evitar execução adicional
        }

        RefreshScreen();
        dialoguePanel.SetActive(false);

    }
   

    public void SetLives(int life)
    {
        lives += life;
        if(lives >=0)
        RefreshScreen();

    }

   

    // public void SetClaves(int clave)
    // {
    //     claves +=clave;
    //     if (claves ==2)
    //     {
    //         claves = 0;
    //         chaves +=1;
    //     }

    // }
    public void SetNotasDo(int notaDo)
    {
        notasDo +=notaDo;
        RefreshScreen();
        ColetarNotaMusical();


    }
    public void SetNotasRe(int notaRe)
    {
        notasRe +=notaRe;
        ColetarNotaMusical();

    }
    public void SetNotasSol(int notaSol)
    {
        notasSol +=notaSol;
        RefreshScreen();
        ColetarNotaMusical();

    }
    public void SetNotasMi(int notaMi)
    {
        notasMi +=notaMi;
        RefreshScreen();
        ColetarNotaMusical();

    }
    public void SetNotasFa(int notaFa)
    {
        notasFa +=notaFa;
        RefreshScreen();
        ColetarNotaMusical();

    }
    public void SetNotasLa(int notaLa)
    {
        notasLa +=notaLa;
        RefreshScreen();
        ColetarNotaMusical();

    }
    public void SetNotasSi(int notaSi)
    {
        notasSi +=notaSi;
        RefreshScreen();
        ColetarNotaMusical();

    }
    

    public void SetLoopsRith(int loopsRigth)
    {
        loopRigth +=loopsRigth;
        RefreshScreen();

    }

     public void SetLoopsLeft(int loopsLeft)
    {
        loopLeft +=loopsLeft;

        RefreshScreen();

    }

     public void SetLoopsUp(int loopsUp)
    {
        loopUp +=loopsUp;
        RefreshScreen();

    }

     public void SetLoopsDown(int loopsDown)
    {
        loopDown +=loopsDown;
        RefreshScreen();

    }


    public void setReset()
    {
        loopDown = 0;
        loopLeft = 0;
        loopRigth = 0;
        loopUp = 0;
        RefreshScreen();
    }


    public void ColetarNotaMusical()
    {
        notasColetadas++;

        // Verifica se todas as notas foram coletadas
        if (notasColetadas == quantidadeNotasMusicais)
        {
            // Fase concluída com sucesso, chama a função CompleteFase no LevelManager
            Debug.Log("Fase concluida!");
            dialoguePanel.SetActive(true);
            canvasElementosTela.SetActive(false);
            if(SceneManager.GetActiveScene().buildIndex>PlayerPrefs.GetInt("faseCompletada"))
            {
                PlayerPrefs.SetInt("faseCompletada", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.Save();
            }
          
 // Passa o índice da fase concluída (0 neste exemplo)
        }
    }

 

    private void Start()
    {
        titleText.text = "CONSOLE DE COMANDOS";
    }

    public void AddCommandToHistory(string command)
    {
        commandHistory.Add(command);
        UpdateHistoryText();
    }

    private void UpdateHistoryText()
    {
        historyText.text = string.Join(">", commandHistory);
    }

    public void limparConsole(){
        commandHistory.Clear();
        UpdateHistoryText();


    }


    
    public void RefreshScreen()
    {
        // clavesText.text  = claves.ToString();
        // lifeText.text = lives.ToString();
        // chavesText.text = chaves.ToString();
        // timeText.text = timeCount.ToString("F0");
        // setNotaDoText.text = notasDo.ToString();
        // setNotaReText.text = notasRe.ToString();
        // setNotaMiText.text = notasMi.ToString();
        // setNotaFaText.text = notasFa.ToString();
        // setNotaSolText.text = notasSol.ToString();
        // setNotaLaText.text = notasLa.ToString();
        // setNotaSiText.text = notasSi.ToString();

        setLoopRigthText.text = loopRigth.ToString();
        setLoopLeftText.text = loopLeft.ToString();
        setLoopUpText.text = loopUp.ToString();
        setLoopDownText.text = loopDown.ToString();
        lifeText.text = lives.ToString();
        


    }

   
    // private void Update()
    // {
    //     TimeCount();
    // }

    // void TimeCount()
    // {
    //     timeOver = false;
    //     if(!timeOver && timeCount >0)
    //     {
    //         timeCount -= Time.deltaTime;
    //         RefreshScreen();

    //         if(timeCount <=0)
    //         {
    //             timeCount = 0;
    //             GameObject.Find("Player").GetComponent<PlayerLife>().LoseLife();
    //             timeOver = true;
    //         }
    //     }
    // }
}
