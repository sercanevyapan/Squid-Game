using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class NpcController : MonoBehaviour
{
    public CharStats charStat;

    void Start()
    {
        StartRun();
      
    }

    private void StartRun()
    {
        charStat.RandomizeStats();
        transform.DOMoveX(-6f, charStat.duration);
        StartCoroutine(StopRun());
    }

    IEnumerator StopRun()
    {
        yield return new WaitForSeconds(1f);
        transform.DOPause();
        yield return new WaitForSeconds(3f);
        StartRun();
    }

   
}
