using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NomalDice : Dice
{
    public float nomalDiceDamage;

    public float nomalDiceTimeBetAttack;

    public float nomalDiceAttackSpeed;

    public GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        Damage = nomalDiceDamage;
        TimeBetAttack = nomalDiceTimeBetAttack;
        
        StartCoroutine(Attack());
    }

    private void OnEnable()
    {
        Dead = false;
        Damage = nomalDiceDamage;
        TimeBetAttack = nomalDiceTimeBetAttack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnAttack()
    {
        GameObject instantiate = Instantiate(bulletPrefab,transform.position,Quaternion.identity);
        instantiate.transform.SetParent(gameObject.transform);
        Bullet instantiateScript = instantiate.GetComponent<Bullet>();
        instantiateScript.setTarget(enemyList[0]);
        instantiateScript.damage = Damage;
    }

    private IEnumerator Attack()
    {
        while(!Dead)
        {
            if (HasTarget)
            {
                OnAttack();
            }
            
            yield return new WaitForSeconds(nomalDiceTimeBetAttack);
        }
    }
}
