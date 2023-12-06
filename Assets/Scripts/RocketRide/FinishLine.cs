using Cinemachine;
using DG.Tweening;
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
            Rocket rocket = other.GetComponent<Rocket>();
            rocket.hasFinished = true;

            RocketRideManager.Instance.rocketsWhichHaveFinished.Add(other.gameObject);
            rocketGroup.RemoveMember(other.transform);

            //Stop a stunt coroutine if there is one and launch the finish coroutine when rocket continue to fly
            if (rocket.stuntCoroutine != null)
            {
                StopCoroutine(rocket.stuntCoroutine);
                rocket.transform.DOKill();
                rocket.isStunt = false;
                rocket.stuntCoroutine = null;
            }
            StartCoroutine(rocket.Finish());
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
