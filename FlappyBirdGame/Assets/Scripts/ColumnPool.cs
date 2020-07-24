using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public GameObject column;
    GameObject[] columns;    

    int columnPoolSize = 5;
    float timeSinceLastSpawned = 0f;
    float spawnRate = 4f;

    int columnNumber;
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columns.Length; i++)
        {
            columns[i] = Instantiate(column);
            columns[i].transform.position = new Vector2(-15f, -20f);
        }
    }

    void Update()
    {
        spawnColumn();
    }

    void spawnColumn()
    {
        if (!GameControl.instance.gameOver)
        {
            timeSinceLastSpawned += Time.deltaTime;

            if (timeSinceLastSpawned > spawnRate)
            {
                // Spawn the column within the object pool
                columns[columnNumber].transform.position = new Vector2(10f, Random.Range(-.5f, 3f));
                columnNumber++;
                timeSinceLastSpawned = 0f;

                if (columnNumber == columns.Length)
                {
                    columnNumber = 0;
                }
            }        
        }
    }
}
