using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   [SerializeField] private HealthController playerhealth;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currenthealthbar;

    private void Start()
    {
        totalhealthbar.fillAmount = playerhealth.currenthealth / 10;
    }

    private void Update()
    {
        currenthealthbar.fillAmount = playerhealth.currenthealth/10;
    }



}

