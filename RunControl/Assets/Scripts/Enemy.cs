using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject attack_target;
    public NavMeshAgent _navMesh;
    bool isAttackStart;


    public void Animation_Trigger()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        isAttackStart = true;
    }

    private void LateUpdate()
    {
        if (isAttackStart)
        {
            _navMesh.SetDestination(attack_target.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Alt_Player"))
        {
            Vector3 newPosition = new Vector3(transform.position.x, 0.24f, transform.position.z);

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().Created_Destroy_Effect(newPosition, false, true);
            gameObject.SetActive(false);
        }
    }
}
