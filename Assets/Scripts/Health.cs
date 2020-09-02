using Mirror;
using UnityEngine;


[System.Serializable]
public class Health : NetworkBehaviour
{

    public float health = 100f;
    [Client]
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    [Client]
    void Update()
    {
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        NetworkServer.Destroy(gameObject);
    }
}
