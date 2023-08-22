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
        public string Levelname;

        private void Awake()
        {
            buttonname = GetComponent<Button>();
            buttonname.onClick.AddListener(onclick);
        }

        private void onclick()
        {
            LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(Levelname);
            switch(levelStatus)
            {
                case LevelStatus.Locked:
                    Debug.Log("Can't Play this as its locked");
                    break;
                case LevelStatus.Unlocked:
                    SceneManager.LoadScene(Levelname);
                    break;
                case LevelStatus.Completed:
                    SceneManager.LoadScene(Levelname); 
                    break;
            }
            
        }

       
    }
}