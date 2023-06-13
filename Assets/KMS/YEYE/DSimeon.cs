using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DSimeon : MonoBehaviour
{
    //[SerializeField] public cameraShake camerashaking;
    //[SerializeField] public float shakeIntensity = 10;
    //[SerializeField] public float shakeTime = 6;

    public GameObject player;
    public GameObject Goals;
    public GameObject Goals1;
    public GameObject Next;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;
    public GameObject Text6;
    public GameObject Text7;
    public GameObject Text8;
    public GameObject Text9;
    public GameObject Text10;
    public GameObject Text11;
    public GameObject Text12;
    public GameObject Text13;
    public GameObject Text14;
    public GameObject Text15;
    public GameObject Text16;
    public GameObject Text17;
    public bool lockkk = true;

    public Image pPortrait;

    public Sprite pIdle;
    public Sprite pAngry;
    public Sprite pSurprised;
    public Sprite pSmile;

    public Sprite pSimeon;

    // Start is called before the first frame update
    void Start()
    {
        //camerashaking.ShakeCamera(shakeIntensity, shakeTime);

        player.GetComponent<MovePlayer>().enabled = false;
        Next.SetActive(false);
        pPortrait.sprite = pSimeon;
        StartCoroutine(Cooldown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SimeonDialogue()
    {
        if (lockkk == false)
        {
            if (Text1.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pSimeon;

                Text1.SetActive(false);
                Text2.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text2.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pSurprised;

                Text2.SetActive(false);
                Text3.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text3.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pIdle;

                Text3.SetActive(false);
                Text4.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text4.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pSimeon;

                Text4.SetActive(false);
                Text5.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text5.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pSimeon;

                Text5.SetActive(false);
                Text6.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text6.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pSimeon;

                Text6.SetActive(false);
                Text7.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text7.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pIdle;

                Text7.SetActive(false);
                Text8.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text8.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pSimeon;

                Text8.SetActive(false);
                Text9.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text9.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pSimeon;

                Text9.SetActive(false);
                Text10.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text10.activeSelf == true && lockkk == false) //11
            {
                Next.SetActive(false);
                pPortrait.sprite = pSimeon;

                Text10.SetActive(false);
                Text11.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text11.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pSmile;

                Text11.SetActive(false);
                Text12.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text12.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pSmile;

                Text12.SetActive(false);
                Text13.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text13.activeSelf == true && lockkk == false) //14
            {
                Next.SetActive(false);
                pPortrait.sprite = pIdle;

                Text13.SetActive(false);
                Text14.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text14.activeSelf == true && lockkk == false) //15
            {
                Next.SetActive(false);
                pPortrait.sprite = pSimeon;

                Text14.SetActive(false);
                Text15.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text15.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pSurprised;

                Text15.SetActive(false);
                Text16.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }
            else if (Text16.activeSelf == true && lockkk == false)
            {
                Next.SetActive(false);
                pPortrait.sprite = pSmile;

                Text16.SetActive(false);
                Text17.SetActive(true);

                lockkk = true;
                StartCoroutine(Cooldown());
            }

            else if (Text17.activeSelf == true && lockkk == false)
            {
                Goals.SetActive(false);
                Goals1.SetActive(true);
                player.GetComponent<MovePlayer>().enabled = true;
                Destroy(gameObject);
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
