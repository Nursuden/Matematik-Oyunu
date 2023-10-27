using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class EgitimMenuLevel : MonoBehaviour
{
   [SerializeField]
   private GameObject startBtn, geriDonBtn;

   [SerializeField]
   private GameObject fadePanel;

   [SerializeField]
   private GameObject kokiciPrefab;

   [SerializeField]
   private Transform content;

   [SerializeField]
   private Sprite[] kokiciResimler;

   [SerializeField]
   private Sprite[] kokDisiResimler;

   [SerializeField]
   private Image kokDisiImage;

   [SerializeField]
   private Text aciklamaText;

   [SerializeField]
   private AudioClip alistirmaClip;




    void Start()
    {
        aciklamaText.text = "";
        fadePanel.SetActive(true);
        fadePanel.GetComponent<CanvasGroup>().alpha = 1;

        fadePanel.GetComponent<CanvasGroup>().DOFade(0,1f).OnComplete(İlkAyariYap);
        
        kokDisiImage.sprite = kokDisiResimler[0];


        if(startBtn!=null)
        {
           startBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    
        
        if(geriDonBtn!=null)
        {
           geriDonBtn.GetComponent<RectTransform>().localScale=Vector3.zero;
        }

        

        

    }

    void İlkAyariYap()
    {

        fadePanel.SetActive(false);

        aciklamaText.text = "Alttaki panelden resimleri sürükleyerek istediğiniz resme tıklayıp üslü ifadenin karşılığını öğrenebilirsiniz.";

        SesiCikar(alistirmaClip);

        ButonlariAc();
        KokiciResimlerOlustur();
    }


     
    void ButonlariAc()
    {
        startBtn.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutBounce);
        geriDonBtn.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutBounce);

    }

    void KokiciResimlerOlustur()
    {
        for(int i=0;i<kokiciResimler.Length;i++)
        {
           GameObject kokiciItem =  Instantiate(kokiciPrefab,content);

           kokiciItem.GetComponent<KokiciButonManager>().butonNo = i;


           kokiciItem.transform.GetChild(3).GetComponent<Image>().sprite = kokiciResimler[i];




        }

       





    }

    public void KokDisiResimiGoster(int butonNo)
    {
        kokDisiImage.sprite = kokDisiResimler[butonNo];
    }


    public void MenuLevelineDon()
    {
        SceneManager.LoadScene("PROJE");
    }

    public void OyunLevelineGit()
    {
        SceneManager.LoadScene("MenuLevel");
    }

    void SesiCikar(AudioClip clip)
    {
        if(clip)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
        }
    }


}
