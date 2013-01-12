using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Expression.Interactivity.Layout;
using DLLgraphe.TraitementGraphique;
using DLLgraphe.Classes;

namespace interfacegraphe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GrapheGraphic monGraphe;
        int mode = 1;
        

        public MainWindow()
        {
            InitializeComponent();
            monGraphe = new GrapheGraphic(canvas_graphe);
        }



        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            monGraphe.graphique(e, mode);   
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            
        }

        private void BtDeplacer_Click(object sender, RoutedEventArgs e)
        {
            mode = 1;
        }

        private void BtAjouter_Click(object sender, RoutedEventArgs e)
        {
            mode = 2;
        }

        private void BtModifier_Click(object sender, RoutedEventArgs e)
        {
            mode = 3;
        }

        private void BtSupprimer_Click(object sender, RoutedEventArgs e)
        {
            mode = 4;
        }

        private void BtArc_Click(object sender, RoutedEventArgs e)
        {
            mode = 5;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void canvas_graphe_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}

