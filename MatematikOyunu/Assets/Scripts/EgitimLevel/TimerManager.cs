using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    [SerializeField]
    private GameObject sonucPaneli;

    int kalanSure;
    bool sureSaysinmi;

   GameManager gameManager;



  SonucManager sonucManager;

  [SerializeField]
  private AudioClip oyunBitisSesi;

  private void Awake()
  {
      gameManager = Object.FindObjectOfType<GameManager>();
  }

 
    
    void Start()
    {
        kalanSure = 90;
        sureSaysinmi = true;

        StartCoroutine(SureTimerRoutine());
    }

    IEnumerator SureTimerRoutine()
    {
        while(sureSaysinmi)
        {
            yield return new WaitForSeconds(1f);

            if(kalanSure<10)
            {
               timerText.text = "0"+kalanSure.ToString();
               timerText.color = Color.red; 
            }else
            {
                timerText.text = kalanSure.ToString();
            }

            if(kalanSure<=0)
            {
                sureSaysinmi = false;
                timerText.text = "";
                sonucPaneli.SetActive(true);

                SesiCikar(oyunBitisSesi);

                if(sonucPaneli!=null)
                {
                    sonucManager = Object.FindObjectOfType<SonucManager>();
                    sonucManager.SonuclariYazdir(gameManager.dogruAdeti,gameManager.yanlisAdeti,gameManager.toplamPuan);
                    
                }
            }

            kalanSure--;
        
        }
    }


     void SesiCikar(AudioClip clip)
    {
        if(clip)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
        }
    }
}
