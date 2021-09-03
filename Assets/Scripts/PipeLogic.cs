using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeLogic : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float despawnXPosition = -7f;
    bool hasScored = false;

    void Update()
    {
        Move(); Despawn(); HandleScore();
    }

    void Move()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    void Despawn()
    {
        if (transform.position.x <= despawnXPosition)
        {
            Destroy(gameObject);
        }
    }

    void HandleScore()
    {
        if (hasScored || transform.position.x >= 0) return;

        GameObject.FindGameObjectWithTag("Player").SendMessage("AddScore");
        hasScored = true;
    }
}
