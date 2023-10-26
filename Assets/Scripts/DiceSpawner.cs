using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceSpawner : MonoBehaviour
{
    public GameObject DicePrefab;
    private static DiceSpawner m_instance;
    public List<GameObject> dices;
    
    public static DiceSpawner instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<DiceSpawner>();
            }
            return m_instance;
        }
    }
    
    [SerializeField] public Transform[] SpawnPoint;

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDice()
    {
        int num = Random.Range(0, SpawnPoint.Length);
        GameObject spawnenemyDice = Instantiate(DicePrefab, SpawnPoint[num].position, SpawnPoint[num].rotation);
        dices.Add(spawnenemyDice);
    }
}
