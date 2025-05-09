using UnityEngine;

public class CamPosition : MonoBehaviour
{
    public Transform CamDestionation;
    public bool isTeleported = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTeleported)
        {
            other.transform.position = CamDestionation.position;
            other.transform.rotation = CamDestionation.rotation;

            CamPosition destPortalTp = CamDestionation.GetComponent<CamPosition>();
            if (destPortalTp != null)
            {
                destPortalTp.isTeleported = false;
            }
        }
    }
}
