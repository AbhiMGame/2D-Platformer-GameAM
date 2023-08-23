
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthController playerHealth=null;
    [SerializeField] private Image totalHealthbar=null;
    [SerializeField] private Image currentHealthbar=null;

    private void Start()
    {
        totalHealthbar.fillAmount = playerHealth.currentHealth/10 ;
     }

    private void Update()
    {
        currentHealthbar.fillAmount = playerHealth.currentHealth/10;
    }

}

