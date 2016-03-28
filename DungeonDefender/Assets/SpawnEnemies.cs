using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

    public Transform spawnPoint;
    public GameObject[] enemies;

    private float spawnTime = 2;
    private bool spawnOn = true;
	
	// Update is called once per frame
	void Update () {
	    if(spawnOn)
        {
            Instantiate(enemies[0], spawnPoint.position, spawnPoint.rotation);
            spawnOn = false;
            StartCoroutine(CountDown(spawnTime));

        }
	}

    IEnumerator CountDown(float spawnTime)
    {

        yield return new WaitForSeconds(spawnTime);
        spawnOn = true;
    }
}
