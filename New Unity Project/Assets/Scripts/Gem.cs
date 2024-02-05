using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{
    bool isSpawned = false;
    public float spawnTime;
    public int cnt;
    bool countedDown = false;
    
    public float interval = 3;
    public int roundCnt;
    bool isGoing = false;

    public GameObject[] gemstones;
    public Transform[] spawnPoints;

    public Text cntDownText;
    public float cntDown = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(cntDown >= 0)
        {
           cntDown -= 1 * Time.deltaTime;
            cntDownText.text = cntDown.ToString ("0");
        }
        else
        {
            Destroy(cntDownText);
        }
        
        if (countedDown == false)
        {
            StartCoroutine(CountDown());
        }
        if (isGoing == false && roundCnt > 0 && countedDown == true)
        {
            cnt = Random.Range(1, 5);
            spawnTime = Random.Range(0, 2);
            StartCoroutine(StartRound());
            roundCnt--;
        }

        if(roundCnt == 0)
        {
            FindObjectOfType<Game>().GameOver();
        }
        
            
    }

    IEnumerator Spawn()
    {
        isSpawned = true;
        
        for (int i = 0; i < cnt; i++)
        {
            GameObject cloneGem = Instantiate(gemstones[Random.Range(0, 12)], spawnPoints[Random.Range(0, 5)]);
            Destroy(cloneGem, 2);
        }
        
        yield return new WaitForSeconds(spawnTime);

        isSpawned = false;
    }

    IEnumerator StartRound()
    {
        isGoing = true;
        if(isSpawned == false)
        {
            StartCoroutine(Spawn());
        }

        yield return new WaitForSeconds(interval);
        isGoing = false;
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(15);
        countedDown = true;
    }

   
}
