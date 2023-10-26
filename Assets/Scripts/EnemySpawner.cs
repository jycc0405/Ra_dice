using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyDicePrefab;

    public float spawnRate;

    private float timeAfterSpawn;
    
    [SerializeField] public Transform[] Check_point;
    
    private int num;

    public List<GameObject> EnemyList;

    public Dice[] Dices;


    
    
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = 3f;
        num = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time>timeAfterSpawn+spawnRate)
        {
            timeAfterSpawn = Time.time;
            GameObject spawnenemyDice = Instantiate(enemyDicePrefab, transform.position, transform.rotation);
            EnemyList.Add(spawnenemyDice);
            for (int i = 0; i < DiceSpawner.instance.dices.Count; i++)
            {
                DiceSpawner.instance.dices[i].GetComponent<Dice>().enemyList = EnemyList;
            }
            spawnenemyDice.name = "enemyDice" + num;
            num++;
            Enemy enemyScript = spawnenemyDice.GetComponent<Enemy>();
            enemyScript.SetCheckPoint(Check_point);
        }
    }
}
