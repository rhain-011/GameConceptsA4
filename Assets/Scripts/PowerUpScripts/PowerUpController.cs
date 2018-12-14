using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {

    public GameObject powerupPrefab;
    public List<PowerUp> powerups;
    public Dictionary<PowerUp, float> activePowerups = new Dictionary<PowerUp, float>();
    public Transform spawnPoint;

    private List<PowerUp> keys = new List<PowerUp>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        HandleActivePowerups();

        // todo test case
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnPowerUp(powerups[0], spawnPoint.position);
        }

	}

    public void HandleActivePowerups()
    {
        bool changed = false;

        if (activePowerups.Count > 0.0f)
        {
            foreach(PowerUp powerUp in keys)
            {
                if (activePowerups[powerUp] > 0.0f)
                {
                    activePowerups[powerUp] -= Time.deltaTime;
                }
                else
                {
                    changed = true;
                    activePowerups.Remove(powerUp);
                    powerUp.End();
                }
            }
        }

        if (changed)
        {
            keys = new List<PowerUp>(activePowerups.Keys);
        }

    }

    public void ActivatePowerup(PowerUp powerup)
    {
        if (!activePowerups.ContainsKey(powerup)) {
            powerup.Start();
            activePowerups.Add(powerup, powerup.duration);
        }
        else
        {
            activePowerups[powerup] += powerup.duration;
        }

        keys = new List<PowerUp>(activePowerups.Keys);
    }


    public GameObject SpawnPowerUp(PowerUp powerup, Vector3 position)
    {
        GameObject powerupGameObject = Instantiate(powerupPrefab);

        var powerupBehaviour = powerupGameObject.GetComponent<PowerUpBehaviour>();

        powerupBehaviour.controller = this;

        powerupBehaviour.SetPowerUp(powerup);

        powerupGameObject.transform.position = position;

        // todo test
        powerupGameObject.SetActive(true);

        return powerupGameObject;
    }

}
