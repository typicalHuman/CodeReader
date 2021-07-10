using CodeBox;
using CodeReader.Scripts.Interfaces;
using CodeReader.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReader.Scripts
{
    public class HistoryStack
    {
        private Stack<Operation> UndoStack { get; set; } = new Stack<Operation>();
        private Stack<Operation> RedoStack { get; set; } = new Stack<Operation>();

        private int UndoCount { get => UndoStack.Count; }
        private int RedoCount { get => RedoStack.Count; }

        public void Undo()
        {
            if (UndoCount > 0)
            {
                Operation op = UndoStack.Pop();
                ICodeComponent changedItem = op.ChangedItem;
                ICodeComponent foundComponent = op.Neighbors.FirstOrDefault(cc =>
                                                cc.ID == changedItem.ID);
                if (op.Type == OperationType.Add)
                    op.Neighbors.Remove(foundComponent);
                else if (op.Type == OperationType.Delete)
                    op.Neighbors.Insert(op.Index, changedItem);
                else
                    foundComponent = changedItem;
                RedoStack.Push(op);
            }
            
        }

        public void Redo()
        {
            if (RedoCount > 0)
            {
                Operation op = RedoStack.Pop();
                ICodeComponent changedItem = op.ChangedItem;
                ICodeComponent foundComponent = op.Neighbors.FirstOrDefault(cc =>
                                                cc.ID == changedItem.ID);
                if (op.Type == OperationType.Add)
                    op.Neighbors.Insert(op.Index, changedItem);
                else if (op.Type == OperationType.Delete)
                    op.Neighbors.Remove(foundComponent);
                else
                    foundComponent = changedItem;
                UndoStack.Push(op);
            }
        }

        public void Push(Operation op)
        {
            UndoStack.Push(op);
        }
    }
}
