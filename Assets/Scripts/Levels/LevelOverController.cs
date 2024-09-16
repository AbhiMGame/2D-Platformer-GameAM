using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverController : MonoBehaviour
{
    public GameObject NextLevelInto;
    [SerializeField] private Button nextLevel;
    [SerializeField] private Button buttonRestart;
    [SerializeField] private Button buttonQuit;
    

    private void Awake()
    {
        NextLevelInto.SetActive(false);
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonQuit.onClick.AddListener(BacktoLevels);
        nextLevel.onClick.AddListener(NextLevel);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if(collision.gameObject.CompareTag("NextLevelTeleporter"))
        {
            NextLevelInto.SetActive(true);
   
        }

    }
    
    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void BacktoLevels()
    {
        SceneManager.LoadScene(1);
    }
}
