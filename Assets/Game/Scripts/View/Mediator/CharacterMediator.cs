using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using System;

public class CharacterMediator : EventMediator
{
    [Inject]
    public CharacterView characterView { get; set; }

    public override void OnRegister()
    {
        characterView.Init();
        dispatcher.AddListener(CommandEvent.DealCard, OnDealCard);
        dispatcher.AddListener(ViewEvent.COMPLETE_DEAL, onCompleteDeal);
        dispatcher.AddListener(ViewEvent.REQUST_PLAY, onPlayPayCard);
        dispatcher.AddListener(ViewEvent.DEAL_THREECARD, onDelThreeCard);
        dispatcher.AddListener(ViewEvent.SUCCESSED_PLAY, onPlayerSuccessPlay);
        dispatcher.AddListener(ViewEvent.RESTART_GAME, onRestartGame);
        dispatcher.AddListener(ViewEvent.UPDATE_INTEGRATION, onUpdateIntegration);
      RoundModel.ComputionHandler += RoundModel_ComputionHandler;
        dispatcher.Dispatch(CommandEvent.RequestUpdate);
        //-------------------
     
    }



    public override void OnRemove()
    {
        dispatcher.RemoveListener(CommandEvent.DealCard, OnDealCard);
        dispatcher.RemoveListener(ViewEvent.COMPLETE_DEAL, onCompleteDeal);
        dispatcher.RemoveListener(ViewEvent.DEAL_THREECARD, onDelThreeCard);
        dispatcher.RemoveListener(ViewEvent.REQUST_PLAY, onPlayPayCard);
        dispatcher.RemoveListener(ViewEvent.RESTART_GAME, onRestartGame);
        dispatcher.RemoveListener(ViewEvent.SUCCESSED_PLAY, onPlayerSuccessPlay);
        dispatcher.RemoveListener(ViewEvent.UPDATE_INTEGRATION, onUpdateIntegration);
        RoundModel.ComputionHandler -= RoundModel_ComputionHandler;



        //--------------------
     
    }







    #region 回调函数

/// <summary>
/// 跟新积分
/// </summary>
/// <param name="payload"></param>
    private void onUpdateIntegration(IEvent payload)
    {

        GameData datae = payload.data as GameData;
        print(datae.playerIntergration);
        characterView.player.characterUI.SetIntergration(datae.playerIntergration);
        characterView.ComputerLeft.characterUI.SetIntergration(datae.computerLeftIntergration);
        characterView.ComputerRight.characterUI.SetIntergration(datae.computerRightIntergration);

    }

    /// <summary>
    /// 重新，开始
    /// </summary>
    /// <param name="payload"></param>
    private void onRestartGame(IEvent payload)
    {
        //----清楚手牌----
        characterView.player.CardList.Clear();
        characterView.ComputerLeft.CardList.Clear();
        characterView.ComputerRight.CardList.Clear();



    }


    /// <summary>
    /// 电脑自动出牌
    /// </summary>
    /// <param name="obj"></param>
    private void RoundModel_ComputionHandler(ComputerSmartArgs obj)
    {

        StartCoroutine("DelayOneSecound", obj);

    }
    IEnumerator DelayOneSecound(ComputerSmartArgs obj)
    {

        yield return new WaitForSeconds(1f);
        bool can = false;
        switch (obj.characterType)
        {

            case CharacterType.ComputerRight:
                can = characterView.ComputerRight.ComputerSemarPlayCard(obj.cardType, obj.weight, obj.lenght, obj.biggerst == CharacterType.ComputerRight);
                if (can)
                {
                    List<Card> cardList = characterView.ComputerRight.SelectCards;
                    CardType cardType = characterView.ComputerRight.currType;
                    //--------------------------添加牌到桌面----------------




                    characterView.Desk.Clear();//添加牌之前把桌面清空下。这里可以做一个剩余牌数（记牌器），把出的牌临时放到一个数组里面，把总牌数减去手牌减去临时数组，就是剩余牌数，这是一个扩展
                    foreach (Card card in cardList)
                    {
                        characterView.AddCard(CharacterType.Desk, card, false);


                    }


                    //-----------------可以出牌-------------------
                    PlayCardArg ee = new PlayCardArg(cardList.Count, Toos.GetWeight(cardList, cardType), CharacterType.ComputerRight, cardType);


                    if (!characterView.ComputerRight.HasCard)
                    {

                        Identity r = characterView.ComputerRight.Identity;
                        Identity l = characterView.ComputerLeft.Identity;
                        Identity p = characterView.player.Identity;
                        GameOverArgs eee = new GameOverArgs()
                        {
                            ComputerRightWin = true,

                            ComputerLeftWin = l == r ? true : false,
                            PlayWin = p == r ? true: false,


                        };


                        dispatcher.Dispatch(CommandEvent.GameOver,eee);
                       


                    }
                    else
                    {
                        dispatcher.Dispatch(CommandEvent.PlayCard, ee);

                    }



                   





                }
                else
                {
                    dispatcher.Dispatch(CommandEvent.PassCard);


                }

                break;
            case CharacterType.ComputerLeft:

                can = characterView.ComputerLeft.ComputerSemarPlayCard(obj.cardType, obj.weight, obj.lenght, obj.biggerst == CharacterType.ComputerLeft);

                if (can)
                {
                 
                    List<Card> cardList = characterView.ComputerLeft.SelectCards;
                    CardType cardType = characterView.ComputerLeft.currType;
                    //--------------------------添加牌到桌面----------------
                    characterView.Desk.Clear();//添加牌之前把桌面清空下。这里可以做一个剩余牌数（记牌器），把出的牌临时放到一个数组里面，把总牌数减去手牌减去临时数组，就是剩余牌数，这是一个扩展
                    foreach (Card card in cardList)
                    {
                    
                        characterView.AddCard(CharacterType.Desk, card, false);


                    }


                    //-----------------可以出牌-------------------
                    PlayCardArg ee = new PlayCardArg(cardList.Count, Toos.GetWeight(cardList, cardType), CharacterType.ComputerLeft, cardType);

                    if (!characterView.ComputerLeft.HasCard)
                    {

                        Identity r = characterView.ComputerRight.Identity;
                        Identity l = characterView.ComputerLeft.Identity;
                        Identity p = characterView.player.Identity;
                        GameOverArgs eee = new GameOverArgs()
                        {
                            ComputerLeftWin = true,
                            ComputerRightWin = r == l ? true : false,
                            PlayWin = p == l ? true : false,


                      


                        };


                        dispatcher.Dispatch(CommandEvent.GameOver, eee);
                    }
                    else
                    {
                        dispatcher.Dispatch(CommandEvent.PlayCard, ee);

                    }
                }
                else
                {

                    dispatcher.Dispatch(CommandEvent.PassCard);

                }

                break;

            default:
                break;
        }

    }



