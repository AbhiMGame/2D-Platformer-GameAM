using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverController : MonoBehaviour
{
    public GameObject NextLevelInto;
    [SerializeField] private Button Nextlevel;
    [SerializeField] private Button buttonrestart;
    [SerializeField] private Button buttonquit;
    private bool doorcollision=false;

    


    private void Awake()
    {
        NextLevelInto.SetActive(false);
        buttonrestart.onClick.AddListener(ReloadLevel);
        buttonquit.onClick.AddListener(BacktoLevels);
        Nextlevel.onClick.AddListener(NextLevel);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if(collision.gameObject.CompareTag("NextLevelTeleporter"))
        {
            
            NextLevelInto.SetActive(true);
            doorcollision = true;
            
            

        }

    }
    
    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void BacktoLevels()
    {
        SceneManager.LoadScene(1);
    }
}
