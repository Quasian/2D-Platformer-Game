using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;

   


    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        PlayerAnimation(horizontal, vertical);
        PlayerMovement(horizontal,vertical);
        PlayerJump(horizontal);
        PlayerCrouch();
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
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
              animator.SetTrigger("Jump");            
              
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
       Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
    }



}
