using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBall : Ball
{
    public int sparkDamage;
    public int sparkArea;
    //public int sparkTargets;

    public GameObject lightingParticle;

    public override void Attack(Collision2D other)
    {
        base.Attack(other);
        Spark(other);
    }

    public void Spark(Collision2D other)
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(other.transform.position, sparkArea);
        foreach (Collider2D obj in objects)
        {
            if (obj.GetComponent<IDamageable>() != null && obj.gameObject != other.gameObject)
            {
                GameObject lightning = Instantiate(lightingParticle, other.transform.position, Quaternion.identity);

                // FIND A BETTER WAY
                StartCoroutine(move(lightning, obj.transform.position));

                Destroy(lightning, 0.5f);
                obj.GetComponent<IDamageable>().TakeDamage(sparkDamage);
            }
        }
    }

    // figure out a solution to thus
    IEnumerator move(GameObject lightning, Vector3 pos)
    {
        yield return new WaitForSeconds(0.1f);
        lightning.transform.position = pos;
    }


}
