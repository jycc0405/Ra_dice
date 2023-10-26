using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour, IAttackable
{
    public List<GameObject> enemyList;

    protected bool HasTarget
    {
        get
        {
            if (enemyList.Count>0)
            {
                return true;
            }

            return false;
        }
    }

    protected float Damage;
    protected float TimeBetAttack;
    private float LastTimeAttack = 0f;
    public bool Dead { get; protected set; }

    public virtual void OnAttack()
    {
        
    }

    public void UpdateEnemyDiceList(List<GameObject> list)
    {
        enemyList = list;
    }
}