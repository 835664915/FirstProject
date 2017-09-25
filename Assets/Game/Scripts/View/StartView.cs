using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartView : EventView
{
    public Image sprit;
    private AudioSource _BgMusic;
    private AudioSource BgMusic
    {
        get { if (_BgMusic==null)
            {
                _BgMusic = GetComponent<AudioSource>();
                

            }
            return _BgMusic;
        }


    }

    private Button btn_one;
    private Button btn_two;
    private Button Bg_music;
   public  void Init()
    {
     

        btn_one = transform.Find("Btn_One").GetComponent<Button>();
        btn_two= transform.Find("Btn_Two").GetComponent<Button>();
        Bg_music=transform.Find("Bg_music").GetComponent<Button>();
        btn_one.onClick.AddListener(onOneClick);
        btn_two.onClick.AddListener(onTwoClick);
        Bg_music.onClick.AddListener(onBgMusic);
        StartCoroutine(UIFX());
    }
    /// <summary>
    /// 单倍按钮点击
    /// </summary>
    private void onOneClick()
    {
        //更改intergrationmodel倍数
        dispatcher.Dispatch(ViewEvent.CHANGE_MULTIPLE, 1);

        StopCoroutine(UIFX());

        Destroy(gameObject);
    }

    /// <summary>
    /// 双倍按钮点击
    /// </summary>
    private void onTwoClick()
    {
        StopCoroutine(UIFX());
        dispatcher.Dispatch(ViewEvent.CHANGE_MULTIPLE, 2);
        Destroy(gameObject);
    }
   bool isOnOff = false;
    private void onBgMusic()
    {

     
        isOnOff = !isOnOff;

        if (isOnOff)
        {

            BgMusic.Play();


        }
        else if(isOnOff==false)
        {
            BgMusic.Stop();

        }



    }
    IEnumerator UIFX()
    {
        float times = 0;
        while (times < 1)
        {


            yield return new WaitForSeconds(0.2f);
            times += 0.2f;
            sprit.GetComponent<RectTransform>().localScale += Vector3.one*0.2f;
            if (sprit.GetComponent<RectTransform>().localScale==Vector3.one)
            {
                sprit.GetComponent<RectTransform>().localScale = Vector3.zero;
                times = 0;


            }





        }




    }

    public    void ViewDestroy()
    {
        btn_one.onClick.RemoveListener(onOneClick);
        btn_two.onClick.RemoveListener(onTwoClick);
        Bg_music.onClick.RemoveListener(onBgMusic);

    }


}
