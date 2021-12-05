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
        transform.DOKill();
        StartCoroutine(StartedGame());
    }


    IEnumerator StartedGame()
    {
        yield return new WaitForSeconds(3f);
        isStartGame = true;
    }

    void Update()
    {
        if(isStartGame)
            PlayerInputControl();
      
            
      
    }

    private void PlayerInputControl()
    {
        if (Input.GetMouseButtonDown(0) && isPlayerRun == false)
        {
            transform.DOMoveX(0f, 20f);
            
            gameObject.GetComponent<Animator>().SetTrigger("Run");
            isPlayerRun = true;
        }

        else if (Input.GetMouseButtonDown(0) && isPlayerRun == true)
        {
            transform.DOPause();
            
            gameObject.GetComponent<Animator>().SetTrigger("Idle");
            isPlayerRun = false;
        }
    }

    public void KillTween()
    {
        isStartGame = false;
        transform.DOKill();
        gameObject.GetComponent<Animator>().SetTrigger("Dead");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            Time.timeScale = 0.0f;

        }


    }
}
