using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour, IDamageable
{
    public float hp;

    public float speed;

    public bool isAlive;

    public Vector2 curpos;

    public int dicenum;

    public Transform[] checkPoint;

    private int _checkNum;

    public TextMeshPro hpText;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        speed = 3f;
        _checkNum = 0;
        hpText.text = hp.ToString(CultureInfo.CurrentCulture);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, checkPoint[_checkNum].transform.position,
            speed * Time.deltaTime);

        if (transform.position == checkPoint[_checkNum].position)
        {
            _checkNum++;
        }

        if (_checkNum == checkPoint.Length)
        {
            OnPlayerHit();
        }
    }

    void OnPlayerHit()
    {
        Destroy(gameObject);
    }

    public void SetCheckPoint(Transform[] setCheckPoint)
    {
        checkPoint = setCheckPoint;
    }

    public virtual void OnDamage(float damage)
    {
        hp -= damage;
        hpText.text = hp.ToString(CultureInfo.CurrentCulture);
        if (hp <= 0)
        {
            for (int i = 0; i < DiceSpawner.instance.dices.Count; i++)
            {
                DiceSpawner.instance.dices[i].GetComponent<Dice>().enemyList.Remove(gameObject);
            }
            GameManager.instance.CostAdd(20);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Bullet bulletScript = other.GetComponent<Bullet>();
            OnDamage(bulletScript.damage);
        }
    }
}