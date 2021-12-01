using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (Input.GetMouseButtonDown(0))
            transform.DOMoveX(-6f, 12f);
        if (Input.GetMouseButtonDown(1))
            transform.DOPause();

    }
}
