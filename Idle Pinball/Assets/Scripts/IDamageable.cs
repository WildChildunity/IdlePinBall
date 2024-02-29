using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    void TakeDamage(int Damage);
    void Burn(int BurnDamage, float BurnTime, int BurnRounds);
    void DamageEffect(int Damage);
    void Die();
}
