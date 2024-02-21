using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLevelManager : MonoBehaviour
{
   private void Update()
   {
      if(SimpleTimer.Instance.timeLeft == 0)
      {
         Debug.Log("Fin nivel");
         // actualizar high score + panel de haberlo superado o no
         // vuelta al main menu
      }
   }
}
