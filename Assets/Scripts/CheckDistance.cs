using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistance : MonoBehaviour
{

    [SerializeField] private Transform Player;

    void Update()
    {

        for (int i = 0; i < FindObjectOfType<platformspawn>().platformlist.Count; i++){
            if (Vector3.Distance(FindObjectOfType<platformspawn>().platformlist[i].transform.position, Player.position) > 1000)
            {
                FindObjectOfType<platformspawn>().platformlist[i].gameObject.SetActive(false);
            }
            else {
                FindObjectOfType<platformspawn>().platformlist[i].gameObject.SetActive(true);
            }
        }


    
    }
}
