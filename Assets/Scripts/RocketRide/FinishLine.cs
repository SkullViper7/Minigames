using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public int numberOfPlayer;

    [SerializeField]
    private CinemachineTargetGroup rocketGroup;

    [SerializeField]
    private GameObject podiumScreen;

    private void Start()
    {
        numberOfPlayer = GameManager.Instance.maxPlayerCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Add the rocket which has reached the finish line in the list
        if (other.CompareTag("Rocket")) 
        {
            RocketRideManager.Instance.rocketsWhichHaveFinished.Add(other.gameObject);
            rocketGroup.RemoveMember(other.transform);
            StartCoroutine(other.GetComponent<Rocket>().Finish());
        }

        //If all rockets have finished, camera follow the finish line and show the podium
        if (RocketRideManager.Instance.rocketsWhichHaveFinished.Count == numberOfPlayer)
        {
            rocketGroup.AddMember(transform, 1, 0);
            StartCoroutine(other.GetComponent<Rocket>().Finish());
            StartCoroutine(WaitBeforeShowingPodium());
        }
    }

    private IEnumerator WaitBeforeShowingPodium()
    {
        //Wait for 3 seconds before showing the results
        yield return new WaitForSeconds(3f);
        podiumScreen.SetActive(true);
    }
}
