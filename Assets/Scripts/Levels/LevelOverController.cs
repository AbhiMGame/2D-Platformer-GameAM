using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverController : MonoBehaviour
{
  
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>()!=null)
        {
            //Level is over
            Debug.Log("Level is completed by the player");
           
            LevelManager.Instance.Markcurrentlevelcomplete();
        }

    }

    

}
