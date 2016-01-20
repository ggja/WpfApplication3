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
            public Cell Cell { get; }
            public PushCellMessage(Cell cell)
            {
                this.Cell = cell;
            }
            public static PushCellMessage CreateMessage(Cell cell)
            {
                return new PushCellMessage(cell);
            }
        }

        public class SetMessage
        {
            public bool Value { get; }
            public Cell Cell { get;}
            public SetMessage(Cell cell, bool value)
            {
                Value = value;
                this.Cell = cell;
            }
        }


        public class PushNeighborsMessage
        {
            public Cell Cell { get; }

            public PushNeighborsMessage(Cell cell)
            {
               this.Cell = cell;
            }

            public static PushNeighborsMessage CreateMessage(Cell cell)
            {
                return new PushNeighborsMessage(cell);
            }
        }


       

    }
}