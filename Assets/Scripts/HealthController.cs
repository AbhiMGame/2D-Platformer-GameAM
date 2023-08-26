﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float startingHealth=0.3f;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    private float scenloadDelay=20f;
    [SerializeField]private Button buttonRestart;
    [SerializeField] private Button buttonQuit;
    [SerializeField] private Button returntoLevels;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonQuit.onClick.AddListener(Backtolobby);
        returntoLevels.onClick.AddListener(BacktoLevels);
    }

    public void Update()
    {
        scenloadDelay -= Time.deltaTime;
        
        if (scenloadDelay < 0 && dead)
        {
            ReloadLevel();
        }
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth>0)
        {
            anim.SetTrigger("hurt");

        }
       
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                SoundManager.Instance.Play(SoundManager.Sounds.PlayerDeath);
                GetComponent<PlayerController>().ShowGameOverPanel();
               
                dead = true;
            }
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
    }

    void Backtolobby()
    {
        SceneManager.LoadScene(0);
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
    }

    void BacktoLevels()
    {
        SceneManager.LoadScene(1);
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
    }
}
