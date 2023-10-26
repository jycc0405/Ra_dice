using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;

    private GameObject target;

    private float speed = 10f;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,5f);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        if (!target.Equals(null))
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position,
                speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GameObject() == target)
        {
            Destroy(gameObject);
        }
    }
    

    public void setTarget(GameObject setTarget)
    {
        target = setTarget;
    }
}