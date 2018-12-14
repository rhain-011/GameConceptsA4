using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour {


    public float maxHealth = 100.0f;
    public float currentHealth;

    [SerializeField]
    private float flashLength;

    private float flashCounter;

    private Renderer renderer;
    private Color defaultColor;


	// Use this for initialization
	void Start () {

        currentHealth = maxHealth;
        renderer = GetComponent<Renderer>();
        defaultColor = renderer.material.GetColor("_Color");
	}
	
	// Update is called once per frame
	void Update () {
        
        // disable player object whenit dies.
		if (currentHealth <= 0.0f)
        {
            gameObject.SetActive(false);
        }


        if(flashCounter > 0.0f)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0.0f)
            {
                renderer.material.SetColor("_Color", defaultColor);
            }
        }
	}

    public void HurtPlayer(float damageToTake)
    {
        currentHealth -= damageToTake;
        flashCounter = flashLength;
        renderer.material.SetColor("_Color", Color.red);
    }

}
