using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private bool isPlayerRun;

    void FixedUpdate()
    {
        
        if (Input.GetMouseButtonDown(0)&& isPlayerRun==false)
        {
            transform.DOMoveX(-6f, 12f);
            isPlayerRun = true;
        }
           
       else if (Input.GetMouseButtonDown(0) && isPlayerRun==true)
        {
            transform.DOPause();
            isPlayerRun = false;
        }
            
      
    }
}
