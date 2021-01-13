﻿//
// The Visual HEIFLOW License
//
// Copyright (c) 2015-2018 Yong Tian, SUSTech, Shenzhen, China. All rights reserved.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
//
// Note:  The software also contains contributed files, which may have their own 
// copyright notices. If not, the GNU General Public License holds for them, too, 
// but so that the author(s) of the file have the Copyright.
//

using Heiflow.Controls.Tree;
using Heiflow.Controls.WinForm.Properties;
using Heiflow.Models.Generic;
using Heiflow.Models.GHM;
using Heiflow.Presentation.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Heiflow.Controls.WinForm.Project
{
    [Export(typeof( IExplorerNodeCreator))]
    public class DisplayablePropertyNodeCreator : ExplorerNodeCreator
    {
        public DisplayablePropertyNodeCreator()
        {

        }

        public override Type ItemType
        {
            get 
            {
                return typeof(DisplayablePropertyItem);
            }
        }

        public override IExplorerNode Creat(object sender, Models.Generic.IExplorerItem item_attribute)
        {
            var pck = sender as IPackage;
            var mat_menu = ContextMenuFactory.Creat(item_attribute) as IPackageContextMemu;
            mat_menu.Package=pck;
            var name = "none";
            if (item_attribute.PropertyInfo != null)
                name = item_attribute.PropertyInfo.Name;
            else if(item_attribute.Tag != null )
            {
               if(item_attribute.Tag is StaticVariable)
               {
                   name = (item_attribute.Tag as StaticVariable).Name;
               }
               else if (item_attribute.Tag is DynamicVariable)
               {
                   name = (item_attribute.Tag as DynamicVariable).Name;
               }

            }
            Node node_mat = new Node(name)
            {
                Image = Resources.LayerRaster_B_16,
                Tag = mat_menu
            };

            return node_mat;
        }
    }
}
