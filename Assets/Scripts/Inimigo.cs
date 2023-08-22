using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{

    float speed = 0.25f;
    float input_x;
    float input_y;
    public int count;
    public bool facingRigth =true;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.25f;
        input_x = 1f;
        input_y = 0f;
        count = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        var move = new Vector3(input_x,input_y,0).normalized;
        transform.position += move * speed * Time.deltaTime;
        
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Pedra")
        {
            if(facingRigth)
            {
                input_x = -1;
                Flip();
            }
            
        }
        if(collider.tag == "Pedra2")
        {
            if(!facingRigth)
            {
                input_x = 1;
                Flip();
            }
            
        }

    }

    void Flip()
    {
        facingRigth = !facingRigth;
        Vector3 Scale = transform.localScale;
        Scale.x *=-1;
        transform.localScale = Scale;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
           collision.gameObject.GetComponent<PlayerLife>().LoseLife();
           
        }
    }


    
  
    
}
