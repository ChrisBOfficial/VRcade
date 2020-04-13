using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalloon : MonoBehaviour
{
    public GameObject BlueBalloon;
    public GameObject GreenBalloon;
    public GameObject TurquoiseBalloon;
    public GameObject TealBalloon;
    public GameObject RedBalloon;
    public GameObject PurpleBalloon;
    public GameObject PinkBalloon;
    public GameObject YellowBalloon;
    public GameObject OrangeBalloon;

    int count = 0;

    void Start()
    {
        StartCoroutine(Spawn()); 
    }

    private IEnumerator Spawn() {
        while(true) {
            yield return new WaitForSeconds(10);
            
            if(count == 0) {
                Instantiate(BlueBalloon, new Vector3(Random.Range(1f, 15f), Random.Range(2f, 7f), Random.Range(13f, 16f)), Quaternion.Euler(1,1,0));
                count++;
            }
            else if(count == 1) {
                Instantiate(GreenBalloon, new Vector3(Random.Range(1f, 15f), Random.Range(2f, 7f), Random.Range(13f, 16f)), Quaternion.Euler(1,2,0));
                count++;
            }
            else if(count == 2) {
                Instantiate(TurquoiseBalloon, new Vector3(Random.Range(1f, 15f), Random.Range(2f, 7f), Random.Range(13f, 16f)), Quaternion.Euler(0,3,1));
                count++;
            }
            else if(count == 3) {
                Instantiate(PinkBalloon, new Vector3(Random.Range(1f, 15f), Random.Range(2f, 7f), Random.Range(13f, 16f)), Quaternion.Euler(0,3,-1));
                count++;
            }
            else if(count == 4) {
                Instantiate(YellowBalloon, new Vector3(Random.Range(1f, 15f), Random.Range(2f, 7f), Random.Range(13f, 16f)), Quaternion.Euler(1,3,1));
                count++;
            }
            else if(count == 5) {
                Instantiate(TealBalloon, new Vector3(Random.Range(1f, 15f), Random.Range(2f, 7f), Random.Range(13f, 16f)), Quaternion.Euler(1,1,0));
                count++;
            }
            else if(count == 6) {
                Instantiate(RedBalloon, new Vector3(Random.Range(1f, 15f), Random.Range(2f, 7f), Random.Range(13f, 16f)), Quaternion.Euler(0,3,1));
                count++;
            }
            else if(count == 7) {
                Instantiate(PurpleBalloon, new Vector3(Random.Range(1f, 15f), Random.Range(2f, 7f), Random.Range(13f, 16f)), Quaternion.Euler(0,3,-1));
                count++;
            }
            else {
                Instantiate(OrangeBalloon, new Vector3(Random.Range(1f, 15f), Random.Range(2f, 7f), Random.Range(13f, 16f)), Quaternion.Euler(1,2,0));
                count = 0;
            }
        }
    }

}
