using CodeBox;
using CodeReader.Scripts.Interfaces;
using CodeReader.Scripts.Enums;
using System.Collections.Generic;
using System.Linq;
using GongSolutions.Wpf.DragDrop;
using System.Threading;

namespace CodeReader.Scripts
{
    public class HistoryStack
    {
        private Stack<Operation> UndoStack { get; set; } = new Stack<Operation>();
        private Stack<Operation> RedoStack { get; set; } = new Stack<Operation>();

        delegate void ExecOperation(Operation op, int index, ICodeComponent comp);

        private int UndoCount { get => UndoStack.Count; }
        private int RedoCount { get => RedoStack.Count; }

        public void Clear()
        {
            UndoStack.Clear();
            RedoStack.Clear();
        }

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

        private void ExecuteOperation(Stack<Operation> fromStack, Stack<Operation> toStack,
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
                    op = ExecuteDropOperation(op);
                toStack.Push(op);
                RemoveDuplicates(toStack);
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

        public void PushDropOp(IDropInfo dropInfo, ICodeComponent beforeDropItem, int index)
        {
            ICodeComponent targetItem = dropInfo.TargetItem as ICodeComponent;
            ICodeComponent sourceItem = dropInfo.Data as ICodeComponent;
            CodeComponentsCollection neighbors = GetNeighbors(beforeDropItem);
            Operation op = new Operation(OperationType.Drop, sourceItem, neighbors, index);
            Push(op);
        }

        private CodeComponentsCollection GetNeighbors(ICodeComponent comp)
        {
            if (comp.Parent == null)
                return App.mainVM.CodeComponents;
            return comp.Parent.Children;
        }

        public int CalculateDropIndex(ICodeComponent beforeDropItem)
        {
            int index = App.mainVM.CodeComponents.IndexOf(beforeDropItem);
            if (beforeDropItem.Parent != null)
                index = beforeDropItem.Parent.Children.IndexOf(beforeDropItem);
            return index;
        }

        private Operation ExecuteDropOperation(Operation op)
        {
            ICodeComponent changedItem = op.ChangedItem;

            CodeComponentsCollection dropNeighbors = GetNeighbors(changedItem);
            int index = CalculateDropIndex(changedItem);//calculate index in pre-drop position of item

            int foundIndex = dropNeighbors.IndexOf(changedItem);
            dropNeighbors.RemoveAt(foundIndex);//remove from last drop position

            ICodeComponent srcItem = (changedItem as CodeComponent).GetCopy();//you need to copy item before drop and parent changing

            op.Neighbors.Insert(op.Index, changedItem);//insert item to position from which it was dropped.

            dropNeighbors = GetNeighbors(srcItem);//init neighbors from dropped position

            return new Operation(OperationType.Drop, changedItem, dropNeighbors, index);    //reinit operation for redo or undo.
        }

        private void RemoveDuplicates(Stack<Operation> stack)
        {
            List<Operation> operations = stack.ToList();
            for(int i = 1; i < operations.Count; i++)
            {
                if (operations[i].ChangedItem.ID == operations[i-1].ChangedItem.ID &&
                    operations[i].Type == operations[i - 1].Type)
                {
                    operations.RemoveAt(i);
                    i--;
                }
            }
            stack = new Stack<Operation>(operations);
        }
    }
}
