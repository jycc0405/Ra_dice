using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDice : MonoBehaviour
{
    public int hp;

    public float speed;

    public bool isAlive;
    
    public Vector2 curpos;

    public int dicenum;

    public Transform[] Check_point;

    private int _checkNum;
    
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        hp = 10;
        speed = 10f;
        _checkNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!isAlive)
        {
            return;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, Check_point[_checkNum].transform.position,
            speed * Time.deltaTime);
        
        if (transform.position==Check_point[_checkNum].position)
        {
            _checkNum++;
        }

        if (_checkNum==Check_point.Length)
        {
            Hit();
        }
    }

    void Hit()
    {
        isAlive = false;
        Destroy(gameObject);
    }

    public void setCheckPoint(Transform[] setCheckPoint)
    {
        Check_point = setCheckPoint;
    }
}
