using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIntro : MonoBehaviour
{
    //[SerializeField] public cameraShake camerashaking;
    //[SerializeField] public float shakeIntensity = 10;
    //[SerializeField] public float shakeTime = 6;

    public GameObject player;
    public GameObject Goals;
    public GameObject Next;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public bool lockkk = true;

    public GameObject PlayerUI;
    public Image pPortrait;

    public Sprite pIdle;
    public Sprite pAngry;
    public Sprite pSurprised;
    public Sprite pSmile;

    // Start is called before the first frame update
    void Start()
    {
        //camerashaking.ShakeCamera(shakeIntensity, shakeTime);

        player.GetComponent<MovePlayer>().enabled = false;
        Goals.SetActive(false);
        Next.SetActive(false);
        pPortrait.sprite = pSurprised;
        StartCoroutine(Cooldown());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && lockkk == false)
            {
                if(Text1.activeSelf == true && lockkk == false)
                {
                    Next.SetActive(false);
                    pPortrait.sprite = pIdle;

                    Text1.SetActive(false);
                    Text2.SetActive(true);

                    lockkk = true;
                    StartCoroutine(Cooldown());
                }
                else if(Text2.activeSelf == true && lockkk == false)
                {
                    Next.SetActive(false);
                    pPortrait.sprite = pIdle;

                    Text2.SetActive(false);
                    Text3.SetActive(true);

                    lockkk = true;
                    StartCoroutine(Cooldown());
                }
                else if(Text3.activeSelf == true && lockkk == false)
                {
                    Next.SetActive(false);
                    pPortrait.sprite = pAngry;

                    Text3.SetActive(false);
                    Text4.SetActive(true);

                    lockkk = true;
                    StartCoroutine(Cooldown());
                }

                else if(Text4.activeSelf == true && lockkk == false)
                {
                    Goals.SetActive(true);
                    player.GetComponent<MovePlayer>().enabled = true;
                    Destroy(gameObject);
                }

            }
    }

    public void Dialog()
    {
        if (lockkk == false)
        {
            if (Text1.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pIdle;

                Text1.SetActive(false);
                Text2.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text2.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pIdle;

                Text2.SetActive(false);
                Text3.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text3.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pAngry;

                Text3.SetActive(false);
                Text4.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }

            else if (Text4.activeSelf == true && lockkk == false)
            {
                Goals.SetActive(true);
                player.GetComponent<MovePlayer>().enabled = true;
                Destroy(gameObject);
                PlayerUI.SetActive(true);
            }

        }
    }
    
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2f);
        lockkk = false;
        Next.SetActive(true);

    }
}
