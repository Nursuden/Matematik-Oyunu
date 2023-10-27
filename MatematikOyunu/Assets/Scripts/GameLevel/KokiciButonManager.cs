using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KokiciButonManager : MonoBehaviour
{

    [SerializeField]
    private Image kokiciImage;

    public int butonNo;

    EgitimMenuLevel EgitimMenuLevel;

    private void Awake()
    {
        EgitimMenuLevel=Object.FindObjectOfType<EgitimMenuLevel>();
    }


    public void ButonaTiklandi()
    {
       EgitimMenuLevel.KokDisiResimiGoster(butonNo);
    }
   




}
