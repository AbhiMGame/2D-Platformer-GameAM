using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button playgameButton;
    [SerializeField] private Button quitgameButton;

    

    private void Awake()
    {

        playgameButton.onClick.AddListener(Playgame);
        playgameButton.onClick.AddListener(Quitgame);
    }

    private void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Quitgame()
    {
        Application.Quit();
        Debug.Log("Applicationbn exited");
    }


}
