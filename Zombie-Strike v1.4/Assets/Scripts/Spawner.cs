using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
public GameObject enemy;
     public float minY, maxY;
     float timer;
     public float maxTime;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= maxTime)
{
Spawn();
timer = 0;
}
    }
    void Spawn()
{
float randYPos = Random.Range(minY,maxY);

GameObject newEnemy = Instantiate(enemy);
}
}

