using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BShipLogic;

namespace BShipServiceLib
{   
    
    public class BShipServiceClass : IBShipService
    {
        GameController gm;

        public GameController GM
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

        public int RecieveAttack(int hitSqaure)
        {
            GM.RecieveAttack(hitSqaure);
            return 1;
        }


        
    }
}
