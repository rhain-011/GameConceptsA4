using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusManager : MonoBehaviour {

    public float health;
    private float currentHealth;

    [SerializeField]
    private float flashLength;

    private float flashCounter;

    private Renderer renderer;
    private Color defaultColor;

    // Use this for initialization
    void Start () {
        currentHealth = health;
        renderer = GetComponent<Renderer>();
        defaultColor = renderer.material.GetColor("_Color");
    }
	
	// Update is called once per frame
	void Update () {
        if (currentHealth <= 0.0f)
        {
            Destroy(gameObject);
        }

        if (flashCounter > 0.0f)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0.0f)
            {
                renderer.material.SetColor("_Color", defaultColor);
            }
        }
    }

    public void HurtEnemy(float damage)
    {
        currentHealth -= damage;
        flashCounter = flashLength;
        renderer.material.SetColor("_Color", Color.red);
    }

}
