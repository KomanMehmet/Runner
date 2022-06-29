using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class altPlayer : MonoBehaviour
{
    NavMeshAgent _navMesh;
    public GameManager _gameManager;
    public GameObject target;
    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();       
    }

    private void LateUpdate()
    {
        _navMesh.SetDestination(target.transform.position);
    }

    Vector3 Position()
    {
        return new Vector3(transform.position.x, 0.24f, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("igneliKutu"))
        {         
            _gameManager.Created_Destroy_Effect(Position());
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Testere"))
        {
            _gameManager.Created_Destroy_Effect(Position());
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Pervane_igne"))
        {
            _gameManager.Created_Destroy_Effect(Position());
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Hammer"))
        {
            _gameManager.Created_Destroy_Effect(Position(), true);
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            _gameManager.Created_Destroy_Effect(Position(), false, false);
            gameObject.SetActive(false);
        }
    }
}
