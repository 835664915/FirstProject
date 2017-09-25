using strange.extensions.command.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public    class PlayCardCommand: EventCommand

    {

    [Inject]
    public RoundModel roundModel { get; set; }
    [Inject]
    public IntegrationModel integrationModel { get; set; }

    public override void Execute()
    {
        PlayCardArg e = evt.data as PlayCardArg;


        //判断玩家出牌合不合法


        if (e.cCharacterType == CharacterType.Player)
        {
            if (e.cardType == roundModel.CardType && e.weight > roundModel.CurrentWeight)
            {
                dispatcher.Dispatch(ViewEvent.SUCCESSED_PLAY);


            }
            else if (e.cardType == CardType.Boom && roundModel.CardType != CardType.Boom)
            {
                dispatcher.Dispatch(ViewEvent.SUCCESSED_PLAY);

            }
            else if (e.cardType == CardType.JokerBoom)

            {
                dispatcher.Dispatch(ViewEvent.SUCCESSED_PLAY);

            }

            else if (roundModel.BiggesterCharacter == CharacterType.Player)
            {

                dispatcher.Dispatch(ViewEvent.SUCCESSED_PLAY);
            }
            else
            {


                Debug.Log("不合法的出牌");

                return;
            }

          
        }

        //炸弹翻倍
        if (e.cardType == CardType.Boom || e.cardType == CardType.JokerBoom)
        {

            integrationModel.Multiples *= 2;

        }
        //保存回合信息
        roundModel.BiggesterCharacter = e.cCharacterType;
        roundModel.CardType = e.cardType;
        roundModel.CurrentWeight = e.weight;
        roundModel.CurrentLength = e.length;

        //转换出牌角色
        roundModel.Trun();






    }


    }

