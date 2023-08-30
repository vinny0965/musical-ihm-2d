using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Animator playerAnimator;
    float input_x;
    float input_y;
    public float speed =4.5f;
    bool isWalking = false;
    bool teste = false;
    // Start is called before the first frame update
   
    public int notas;
    public int chaves = 0;

    // private GameController gcPlayer;
    // public GameController2 gcPlayer2;
   
   [Header("Interact")]
   public KeyCode interactKey = KeyCode.E;
   bool canTeleport = false;
//    Region tmpRegion;


    void Start()
    {

        // gcPlayer = GameController.gc;
        // gcPlayer2 = GameController2.gc;
        isWalking = false;
        teste = false;
        
    }

  public  void clique()
    {
        teste = true;
        if (teste)
        {
            input_x = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {

        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");
        isWalking = (input_x !=0 || input_y !=0);
        
        if (isWalking)
        {
            var move = new Vector3(input_x,input_y,0).normalized;
            transform.position += move * speed * Time.deltaTime;

            playerAnimator.SetFloat("input_x",input_x);
            playerAnimator.SetFloat("input_y",input_y);


        }
        teste = false;




        playerAnimator.SetBool("isWalking",isWalking);

         if(Input.GetButtonDown("Fire1"))
             playerAnimator.SetTrigger("Atack");

        
        // if(canTeleport && tmpRegion !=null && Input.GetKeyDown(interactKey))
        // {
        //     this.transform.position = tmpRegion.warpLocation.position;
        // }
    }

 
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // if(collider.tag == "Teleport")

        // {
        //     // tmpRegion = collider.GetComponent<Teleport>().region;
        //     canTeleport = true;
        // }

        // if(collider.gameObject.tag == "Notas")
        // {
        //     Destroy(collider.gameObject);
        //     notas++;
        // }

        
        // if(collider.gameObject.tag == "Clave")
        // {
        //     Destroy(collider.gameObject);
        //     gcPlayer.SetClaves(1);
        //     gcPlayer.RefreshScreen();
        //     chaves = gcPlayer.chaves;


        // }

        // if(collider.gameObject.tag == "NotaDo")
        // {
        //     Destroy(collider.gameObject);
        //     gcPlayer2.SetNotasDo(1);


        // }
        // if(collider.gameObject.tag == "NotaRe")
        // {
        //     Destroy(collider.gameObject);
        //     gcPlayer2.SetNotasRe(1);

        // }
        // if(collider.gameObject.tag == "NotaMi")
        // {
        //     Destroy(collider.gameObject);
        //     gcPlayer2.SetNotasMi(1);


        // }
        // if(collider.gameObject.tag == "NotaFa")
        // {
        //     Destroy(collider.gameObject);
        //     gcPlayer2.SetNotasFa(1);


        // }
        // if(collider.gameObject.tag == "NotaSol")
        // {
        //     Destroy(collider.gameObject);
        //     gcPlayer2.SetNotasSol(1);



        // }
        // if(collider.gameObject.tag == "NotaLa")
        // {
        //     Destroy(collider.gameObject);
        //     gcPlayer2.SetNotasLa(1);


        // }
        // if(collider.gameObject.tag == "NotaSi")
        // {
        //     Destroy(collider.gameObject);
        //     gcPlayer2.SetNotasSi(1);


        // }
       

        if(collider.gameObject.tag == "LevelUp" && chaves >0)
        {
            SceneManager.LoadScene("Fase4");
            // gcPlayer.timeCount = 1200f;
        }
        if(collider.gameObject.tag == "LevelUp2")
        {
            SceneManager.LoadScene("FaseFinal");
            // gcPlayer.timeCount = 1200f;
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if(collider.tag == "Teleport")

        {
            // tmpRegion = null;
            canTeleport = false;
        }
        
    }



}
