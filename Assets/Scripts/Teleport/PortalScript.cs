using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Transform destination;
    public Transform camDestination;
    public Camera mainCam;

    private bool justTeleported = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !justTeleported)
        {

            other.transform.position = destination.position;
            other.transform.rotation = destination.rotation;


            if (mainCam != null && camDestination != null)
            {
                mainCam.transform.position = camDestination.position;
                mainCam.transform.rotation = camDestination.rotation;
            }


            PortalScript destPortal = destination.GetComponent<PortalScript>();
            if (destPortal != null)
            {
                destPortal.justTeleported = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            justTeleported = false;
        }
    }
}