﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using LL.BasicTiles.DataModel;
using LL.BasicTiles.ViewModels;
using Metro.LL.Common.Models;

namespace LL.BasicTiles.DataModel
{
    public class DashboardSampleData : DashboardViewModel
    {
        public DashboardSampleData() : base()
        {

        }

        public DashboardItemModel SelectedItem
        {
            get { return Items[0]; }
        }
    }
}