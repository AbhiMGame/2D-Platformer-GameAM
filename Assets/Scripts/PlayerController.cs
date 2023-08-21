using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float force;
    public bool IsPlayerGrounded;
    public GameObject playerposition;
    public ScoreController scoreController;
    public GameObject GameOver;


    private void Awake()
    {
        GameOver.SetActive(false);
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        MoveCharachtar(horizontal);
        PlayMovementAnimation(horizontal);

        float vertical = Input.GetAxisRaw("Vertical");
        if (IsPlayerGrounded == true)
        {
            JumpPlayer(vertical);
        }
        PlayerDeath();
    }

    private void MoveCharachtar(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void JumpPlayer(float vertical)
    {
        Vector3 position = transform.position;
        position.y += vertical * force * Time.deltaTime;
        transform.position = position;
    }

    public void pickupkey()
    {
        Debug.Log("Key has been picked up"); 
        scoreController.IncreaseScore(10);
    }

    private void PlayMovementAnimation(float horizontal)
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

        bool crouch = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("Crouch", crouch);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("GROUND"))
        {
            IsPlayerGrounded = true;
        }
        else
        {
            IsPlayerGrounded = false;
        }


        if (collision.gameObject.CompareTag("NextLevelTeleporter"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }


     void PlayerDeath()
    {
        if(playerposition.transform.position.y<-50)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }

    

}