    /// <summary>
    /// 发牌
    /// </summary>
    /// <param name="payload"></param>
    private void OnDealCard(IEvent payload)
    {
        DealCardArgs e = payload.data as DealCardArgs;
        //发牌就是让ui加ui
        characterView.AddCard(e.cType, e.card, e.selected);



    }
    /// <summary>
    /// 发牌结束的回调
    /// </summary>
    /// <param name="payload"></param>
    private void onCompleteDeal(IEvent payload)
    {
        characterView.player.Sort(false);
        characterView.Desk.Sort(true);

        characterView.ComputerLeft.Sort(true);
        characterView.ComputerRight.Sort(true);

    }
    /// <summary>
    /// 发底牌的回调
    /// </summary>
    /// <param name="payload"></param>
    private void onDelThreeCard(IEvent payload)
    {

        GrabLandlorArgs e = payload.data as GrabLandlorArgs;
        characterView.AddThreeCard(e.cType);



    }

    /// <summary>
    /// 请求玩家出牌事件的回调
    /// </summary>
    /// <param name="payload"></param>
    private void onPlayPayCard(IEvent payload)
    {


        List<Card> cardList = characterView.player.FindSelectCard();
        CardType cardType;

        Rulers.CanPop(cardList, out  cardType);
        //还需要根据上次出牌的类型



        if (cardType != CardType.None)
        {
            //可以出牌
            PlayCardArg e = new PlayCardArg(cardList.Count ,Toos.GetWeight(cardList,cardType),CharacterType.Player,cardType);


            dispatcher.Dispatch(CommandEvent.PlayCard,e );


 

        }
        else
        {
            Debug.Log("请选择正确的牌");

        }


    }


    /// <summary>
    /// 玩家成功出牌
    /// </summary>
    public void onPlayerSuccessPlay()
    {
        List<Card> cardList = characterView.player.FindSelectCard();
        //添加牌到桌面
        characterView.Desk.Clear();//添加牌之前把桌面清空下。这里可以做一个剩余牌数（记牌器），把出的牌临时放到一个数组里面，把总牌数减去手牌减去临时数组，就是剩余牌数，这是一个扩展
        foreach (Card card in cardList)
        {
            characterView.AddCard(CharacterType.Desk, card, false);


        }


        characterView.player.DeleteSelectCardUI();
        //-----游戏胜利的判断-------
        if (!characterView.player.HasCard)
        {

            Identity r = characterView.ComputerRight.Identity;
            Identity l = characterView.ComputerLeft.Identity;
            Identity p = characterView.player.Identity;
            GameOverArgs eee = new GameOverArgs()
            {
                PlayWin = true,
                ComputerRightWin = r == p ? true : false,
                ComputerLeftWin = l == p ? true : false,

                



            };




            dispatcher.Dispatch(CommandEvent.GameOver, eee);


        }


        else
        {
            //---------------发送事件-----------------------------
            dispatcher.Dispatch(ViewEvent.COMPLETE_PLAY);
        }




    }


  
    #endregion



}
