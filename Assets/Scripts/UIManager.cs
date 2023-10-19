using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager m_instance;
    public Text textPoint;
    public event Action pressed_CostButton;
    public Text textCost;

    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }

            return m_instance;
        }
    }

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

    public void UpdatePoint(int point)
    {
        textPoint.text = "Point : " + point;
    }

    public void PressCostButton()
    {
        if (pressed_CostButton != null)
        {
            pressed_CostButton();
        }
    }

    public void UpdateCost(int cost)
    {
        textCost.text = cost.ToString();
    }
}