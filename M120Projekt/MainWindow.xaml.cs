using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DemoErstellen();
            DemoAbfragen();
        }
        #region Demo
        private void DemoErstellen()
        {
            // ClassB (kurze Syntax)
            DAL.ClassB classB1 = new DAL.ClassB{ TextAttribut = "Kategorie 1", BooleanAttribut = true, DatumAttribut = DateTime.Today};
            Int64 classB1Id = BLL.ClassB.Erstellen(classB1);
            Debug.Print("Kategorie erstellt mit Id:" + classB1Id);
            DAL.ClassB classB2 = new DAL.ClassB { TextAttribut = "Kategorie 2", BooleanAttribut = true, DatumAttribut = DateTime.Today };
            Int64 classB2Id = BLL.ClassB.Erstellen(classB2);
            Debug.Print("Kategorie erstellt mit Id:" + classB2Id);
            // ClassA (detaillierte Syntax)
            DAL.ClassA classA1 = new DAL.ClassA();
            classA1.TextAttribut = "Kunde 1";
            classA1.DatumAttribut = DateTime.Today;
            classA1.FremdschluesselAttribut = classB1;
            Int64 classA1Id = BLL.ClassA.Erstellen(classA1);
            Debug.Print("Kunde erstellt mit Id:" + classA1Id);
        }
        private void DemoAbfragen()
        {
            String output = "";
            // Alle Records ClassA mit Details zu verknüpftem Record aus ClassB
            output += Environment.NewLine + "Alle Records ClassA";
            foreach (DAL.ClassA classA in BLL.ClassA.LesenAlle())
            {
                output += Environment.NewLine + "TextAttribut ClassA:" + classA.TextAttribut;
                output += Environment.NewLine + "TextAttribut ClassB:" + classA.FremdschluesselAttribut.TextAttribut;
            }
            output += Environment.NewLine + "------------------------------------------------------";
            // Alle Records ClassB
            output += Environment.NewLine + "Alle Records ClassB";
            foreach (DAL.ClassB classB in BLL.ClassB.LesenAlle())
            {
                output += Environment.NewLine + "TextAttribut ClassB:" + classB.TextAttribut;
            }
            output += Environment.NewLine + "------------------------------------------------------";
            Debug.Print(output);
        }
        #endregion
    }
}
