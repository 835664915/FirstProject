using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using strange.extensions.command.impl;
using strange.extensions.context.api;

/// <summary>
/// 请求发牌的命令
/// </summary>
public class RequestDealCommand : EventCommand
{
    [Inject]
    public CardModel CardModel { get; set; }

    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject gameRoot { get; set; }

    public override void Execute()
    {
      
        //打乱牌的次序
        CardModel.Shuffle();
        //发牌
        gameRoot.GetComponent<GameRoot>().StartCoroutine(IEDeal());
    }

    /// <summary>
    /// 发牌
    /// </summary>
    /// <param name="cType">给谁</param>
    public void DealTo(CharacterType cType)
    {
        //数据到ui视图
        Card card = CardModel.DealCard(cType);
        DealCardArgs e = new DealCardArgs(cType, card, false);


        dispatcher.Dispatch(CommandEvent.DealCard, e);




    }
    IEnumerator IEDeal()
    {
        CharacterType curr = CharacterType.Player;

        for (int i = 0; i < 51; i++)
        {
            if (curr == CharacterType.Desk)
            {
                curr = CharacterType.Player;

            }
            DealTo(curr);


            curr++;
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i< 3; i++)
        {
            DealTo(CharacterType.Desk);


        }

        //------标志发牌结束-------------

        dispatcher.Dispatch(ViewEvent.COMPLETE_DEAL);//发送事件出去


    }



}
