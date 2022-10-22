using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformspawn : MonoBehaviour
{
	public List<GameObject> platformlist = new List<GameObject>();

	[SerializeField]
	private GameObject platformModel;
	[SerializeField]
	private GameObject platformModel2;
	[SerializeField]
	private GameObject player;

	GameObject platformInstantiate;

	private int zSpacing = 30;

	void Start()
	{

		for (int i = 0; i < 20; i++) {
			CreatePlatform();
		}
	}

    void Update()
    {
		if (platformlist.Count >= 1 && Vector3.Distance(player.transform.position, platformlist[platformlist.Count-1].transform.position) < 1000){
			CreatePlatform();
		}
    }

	void CreatePlatform() { 
		int decide = Random.Range(1, 3);
		GameObject block;

		if (decide == 1)
			platformInstantiate = platformModel;
		else
			platformInstantiate = platformModel2;

		block = Instantiate(platformInstantiate) as GameObject;
		block.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), zSpacing);
		block.transform.Rotate(new Vector3(0, 0, 0));

		platformlist.Add(block);
		zSpacing += 35;
	}

}
