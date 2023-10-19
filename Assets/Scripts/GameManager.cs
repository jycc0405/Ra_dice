using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    private static int m_Cost;
    private static int m_Point;
    public int Cost
    {
        get
        {
            return m_Cost;
        }
        private set
        {
            m_Cost = value;
        }
    }
    
    public int increaseCost;
    public int startCost;
    public int Point
    {
        get
        {
            return m_Point;
        }
        private set
        {
            m_Point = value;
        }
    }
    public int startPoint;
    
    public bool IsGameOver { get; private set; }
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    private void Awake()
    {
        if (instance!=this)
        {
            Destroy(gameObject);
        }

        Cost = startCost;
        Point = startPoint;
        UIManager.instance.UpdateCost(Cost);
        UIManager.instance.UpdatePoint(Point);
    }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<UIManager>().pressed_CostButton += CostButton ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        IsGameOver = true;
        
    }
    
    public void CostButton()
    {
        if (Point>=Cost)
        {
            Point -= Cost;
            Cost += increaseCost;
            UIManager.instance.UpdatePoint(Point);
            UIManager.instance.UpdateCost(Cost);
            DiceSpawner.instance.SpawnDice();
        }
    }
}
