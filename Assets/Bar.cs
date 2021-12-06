using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{

    public GameObject bar;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateBar()
    {

        bar.transform.DOScaleX(1, time);

        StartCoroutine(StartScaleBar());
       
    }

    IEnumerator StartScaleBar()
    {
        yield return new WaitForSeconds(3f);
        bar.transform.DOScaleX(0, time);
        yield return new WaitForSeconds(3f);
        AnimateBar();
    }
}
