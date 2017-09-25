using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using System;
using strange.extensions.dispatcher.eventdispatcher.api;

/// <summary>
/// 
/// </summary>
public class InteractionMediator : EventMediator
{
    [Inject]
    public InteractionView intergrationView { get; set; }

    public override void OnRegister()
    {
       
       //---------------监听事件回调---------------------------
        dispatcher.AddListener(ViewEvent.COMPLETE_DEAL, onCompleteDeal);
        dispatcher.AddListener(ViewEvent.COMPLETE_PLAY, onCompletePlay);
        dispatcher.AddListener(ViewEvent.RESTART_GAME, onRestartGame);



        //--------按钮点击事件的回调-------------------
        intergrationView.btn_Deal.onClick.AddListener(OnDealClick);
        intergrationView.btn_Disgrab.onClick.AddListener(onDisgrabClick);
        intergrationView.btn_Grab.onClick.AddListener(onGrabClick);
        intergrationView.btn_Play.onClick.AddListener(onPlayClick);
        intergrationView.btn_Pass.onClick.AddListener(onPassClick);
        //------------注册事件，玩家出牌的---------------------
        RoundModel.PlayerHandler += OnActiveButton;



    }

 

    public override void OnRemove()
    {
        intergrationView.btn_Deal.onClick.RemoveListener(OnDealClick);
        intergrationView.btn_Disgrab.onClick.RemoveListener(onDisgrabClick);
        intergrationView.btn_Grab.onClick.RemoveListener(onGrabClick);
        intergrationView.btn_Play.onClick.RemoveListener(onPlayClick);
        intergrationView.btn_Pass.onClick.RemoveListener(onPassClick);
        //--------------------------------------------------------------
        dispatcher.RemoveListener(ViewEvent.COMPLETE_DEAL, onCompleteDeal);
        dispatcher.RemoveListener(ViewEvent.COMPLETE_PLAY, onCompletePlay);
        dispatcher.RemoveListener(ViewEvent.RESTART_GAME, onRestartGame);


        //-----------------------------------------------
        RoundModel.PlayerHandler -= OnActiveButton;
    }

    #region 回调函数


    private void onRestartGame(IEvent payload)
    {

        intergrationView.DeactiveAll();
        intergrationView.ActiveDeal();

    }
    /// <summary>
    /// 不出按钮的回调
    /// </summary>
    private void onPassClick()
    {
        //发送一个事件

        dispatcher.Dispatch(CommandEvent.PassCard);
        intergrationView.DeactiveAll();

    }

    /// <summary>
    ///出牌的按钮的回调
    /// </summary>
    private void onPlayClick()
    {
        //派发请求按钮的事件
        dispatcher.Dispatch(ViewEvent.REQUST_PLAY);

    }
    /// <summary>
    /// 抢地主的点击回调
    /// </summary>
    private void onGrabClick()
    {

        intergrationView.DeactiveAll();
        //倍数翻倍,地主角色的转换

        GrabLandlorArgs g = new GrabLandlorArgs() { cType=CharacterType.Player};

        dispatcher.Dispatch(CommandEvent.GrabLandLord, g);


    }
    /// <summary>
    /// 不抢地主的点击回调
    /// </summary>
    private void onDisgrabClick()
    {
        intergrationView.DeactiveAll();
        int a = UnityEngine.Random.Range(2, 4);

        GrabLandlorArgs g = new GrabLandlorArgs()
        {
            cType = (CharacterType)a
        };
        dispatcher.Dispatch(CommandEvent.GrabLandLord, g);

    }

    /// <summary>
    /// 发牌结束的回调
    /// </summary>
    /// <param name="payload"></param>
    private void onCompleteDeal(IEvent payload)
    {
        //显示抢地主按钮
        intergrationView.ActiveGrabAndDisgrab();

    }

    /// <summary>
    /// 发牌的回调函数
    /// </summary>
    private void OnDealClick()
    {
        
        //这个方法用来与命令通讯
        dispatcher.Dispatch(CommandEvent.RequestDeal);
        //隐藏发牌按钮
        intergrationView.DeactiveAll();



    }

    /// <summary>
    /// 轮到玩家出牌的委托,激活按钮
    /// </summary>
    private void OnActiveButton(bool canPass)
    {

        intergrationView.ActivePlayAndPass(canPass);

    }


    /// <summary>
    /// 完成出牌的回调
    /// </summary>
    /// <param name="payload"></param>
    private void onCompletePlay(IEvent payload)
    {
        intergrationView.DeactiveAll();


    }

    #endregion





}
