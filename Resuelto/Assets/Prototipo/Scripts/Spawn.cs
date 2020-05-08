using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    private Coroutine spawnCorrutina;
    public float wait;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCorrutina == null)
        {
            spawnCorrutina = StartCoroutine(SpawnEnemy());
        }
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(wait);
        Instantiate(enemy,transform.position,Quaternion.identity);
        spawnCorrutina = null;
        yield break;
    }
}
