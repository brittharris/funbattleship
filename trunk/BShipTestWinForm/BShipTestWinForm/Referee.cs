using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BShipLogic;

namespace BShipTestWinForm
{
    class Referee
    {
        GameController gm;

        internal GameController GM
        {
            get
            {
                if (gm == null)
                {
                    gm = new GameController();
                }
                return gm; 
            }
           
        }

        internal static void Attack(int row, int col)
        {
            //pass this to the other side
            BShipTestWinForm.Referee.AttacksReciever();
            

        }

        public static void AttacksReciever()
        {

        }

        public void AsyncAttacksReciever()
        {
            
        }


        
    }
}
