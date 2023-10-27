using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;



public class MenuManager : MonoBehaviour
{


    [SerializeField]
    public GameObject hakkimdaPanel;
    bool panelAcikmi;

    private void Start()
    {
        panelAcikmi = false;
    }


    public void OyunaBasla()
    {
        SceneManager.LoadScene("GameLevel");
    }


    public void HakkimdaPaneliniAc()
    {
        if (!panelAcikmi)
        {
            hakkimdaPanel.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        }
        else
        {
            hakkimdaPanel.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        }
        panelAcikmi = !panelAcikmi;
    }

    public void OyundanCik()
    {
        Application.Quit();
    }
}
