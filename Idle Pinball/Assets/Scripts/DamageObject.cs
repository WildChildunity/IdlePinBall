using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageObject : MonoBehaviour
{
    public int Power;

    private Rigidbody2D rb;

    private TextMeshPro TMP;
    void Start()
    {

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        TMP = GetComponent<TextMeshPro>();

        rb.velocity = Random.insideUnitSphere * Power;
        StartCoroutine(Fade());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Fade()
    {
        while(TMP.color.a > 0)
        {
            Color textcolour = TMP.color;
            textcolour.a -= 0.01f;
            TMP.color = textcolour;
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);

    }
}
