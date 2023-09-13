using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private List<string> movementList = new List<string>();
    public float moveSpeed = 3f;
    private bool isMoving = false;
    private bool isColliding = false;
    private Vector3 initialPosition;
    private GameController2 gcPlayer2;
    public Animator playerAnimator; // Referência ao componente Animator
    private PlayerLife1 playerLife;

    private AudioSource audioSource;

    public AudioClip sound1;
    public AudioClip sound2;


    private void Start()
    {
        gcPlayer2 = GameController2.gc;
        playerAnimator = GetComponent<Animator>(); // Obtendo o componente Animator
        initialPosition = transform.position;
        playerLife = GetComponent<PlayerLife1>();
        audioSource = GetComponent<AudioSource>();


    }

    private void TocarSom(AudioClip som)
    {
        if (audioSource != null)
        {
            audioSource.clip = som;
            audioSource.Play();
        }
    }
    public void TocarSomDePerda()
    {
        TocarSom(sound2);
    }

    public void MoveLeft()
    {
        if (!isColliding)
            movementList.Add("left");
    }

    public void MoveRight()
    {
        if (!isColliding)
            movementList.Add("right");
    }

    public void MoveUp()
    {
        if (!isColliding)
            movementList.Add("up");
    }

    public void MoveDown()
    {
        if (!isColliding)
            movementList.Add("down");
    }

    public void PlayMovements()
    {
        if (!isMoving && !isColliding)
        {
            StartCoroutine(ExecuteMovements());
        }
    }

    public void setMoveRigth()
    {
        gcPlayer2.SetLoopsRith(1);
    }
    public void setMoveLeft()
    {
        gcPlayer2.SetLoopsLeft(1);
    }
    public void setMoveUp()
    {
        gcPlayer2.SetLoopsUp(1);
    }
     public void setMoveDown()
    {
        gcPlayer2.SetLoopsDown(1);
    }

    public void resetComands()
    {
        gcPlayer2.setReset();
    }
    public void lixeira()
    {
        gcPlayer2.setReset();
        StartCoroutine(ClearConsoleWithDelay());

    }

    private IEnumerator ClearConsoleWithDelay()
    {
        gcPlayer2.AddCommandToHistory("\n\n\n\n\n\n\n" + "limpando console.........");
        yield return new WaitForSeconds(1f);
        gcPlayer2.limparConsole();
        movementList.Clear();
    }
    private IEnumerator ExecuteMovements()
    {
        isMoving = true;

        while (movementList.Count > 0)
        {
            string movement = movementList[0];
            movementList.RemoveAt(0);

            if (isColliding) // Verifica se houve uma colisão e interrompe a rotina
            {
                break;
            }

            switch (movement)
            {
                case "left":
                    MoveCharacter(Vector3.left);
                    break;
                case "right":
                    MoveCharacter(Vector3.right);
                    break;
                case "up":
                    MoveCharacter(Vector3.up);
                    break;
                case "down":
                    MoveCharacter(Vector3.down);
                    break;
                default:
                    break;
            }

            yield return new WaitForSeconds(1f);
        }
        gcPlayer2.AddCommandToHistory("\n\n\n\n\n\n\n"+"limpando console.........");
        yield return new WaitForSeconds(1.5f);
        gcPlayer2.limparConsole();
        if (gcPlayer2.notasColetadas == 0)
        {
            // Nenhuma nota foi coletada, então volta o personagem para a posição inicial
            transform.position = initialPosition;
            playerLife.LoseLife();
        }
        isMoving = false;
    }

    private void MoveCharacter(Vector3 direction)
    {
        Vector3 targetPosition = transform.position + direction * 0.31f;
        transform.position = targetPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
        transform.position = initialPosition;
        movementList.Clear(); // Limpa a lista para interromper os movimentos pendentes
        isColliding = false;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.gameObject.tag == "NotaRe")
        {
            Destroy(collider.gameObject);
            gcPlayer2.SetNotasRe(1);


        }
        if(collider.gameObject.tag == "NotaMi")
        {
            Destroy(collider.gameObject);
            gcPlayer2.SetNotasMi(1);


        }
        if(collider.gameObject.tag == "NotaFa")
        {
            Destroy(collider.gameObject);
            gcPlayer2.SetNotasFa(1);


        }
        if(collider.gameObject.tag == "NotaSol")
        {
            Destroy(collider.gameObject);
            TocarSom(sound1);
            gcPlayer2.SetNotasSol(1);


        }
        if(collider.gameObject.tag == "NotaLa")
        {
            Destroy(collider.gameObject);
            TocarSom(sound1);
            gcPlayer2.SetNotasLa(1);


        }
        if(collider.gameObject.tag == "NotaSi")
        {
            Destroy(collider.gameObject);
            TocarSom(sound1);
            gcPlayer2.SetNotasSi(1);


        }
        if(collider.gameObject.tag == "NotaDo")
        {
            Destroy(collider.gameObject);
            TocarSom(sound1);
            gcPlayer2.SetNotasDo(1);


        }

        if(collider.gameObject.tag == "inimigo")
        {
            TocarSom(sound2);
            TocarSom(sound1);
            playerLife.LoseLife();
            



        }
       


    }

    


}
