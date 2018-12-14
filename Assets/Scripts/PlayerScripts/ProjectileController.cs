using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float projDamage = 10.0f;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) {
            Destroy(gameObject);
        }
	}


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyStatusManager>().HurtEnemy(projDamage);
            Destroy(gameObject); // desrtroy bullet on collision
        }
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerStatusManager>().HurtPlayer(projDamage);
            Destroy(gameObject);
        }
    }
}
