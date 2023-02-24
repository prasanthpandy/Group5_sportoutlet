using System;

namespace OrderBot
{
    public class Session
    {
        private enum State
        {
            WELCOMING, SIZE, PROTEIN
        }

        private State nCur = State.WELCOMING;
        private Order oOrder;

        public Session(string sPhone)
        {
            this.oOrder = new Order();
            this.oOrder.Phone = sPhone;
        }

        public List<String> OnMessage(String sInMessage)
        {
            List<String> aMessages = new List<string>();
            switch (this.nCur)
            {
                case State.WELCOMING:
                    aMessages.Add("Welcome to Group 5 Sports Outlet!");
                    aMessages.Add("Would you like to purchase sports costume or sports goods?");
                    this.nCur = State.SIZE;
                    break;
                case State.SIZE:
                    this.oOrder.Size = sInMessage;
                    this.oOrder.Save();
                    aMessages.Add("What goods would you like to buy from " + this.oOrder.Size + "sports goods ?");
                    this.nCur = State.PROTEIN;
                    break;
                case State.PROTEIN:
                    string sProtein = sInMessage;
                    aMessages.Add("Goods size would you like on this (1. size 7 2. size 8) " + this.oOrder.Size + " " + sProtein + " sports goods?");
                    break;


            }
            aMessages.ForEach(delegate (String sMessage)
            {
                System.Diagnostics.Debug.WriteLine(sMessage);
            });
            return aMessages;
        }

    }
}
