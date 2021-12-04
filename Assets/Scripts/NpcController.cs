using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class NpcController : MonoBehaviour
{
    public CharStats charStat;

    public float npcPositionXLimit;

    void Start()
    {
        StartRun();
        
    }

    private void StartRun()
    {
        charStat.RandomizeStats();
 

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
       transform.DOKill();
    }

}
