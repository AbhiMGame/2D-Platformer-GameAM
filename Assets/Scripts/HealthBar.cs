
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthController playerHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;

    private void Start()
    {
        totalHealthbar.fillAmount = playerHealth.currentHealth/10 ;
    }

    public void LateUpdate()
  {
     currentHealthbar.fillAmount = playerHealth.currentHealth/10;
  }

}

