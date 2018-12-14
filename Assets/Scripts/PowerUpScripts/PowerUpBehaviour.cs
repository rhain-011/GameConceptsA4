using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour {

    public PowerUpController controller;

    [SerializeField]
    private PowerUp powerup;

    private Transform transform_;

    // Use this for initialization
    void Awake()
    {
        transform_ = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ActivatePowerUp();
            gameObject.SetActive(false);
        }
    }


    private void ActivatePowerUp()
    {
        controller.ActivatePowerup(powerup);
    }

    public void SetPowerUp(PowerUp powerup)
    {
        this.powerup = powerup;
        gameObject.name = powerup.name;
    }
}
