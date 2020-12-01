using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] GameObject _patrolPointPrefab;
    [SerializeField] PlayerMovement _player;
    public List<GameObject> _patrolPoints;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    Debug.Log("trfienie");
                    _patrolPoints.Add(Instantiate(_patrolPointPrefab, new Vector3(hit.point.x, 0, hit.point.z), Quaternion.identity));
                }
                if (hit.collider.CompareTag("PatrolPoint"))
                {
                    _patrolPoints.Remove(hit.collider.gameObject);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    public List<GameObject> GetPatrolPoints()
    {
        return _patrolPoints;
    }
}
