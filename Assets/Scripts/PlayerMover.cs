using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{
    public float speed = 3f;
    public Vector3 targetPosition;
	
	void Update ()
    {
        MouseClickWatcher();
        //Move();
    }

    void MouseClickWatcher()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            //cast ray and save information in raycastHit variable
            Physics.Raycast(ray, out raycastHit);

            if (raycastHit.transform != null)
            {
                targetPosition = raycastHit.point;
                GetComponent<NavMeshAgent>().SetDestination(targetPosition);
            }
        }
    }

    //void Move()
    //{
    //    Vector3 direction = targetPosition - transform.position;
    //    direction = direction.normalized;

    //    transform.position += direction * speed * Time.deltaTime;
    //}
}
