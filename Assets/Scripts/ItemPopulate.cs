using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPopulate : MonoBehaviour
{

    [SerializeField] private List<GameObject> items;
    private RaycastHit hit;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            if (Physics.Raycast(new Vector3(Random.Range(-10, 10), 100, Random.Range(-10, 10)), Vector3.down, out hit))
            {
                if(!hit.transform.tag.Equals("Player"))
                    Instantiate(items[Random.Range(0, items.Count)], hit.point, Quaternion.identity);
            }
        }
    }
}
