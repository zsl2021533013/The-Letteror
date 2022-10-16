using UnityEngine;
using Cinemachine;

public class RegionSwitch : MonoBehaviour
{
    private CinemachineVirtualCamera CinVC;
    private void Awake()
    {
        CinVC = GetComponentInChildren<CinemachineVirtualCamera>();
        CinVC.Follow = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            CinVC.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CinVC.enabled = false;
        }
    }
}
