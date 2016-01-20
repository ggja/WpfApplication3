using System;
using Akka.Actor;

namespace WpfApplication3
{
    public partial class ModelActor : ReceiveActor
    {
  
        

        public ModelActor()
        {
            Receive<SetMessage>(message=>SetStoregeItemValue(message));
            Receive<PushNeighborsMessage>(message => PushNeighbors(message));
            Receive<PushCellMessage>(message => PushCell(message));
        }


        public void SetStoregeItemValue(SetMessage message)
        {
            SetCellValue(message.Cell, message.Value);
            Self.Tell(PushNeighborsMessage.CreateMessage(message.Cell));
        }

        public void PushNeighbors(PushNeighborsMessage message)
        {
            foreach (var cell in GetNeighbors(message.Cell))
            {
                Self.Tell(PushCellMessage.CreateMessage(cell));
            }
        }

        public void PushCell(PushCellMessage message)
        {
            
        }

        public class PushCellMessage
        {
            public Tuple<int, int> Cell { get; }
            public PushCellMessage(Tuple<int, int> cell)
            {
                Cell = cell;
            }
            public static PushCellMessage CreateMessage(Tuple<int, int> cell)
            {
                return new PushCellMessage(cell);
            }
        }

        public class SetMessage
        {
            public bool Value { get; }
            public Tuple<int, int> Cell { get;}
            public SetMessage(Tuple<int, int> cell, bool value)
            {
                Value = value;
                Cell = cell;
            }
        }


        public class PushNeighborsMessage
        {
            public Tuple<int,int> Cell { get; }

            public PushNeighborsMessage(Tuple<int, int> cell)
            {
                Cell = cell;
            }

            public static PushNeighborsMessage CreateMessage(Tuple<int, int> cell)
            {
                return new PushNeighborsMessage(cell);
            }
        }


       

    }
}