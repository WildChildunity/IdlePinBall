using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Ball
{
    public int burnDamage;
    public float burnTime;
    public int burnRounds;

    void Start()
    {
        
    }

    public override void Attack(Collision2D other)
    {
        base.Attack(other);
        other.gameObject.GetComponent<IDamageable>().Burn(burnDamage, burnTime, burnRounds);
    }

}