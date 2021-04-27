using CodeReader.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReader.Scripts.ViewModel
{
    public class CodeTreeVM : BaseViewModel
    {
        public CodeTreeVM()
        {
            CodeComponents[0].Children.Add(new CodeComponent("Method", "public void DoSmth()\n{\n}\n", "", CodeComponentType.Method));
        }
        public ObservableCollection<ICodeComponent> CodeComponents { get; set; } = new ObservableCollection<ICodeComponent>()
        {
            new CodeComponent("Class", "public abstract class Avangard\n{\n}\n", "", CodeComponentType.AbstractClass),
           
        };
    }
}
