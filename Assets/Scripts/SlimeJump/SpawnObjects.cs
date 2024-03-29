using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    float speed;
    public float DistanceToSpawn;

    private void Awake()
    {
        speed = -5;
        if(DistanceToSpawn == 0)
        {
            DistanceToSpawn = transform.position.y;
        }
        
    }

    //Va g�rer la vitesse de l'objet, si il n'est pas l'original il va le d�truire � la fin du niveau sinon si il l'est il va le rendre inactif 
    private void FixedUpdate()
    {
        Vector2 velocite = new Vector2(0, speed * Time.deltaTime);
        transform.Translate(velocite, Space.World);
        if(transform.position.y <= (DistanceToSpawn * -1))
        {
            bool isTheOriginal = false;
            foreach(GameObject _obj in SpawnManager.Instance.spawnObject)
            {
                if(_obj == gameObject) 
                { 
                    gameObject.SetActive(false);
                    Debug.Log(gameObject.name);
                    isTheOriginal = true;
                }
            }
            if(SpawnManager.Instance.coin == gameObject)
            {
                gameObject.SetActive(false);
                Debug.Log(gameObject.name);
                isTheOriginal = true;
            }
            if(!isTheOriginal) 
            {
                Destroy(gameObject);
            }
        }
    }
}
