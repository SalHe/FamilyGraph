﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using FamilyGraph.ViewModel;

namespace FamilyGraph
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            InitViewModel();
            InitData();
        }

        private void InitData()
        {
            _viewModel.FamilyTreeNodes.Add(GenerateDefaultTree());
        }

        private void InitViewModel()
        {
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private FamilyTreeNode GenerateDefaultTree()
        {
            var son1 = new FamilyTreeNode
            {
                Name = "儿子1",
                Type = FamilyTreeNode.NodeType.Male
            };
            var son2 = new FamilyTreeNode
            {
                Name = "儿子2",
                SpouseName = "儿媳妇2",
                Type = FamilyTreeNode.NodeType.Male
            };
            var daughter = new FamilyTreeNode
            {
                Name = "女儿",
                Type = FamilyTreeNode.NodeType.Female
            };

            var me = new FamilyTreeNode
            {
                Name = "我",
                SpouseName = "老婆",
                Type = FamilyTreeNode.NodeType.Male
            };
            me.Children.Add(son1);
            me.Children.Add(son2);
            me.Children.Add(daughter);

            var brother = new FamilyTreeNode
            {
                Name = "哥哥",
                SpouseName = "嫂子",
                Type = FamilyTreeNode.NodeType.Male
            };

            var father = new FamilyTreeNode
            {
                Name = "爸爸",
                SpouseName = "妈妈",
                Type = FamilyTreeNode.NodeType.Male
            };
            father.Children.Add(me);
            father.Children.Add(brother);

            var grandpa = new FamilyTreeNode
            {
                Name = "爷爷",
                SpouseName = "奶奶",
                Type = FamilyTreeNode.NodeType.Male
            };
            grandpa.Children.Add(father);

            return grandpa;
        }
    }
}