using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerController : MonoBehaviour
{
    private bool isPlayerRun;

    private bool isStartGame;

    private void Start()
    {
        StartCoroutine(StartedGame());
    }


    IEnumerator StartedGame()
    {
        yield return new WaitForSeconds(3f);
        isStartGame = true;
    }

    void FixedUpdate()
    {
        if(isStartGame)
            PlayerInputControl();
      
            
      
    }

    private void PlayerInputControl()
    {
        if (Input.GetMouseButtonDown(0) && isPlayerRun == false)
        {
            transform.DOMoveX(0f, 15f);
            isPlayerRun = true;
            gameObject.GetComponent<Animator>().SetTrigger("Run");
        }

        else if (Input.GetMouseButtonDown(0) && isPlayerRun == true)
        {
            transform.DOPause();
            isPlayerRun = false;
            gameObject.GetComponent<Animator>().SetTrigger("Idle");
        }
    }

    public void KillTween()
    {
        transform.DOKill();
    }
}
