using UnityEngine;
using UnityEngine.AI;

public class RayCast : MonoBehaviour
{
    protected NavMeshHit _hit;

    public bool IsBlocked(GameObject target)
    {
        bool blocked = NavMesh.Raycast(transform.position, target.transform.position, out _hit, NavMesh.AllAreas);

        Debug.DrawLine(transform.position, target.transform.position, blocked ? Color.red : Color.green);

        if (blocked)
        {
            Debug.DrawRay(_hit.position, Vector3.up, Color.red);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UnityRaycastNotWorking()
    {
        //TO BE RESEARCHED WHY UNITY RAYCAST IS BUGGY
        //bool hasHitSomething = Physics.Raycast(originObject.transform.position, playerObject.transform.position, out RaycastHit hit); //maybe it doesnt detect the player because of layers

        //Debug.DrawLine(originObject.transform.position, playerObject.transform.position, hasHitSomething ? Color.red : Color.green);

        //if (hasHitSomething && hit.collider.tag == "Player")
        //{
        //    Debug.DrawRay(hit.transform.position, Vector3.up, Color.red);
        //    Debug.Log("Player hit");
        //    return false;
        //}
        //else
        //{
        //    Debug.Log("Player not hit");
        //    return true;
        //}
    }
}
