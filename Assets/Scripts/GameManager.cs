using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> npcs;

    Vector3 firstPosition;
    Vector3 lastPosition;

    public GameObject greenRedLight;
    public PlayerController player;

    public Gun gun;


    public float greenTime;
    public float redTime;

    public bool checkRedLight;


    void Start()
    {
        GreenRedLight();    
    }
 
    private void FixedUpdate()
    {
     
       StartCoroutine( CheckMovePlayer());
        //StartCoroutine(CheckMoveChar());
     
    }

    IEnumerator CheckMovePlayer()
    {
       
        if (player!=null && checkRedLight)
        {

            Vector3 startPos =player.transform.position;

            yield return new WaitForSeconds(0.5f);

            Vector3 finalPos = player.transform.position;

            if ((startPos.x - finalPos.x)>0.1f )
            {
                

                gun.Shoot(player.transform);
                player.KillTween();

                //player.SetActive(false);
            }

            


        }

       
    }

    private void GreenRedLight()
    {
        StartCoroutine(StartGreenRedLight());
    }

    IEnumerator StartGreenRedLight()
    {
        greenRedLight.GetComponent<Renderer>().material.color = Color.red;

        checkRedLight = true;
        StartCoroutine(CheckMoveChar());

        yield return new WaitForSeconds(3f);
        greenRedLight.GetComponent<Renderer>().material.color = Color.green;
        

        yield return new WaitForSeconds(3f);
        greenRedLight.GetComponent<Renderer>().material.color = Color.red;
        checkRedLight = true;
        StartCoroutine(CheckMoveChar());
        GreenRedLight();
    }
    IEnumerator CheckMoveChar()
    {
        if (npcs.Count > 0 /*&& checkRedLight*/)
        {
            for (int i = 0; i < npcs.Count; i++)
            {
                if (npcs[i] !=null)
                {
                    firstPosition = npcs[i].transform.position;

                    yield return new WaitForSeconds(0.5f);


                        lastPosition = npcs[i].transform.position;

                    //Debug.Log(firstPosition.x - lastPosition.x);
                    if ((firstPosition.x - lastPosition.x) > 0.15f &&npcs[i] != null)
                    {
                        if (npcs.Count > 0)
                        {
                            GameObject destroyNpc = npcs[i];
                            //npcs.Remove(destroyNpc);

                            gun.Shoot(destroyNpc.transform);

                            destroyNpc.GetComponent<NpcController>().KillTween();
                            Destroy(destroyNpc.GetComponent<NpcController>());

                            //npcController.KillTween(destroyNpc);

                            //destroyNpc.SetActive(false);


                        }


                    }
                }        
             

            }
            checkRedLight = false;


           
        }
        
      
    }





    public void RestartLevel()
    {
        SceneManager.LoadScene("GameScene");

        player.RestartPlayer();
        //foreach (var item in npcs)
        //{
        //    if (item != null)
        //        item.GetComponent<NpcController>().RestartNpc();
        //}
    }


}
