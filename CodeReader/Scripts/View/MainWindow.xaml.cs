using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Component> components = new List<Component>();

            Component component1 = new Component() { Name = "Car" };
            component1.Members.Add(new Child() { Name = "Move"});
            component1.Members.Add(new Child() { Name = "Repair"});
            component1.Members.Add(new Child() { Name = "Blow" });
            components.Add(component1);
            Component component2 = new Component() { Name = "Plane" };
            component2.Members.Add(new Child() { Name = "Fly" });
            component2.Members.Add(new Child() { Name = "Crash" });
            components.Add(component2);

            componentsTree.ItemsSource = components;
        }

    }
    public class Component
    {
        public Component()
        {

            this.Members = new ObservableCollection<Child>();

        }

        public string Name { get; set; }

        public ObservableCollection<Child> Members { get; set; }
    }

    public class Child
    {
        public string Name { get; set; }
    }
}
