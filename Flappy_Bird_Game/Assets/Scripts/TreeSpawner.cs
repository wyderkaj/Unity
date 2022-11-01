using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tree;

    private float timeBtwSpawnTree;
    public float StartTimeBtwSpawnTree;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwSpawnTree <= 0)
        {
           Instantiate(tree, transform.position, transform.rotation); 
           timeBtwSpawnTree = StartTimeBtwSpawnTree;
        }
        else
        {
            timeBtwSpawnTree -= Time.deltaTime;
        }
    }
}
