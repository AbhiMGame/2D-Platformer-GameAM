using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float startinghealth=0.3f;
    public float currenthealth { get; private set; }
    private Animator anim;
    private bool dead;
    private float scenloaddelay=8f;

    private void Awake()
    {
        currenthealth = startinghealth;
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        scenloaddelay -= Time.deltaTime;

        if (scenloaddelay < 0 && dead)
        {
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void takedamage(float _damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, startinghealth);

        if(currenthealth>0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerController>().enabled = false;
                dead = true;
                
                
                
            }
        }
    }

   


}
