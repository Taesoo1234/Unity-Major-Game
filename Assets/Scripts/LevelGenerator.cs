using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour
{
    // the surface to create the NavMesh
    public NavMeshSurface surface;

    // the boundaries for spawning enemies and boxes
    public int width = 45;
    public int height = 45;
    
    // gameobjects used in level generation
    public GameObject wall;
    public GameObject player;
    public GameObject enemy;
    public GameObject powerup;

    // the number of enemies present on the stage
    public int enemycount = 0;

    // bools to determine if the player is spawned and if a level can be generated
    private bool playerSpawned = false;
    public bool cangenerate = true;

    // Start is called before the first frame update
    void Start()
    {
        // generate a level
        GenerateLevel();

        // build a navmesh
        surface.BuildNavMesh();
    }

    void Update()
    {
        // if there are no enemies present and cangenrate is true,
        // destroy all child objects, generate a level and start a cooldown and set cangenerate to false
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
        // wait 2 seconds
        yield return new WaitForSeconds(2);

        // cangenerate is set to true
        cangenerate = true;
    }

    // Create a grid based level
    void GenerateLevel()
    {
        // teleport the player to a new Vector3
        player.transform.position = new Vector3(-21, 1.6f, 0);

        // Loop over the grid
        for (int x = 0; x <= width; x += 2)
        {
            for (int y = 0; y <= height; y += 2)
            {
                // if the random value is greater than .7
                if (Random.value > .7f)
                {
                    // Spawn a wall
                    Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                    Instantiate(wall, pos, Quaternion.identity, transform);
                }

                // if the random value is greater than .965
                else if (Random.value > .965f)
                {
                    // Spawn an enemy
                    Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                    var newEnemy = Instantiate(enemy, pos, Quaternion.identity);

                    // make it a child
                    newEnemy.transform.parent = gameObject.transform;

                    // increase enemycount by 1
                    enemycount = enemycount + 1;
                }

                // if the random value is greater than .99
                else if (Random.value > .99f)
                {
                    // Spawn a powerup
                    Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                    var newPowerup = Instantiate(powerup, pos, Quaternion.identity);

                    // make it a child
                    newPowerup.transform.parent = gameObject.transform;
                }
            }
        }

        // build a new Navemesh
        surface.BuildNavMesh();
    }
    
    // when recieving the message "Death"
    void Death()
    {
        // decrease enemycount by 1
        enemycount = enemycount - 1;
    }
}