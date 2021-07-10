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

        delegate void ExecOperation(Operation op, int index, ICodeComponent comp);

        private int UndoCount { get => UndoStack.Count; }
        private int RedoCount { get => RedoStack.Count; }

        public void Undo()
        {
            ExecuteOperation(UndoStack, RedoStack, AddAction, DeleteAction);
        }

        private void AddAction(Operation op, int index, ICodeComponent comp)
        {
            op.Neighbors.Remove(comp);
        }

        private void DeleteAction(Operation op, int index, ICodeComponent comp)
        {
            op.Neighbors.Insert(index, comp);
        }

        public void Redo()
        {
            ExecuteOperation(RedoStack, UndoStack, DeleteAction, AddAction);
        }

        private static void ExecuteOperation(Stack<Operation> fromStack, Stack<Operation> toStack,
            ExecOperation addAction, ExecOperation deleteAction)
        {
            if (fromStack.Count > 0)
            {
                Operation op = fromStack.Pop();
                ICodeComponent changedItem = op.ChangedItem;
                ICodeComponent foundComponent = op.Neighbors.FirstOrDefault(cc =>
                                                cc.ID == changedItem.ID);
                if (op.Type == OperationType.Add)
                    addAction(op, op.Index, changedItem);
                else if (op.Type == OperationType.Delete)
                    deleteAction(op, op.Index, changedItem);
                else
                {
                    op.Neighbors.RemoveAt(op.Neighbors.IndexOf(changedItem));
                    changedItem.Parent.Children.Insert(op.Index, changedItem);
                }
                toStack.Push(op);
            }
        }

        public void Push(Operation op)
        {
            UndoStack.Push(op);
        }

        public void Push(OperationType type, ICodeComponent changedComponent, CodeComponentsCollection neighbors)
        {
            Operation op = new Operation(type, changedComponent, neighbors);
            UndoStack.Push(op);
        }
    }
}
