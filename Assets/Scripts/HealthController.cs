using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float startinghealth=0.3f;
    public float currenthealth { get; private set; }
    private Animator anim;
    private bool dead;
    private float scenloaddelay=20f;
    [SerializeField]private Button buttonrestart;
    [SerializeField] private Button buttonquit;

    private void Awake()
    {
        currenthealth = startinghealth;
        anim = GetComponent<Animator>();
        buttonrestart.onClick.AddListener(ReloadLevel);
        buttonquit.onClick.AddListener(Backtolobby);
    }

    public void Update()
    {
        scenloaddelay -= Time.deltaTime;

        if (scenloaddelay < 0 && dead)
        {
            ReloadLevel();
            
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
                GetComponent<PlayerController>().GameOver.gameObject.SetActive(true);
                GetComponent<PlayerController>().enabled = false;
                
                
                dead = true;
        
                
            }
        }
    }

   void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Backtolobby()
    {
        SceneManager.LoadScene(0);
    }

}
