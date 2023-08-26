using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   [SerializeField] private HealthController playerhealth=null;
    [SerializeField] private Image totalhealthbar=null;
    [SerializeField] private Image currenthealthbar=null;

    private void Start()
    {
        totalhealthbar.fillAmount = playerhealth.currenthealth / 10;
     }

    private void Update()
    {
        currenthealthbar.fillAmount = playerhealth.currenthealth/10;
    }



}

