using UnityEngine;
using UnityEngine.AI;
using Units;

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

            //clicked on the floor, move
            if (raycastHit.transform.tag == "Floor")
            {
                targetPosition = raycastHit.point;
                GetComponent<NavMeshAgent>().SetDestination(targetPosition);
            }
            //clicked on enemy, attack
            else if (raycastHit.transform.tag == "Enemy")
            {
                GetComponent<Soldier>().target = raycastHit.transform.GetComponent<Soldier>();
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
