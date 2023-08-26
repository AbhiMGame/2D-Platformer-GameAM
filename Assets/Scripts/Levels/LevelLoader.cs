using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Levels
{
    [RequireComponent(typeof(Button))]
    public class LevelLoader : MonoBehaviour
    {

        private Button buttonname;
        [SerializeField] private string Levelname;

        private void Awake()
        {
            buttonname = GetComponent<Button>();
            buttonname.onClick.AddListener(onclick);
        }

        private void onclick()
        {
            SceneManager.LoadScene(Levelname);
        }
    }
}