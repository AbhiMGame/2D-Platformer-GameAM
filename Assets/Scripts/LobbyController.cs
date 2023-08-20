using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button playgamebutton;
    [SerializeField] private Button quitgamebutton;


    private void Awake()
    {
        playgamebutton.onClick.AddListener(Playgame);
        playgamebutton.onClick.AddListener(Quitgame);
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
