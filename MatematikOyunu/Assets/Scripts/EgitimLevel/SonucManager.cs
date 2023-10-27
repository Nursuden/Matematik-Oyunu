using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{

    [SerializeField]
    private GameObject sonucImage;

    [SerializeField]
    private Text dogruText, yanlisText, puanText;

    [SerializeField]
    private GameObject puanObje, timerObje, dogruYanlisObje, geriDonBtnObje, daireObje;


    private void OnEnable()
    {
        sonucImage.transform.DOLocalMove(Vector3.zero, 0.5f).SetEase(Ease.OutBack);
        sonucImage.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        EkraniTemizle();
    }
    
    
    public void SonuclariYazdir(int dogruAdet,int yanlisAdet,int toplamPuan)
    {
        dogruText.text = dogruAdet.ToString() + " Doğru";
        yanlisText.text = yanlisAdet.ToString() + " Yanlış";
        puanText.text = toplamPuan.ToString() + " Puan";
        

    }

    void EkraniTemizle()
    {
        puanObje.SetActive(false);
        timerObje.SetActive(false);
        dogruYanlisObje.SetActive(false);
        geriDonBtnObje.SetActive(false);
        daireObje.SetActive(false);
    }


    public void TekrarOyna()
    {
        SceneManager.LoadScene("MenuLevel"); 
    }
}
