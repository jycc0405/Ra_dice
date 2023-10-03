using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiceSpawner : MonoBehaviour
{
    public GameObject enemyDicePrefab;

    public float spawnRate;

    private float timeAfterSpawn;
    
    [SerializeField] public Transform[] Check_point;
    
    private int num;

    
    
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = 5f;
        num = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn>=spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject spawnenemyDice = Instantiate(enemyDicePrefab, transform.position, transform.rotation);
            spawnenemyDice.name = "enemyDice" + num;
            num++;
            EnemyDice enemyDiceScript = spawnenemyDice.GetComponent<EnemyDice>();
            enemyDiceScript.setCheckPoint(Check_point);
        }

    }
}
