using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Levels
{
    [RequireComponent(typeof(Button))]
    public class LevelLoader : MonoBehaviour
    {
        private Button buttonName;
        public string levelName;

        private void Awake()
        {
            buttonName = GetComponent<Button>();
            buttonName.onClick.AddListener(OnCclick);
        }

        private void OnCclick()
        {
            LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
            switch(levelStatus)
            {
                case LevelStatus.Locked:
                    Debug.Log("Can't Play this as its locked");
                    break;
                case LevelStatus.Unlocked:
                    SceneManager.LoadScene(levelName);
                    break;
                case LevelStatus.Completed:
                    SceneManager.LoadScene(levelName); 
                    break;
            }
            
        }

       
    }
}