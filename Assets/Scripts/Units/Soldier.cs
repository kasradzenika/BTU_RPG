using UnityEngine;
using UnityEngine.AI;

namespace Units
{
    public class Soldier : MonoBehaviour
    {
        public int health = 100;
        public int damage = 10;
        public float attackDistance = 1f;
        public float speed = 1f;
        public Soldier target;

        public virtual void Attack()
        {
            target.GetDamage(damage);
        }

        public virtual void GetDamage(int dmg)
        {
            health -= dmg;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (target == null)
                return;

            Vector3 distanceToTarget = target.transform.position - transform.position;

            if (distanceToTarget.magnitude < attackDistance)
            {
                GetComponent<NavMeshAgent>().Stop();
                Attack();
            }
            else
            {
                GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
            }
        }
    }
}