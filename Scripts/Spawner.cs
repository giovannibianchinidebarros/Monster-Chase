using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] Monsters;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }


    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, Monsters.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(Monsters[randomIndex]);

            if (randomSide == 0)
            {   // Left Side
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = 7;
                spawnedMonster.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {   // Right Side
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -7;
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }  // while


    }


}  // class Spawner 
