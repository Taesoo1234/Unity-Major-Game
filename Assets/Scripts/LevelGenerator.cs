using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour
{

    public NavMeshSurface surface;
    public int width = 45;
    public int height = 45;
    public GameObject wall;
    public GameObject player;
    public GameObject enemy;
    public int enemycount = 0;
    private bool playerSpawned = false;
    public bool cangenerate = true;

    // Use this for initialization
    void Start()
    {
        GenerateLevel();
        surface.BuildNavMesh();
    }

    void Update()
    {
        if (enemycount == 0 && cangenerate)
        {
            while (transform.childCount > 0)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }

            GenerateLevel();
            StartCoroutine(GenerationCooldown());
            cangenerate = false;
        }
    }

    IEnumerator GenerationCooldown()
    {
        yield return new WaitForSeconds(2);
        cangenerate = true;
    }

    // Create a grid based level
    void GenerateLevel()
    {
        player.transform.position = new Vector3(-21, 1.6f, 0);
        // Loop over the grid
        for (int x = 0; x <= width; x += 2)
        {
            for (int y = 0; y <= height; y += 2)
            {
                // Should we place a wall?
                if (Random.value > .7f)
                {
                    // Spawn a wall
                    Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                    Instantiate(wall, pos, Quaternion.identity, transform);
                }

                else if (Random.value > .965f)
                {
                    // Spawn an enemy
                    Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                    //Instantiate(enemy, pos, Quaternion.identity, transform);
                    var newEnemy = Instantiate(enemy, pos, Quaternion.identity);
                    newEnemy.transform.parent = gameObject.transform;
                    enemycount = enemycount + 1;
                }
            }
        }
        surface.BuildNavMesh();
    }

    void Death()
    {
        enemycount = enemycount - 1;
    }
}