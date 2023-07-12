using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Material[] materialList;
    //bounds 1 is initialized as smaller
    [SerializeField]private Transform bounds1;
    [SerializeField] private Transform bounds2;
    public int minObjects = 10;
    public int maxObjects = 10;
    // Start is called before the first frame update
    void Start()
    {
        
        int amt = Random.Range(minObjects, maxObjects);
        for(int i = 0; i < amt; i++)
        {
            Vector3 spawnPoint=new Vector3(Random.Range(bounds1.position.x,bounds2.position.x), Random.Range(bounds1.position.y, bounds2.position.y),Random.Range(bounds1.position.z, bounds2.position.z));
            Instantiate(prefab, spawnPoint, Quaternion.identity).GetComponent<Renderer>().material=materialList[Random.Range(0,materialList.Length)];
        }
    }
}
