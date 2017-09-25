using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealCardArgs 
{
    public CharacterType cType;
    public Card card;
    public bool selected;



    public DealCardArgs(CharacterType cType,Card card,bool selected )
    {



        this.selected = selected;
        this.card = card;
        this.cType = cType;

    }






}
