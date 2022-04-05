using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    public Rigidbody2D rb2;
    public bool isGrounded;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    public bool DoubleJump= false;
    public BoxCollider2D deathcollider;
    public ScoreController scoreController;
    public int playerHealth;
    public PlayerHealth healthSystem;



    void Start()
    { 
        
    
    }
    
    
    //Pickup key
    public void PickUpKey()
    {
        Debug.Log("Picked up Key");
        scoreController.IncreaseScore(10);
    }

    //Kill player by enemy
    public void KillPlayer()
    {
        Debug.Log("Player killed by Enemy");
        Destroy(gameObject);
        ReloadLevel();

    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
        
    }


    public void PlayerDamage()
    {
        if (playerHealth > 0)
        { 
            healthSystem.TakeDamage(playerHealth);
            playerHealth--;
        }
    
    }

   
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        PlayerAnimation(horizontal, vertical);
        PlayerMovement(horizontal,vertical);
        PlayerJump(horizontal);
        PlayerCrouch();
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }

    private void PlayerAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

    }
        //JUMP       
        private void PlayerJump(float horizontal)
        {
            if (Input.GetKeyDown(KeyCode.Space) )
            {
              animator.SetBool("Jump", true);  
                    
            }

            else
             {
            animator.SetBool("Jump", false);
             }
            
            
        }

        
         //Crouch
         private void PlayerCrouch()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
               
                animator.SetBool("Crouch", true);
            }
            
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
              
               animator.SetBool("Crouch", false);
            }

        }
      

    private void PlayerMovement(float horizontal, float vertical) 
    {
      //Horizontal Movement
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Vertical Movement
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            Jump();
            DoubleJump = true;
            Debug.Log("First Jump");

        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false)
        {
                Jump();
                DoubleJump = false;
                Debug.Log("Second Jump");
            
        }
        
    }

    //Player Jump
    private void Jump()
    {
        rb2.AddForce(Vector2.up * jump );
    }

    //Player death and Respawn
    public void PlayerDeath()
    {
        transform.position = Vector2.zero;
        Debug.Log("Player has died");
        //Destroy(gameObject);
       
    }
    
    //Player Death
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerDamage();

        }

    }

}