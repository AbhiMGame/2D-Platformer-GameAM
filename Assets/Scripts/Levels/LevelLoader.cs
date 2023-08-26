using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Levels
{
    [RequireComponent(typeof(Button))]
    public class LevelLoader : MonoBehaviour
    {
        private Button button;
        public string levelName;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnCclick);
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
                    SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
                    SceneManager.LoadScene(levelName);
                    break;
                case LevelStatus.Completed:
                    SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
                    SceneManager.LoadScene(levelName); 
                    break;
            }
            
        }

       
    }
}