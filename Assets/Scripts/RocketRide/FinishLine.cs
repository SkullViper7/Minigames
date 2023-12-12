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
    [SerializeField]
    private GameObject gameScreen;

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

            if (!rocket.hasFinished && !RocketRideManager.Instance.gameIsOver)
            {
                rocket.hasFinished = true;

                //Get the chrono
                rocket.chrono = RocketRideChronoManager.Instance.ConvertAnActualChronoIntoATime(RocketRideChronoManager.Instance.actualChrono);

                RocketRideManager.Instance.rocketsWhichHaveFinished.Add(other.gameObject);
                rocketGroup.RemoveMember(other.transform);

                //Stop a stunt coroutine if there is one and launch the finish coroutine when rocket continue to fly
                if (rocket.stunnedCoroutine != null)
                {
                    StopCoroutine(rocket.stunnedCoroutine);
                    rocket.transform.DOKill();
                    rocket.isStunned = false;
                    rocket.stunnedCoroutine = null;
                }
                StartCoroutine(rocket.Finish());
            }
        }

        //If all rockets have finished, camera follow the finish line and show the podium
        if (RocketRideManager.Instance.rocketsWhichHaveFinished.Count == numberOfPlayer)
        {
            RocketRideManager.Instance.gameIsOver = true;
            RocketRideChronoManager.Instance.StopTimer();
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
