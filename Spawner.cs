using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    [SerializeField]
    private GameObject [] swarmerPrefab;
    //[SerializeField]
    //private GameObject[] bigSwarmerPrefab;

    [SerializeField]
    public float [] swarmerInterval;
    private int number;
    
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    private float y = 1f;
    [SerializeField] private Transform spawnOrigin;

    void Start()
    {
        number=swarmerInterval.Length;
        for (int i=0;i<number;++i)
        {
            StartCoroutine(spawnEnemy(swarmerInterval[i],swarmerPrefab[i]));
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        Vector3 originPos = spawnOrigin != null ? spawnOrigin.position : transform.position;
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        Vector3 spawnPos = originPos + new Vector3(x, y, z);

        GameObject newEnemy = Instantiate(enemy, spawnPos, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}