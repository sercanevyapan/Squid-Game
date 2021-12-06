using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class NpcController : MonoBehaviour
{
    public CharStats charStat;

    public float npcPositionXLimit;

    public bool isfinish;
 
    void Start()
    {
        
        StartRun();
        
    }


    private void StartRun()
    {
        if(!isfinish)
            StartCoroutine(StopRun());              
    }

    IEnumerator StopRun()
    {
        
            yield return new WaitForSeconds(charStat.runWait);
            transform.DOMoveX(npcPositionXLimit, charStat.duration);
            gameObject.GetComponent<Animator>().SetTrigger("Run");
            yield return new WaitForSeconds(charStat.runWait);
            gameObject.GetComponent<Animator>().SetTrigger("Idle");
            transform.DOPause();

        StartRun();

    }

    public void KillTween()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Dead");
        if (transform.gameObject != null)
        {
            transform.DOKill();
           
        }
     

    }

    public void RestartNpc()
    {

        transform.DOKill();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Finish")
        {
            isfinish = true;
            
        }
      
    }

}
