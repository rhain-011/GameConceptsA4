using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActions : MonoBehaviour {

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private PlayerStatusManager playerStatus;

    // High speed powerup
    public void HighSpeedStartAction()
    {
        playerController.moveSpeed *= 2.0f;
    }

    public void HighSpeedEndAction()
    {
        playerController.moveSpeed = playerController.defaultMoveSpeed;
    }


    // Health powerup
    public void HealthUpStartAction()
    {
        playerStatus.currentHealth += 20.0f;
    }

    public void HealthUpEndAction()
    {

    }
}
