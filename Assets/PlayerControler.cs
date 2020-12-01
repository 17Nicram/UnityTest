using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] Patrol _patrol;
    [SerializeField] NavMeshAgent _player;
    public List<GameObject> _patrolPoints;
    public Vector3 _currentDestination;
    public int _currentDestinationIndex;

    private void Update()
    {
        _patrolPoints = _patrol.GetPatrolPoints();

        if (_patrolPoints.Count > 0)
        {
            if (_currentDestination == null)
            {
                _currentDestinationIndex = 0;
                _currentDestination = _patrolPoints[0].transform.position;
            }

            if (Vector3.Distance(transform.position, _currentDestination) < 0.2f)
            {
                Debug.Log("cel osiagniety: " + _currentDestinationIndex);
                _currentDestinationIndex++;
                if ((_currentDestinationIndex) >= _patrolPoints.Count)
                {
                    _currentDestinationIndex = 0;
                    _currentDestination = _patrolPoints[_currentDestinationIndex].transform.position;
                }
                else
                    _currentDestination = _patrolPoints[_currentDestinationIndex].transform.position;

                /*
                if (_currentDestinationIndex == (_patrolPoints.Count - 1))
                {
                    _currentDestinationIndex = 0;
                    _currentDestination = _patrolPoints[0].transform.position;
                }
                else
                {

                        _currentDestinationIndex++;
                        if ((_currentDestinationIndex + 1) >= _patrolPoints.Count)
                        {
                            _currentDestinationIndex = 0;
                            _currentDestination = _patrolPoints[_currentDestinationIndex].transform.position;
                        }
                        else
                            _currentDestination = _patrolPoints[_currentDestinationIndex].transform.position;
                    
                }*/
            }

            _player.SetDestination(_currentDestination);
        }

    }
}
