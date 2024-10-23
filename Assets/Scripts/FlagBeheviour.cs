using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBeheviour : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public string paramName;

    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Color currentColor = spriteRenderer.color;

            this.spriteRenderer.color = new Color(1f, 1f, 1f, 0.75f);
        }
    }
}
