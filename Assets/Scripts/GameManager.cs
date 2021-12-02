using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> npcs;
    float firstPosition;
    float lastPosition;

    public GameObject greenRedLight;


    void Start()
    {    
      
            StartGame();
            GreenRedLight();
    }

    private void GreenRedLight()
    {
        StartCoroutine(StartGreenRedLight());
    }

    IEnumerator StartGreenRedLight()
    {
        greenRedLight.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(1f);
        greenRedLight.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(1f);
        greenRedLight.GetComponent<Renderer>().material.color = Color.green;
        GreenRedLight();
    }

    private void StartGame()
    {
        if (npcs.Count>0)
            StartCoroutine(CheckMoveChar());
                       
    }
    IEnumerator CheckMoveChar()
    {
        for (int i = 0; i < npcs.Count; i++)
        {
            yield return new WaitForSeconds(0.9f);
            firstPosition = npcs[i].transform.position.x;
            yield return new WaitForSeconds(0.1f);
            lastPosition = npcs[i].transform.position.x;
            Debug.Log(firstPosition - lastPosition);
            if (firstPosition - lastPosition > 0.1f)
            {
                GameObject destroyNpc = npcs[i];
                npcs.Remove(destroyNpc);
                Destroy(destroyNpc);
           
                destroyNpc.GetComponent<NpcController>().KillTween();
                        
            }
          
        }
        StartGame();
    }
  


}
