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

using Heiflow.Image.ImageSets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heiflow.Image.Recognization
{
    public class ColorClassifier : IColorClassifier
    {
        private Dictionary<int, double> _KnownRGB;
        private Color[] _KnownColors;
        public static double NoData = -9999;

        public ColorClassifier()
        {
            _KnownRGB = new Dictionary<int, double>();
        }
        public Color[] KnownColors
        {
            get
            {
                return _KnownColors;
            }
            set
            {
                _KnownColors = value;
            }
        }

        public double[] KnownValues { get; set; }

        public void Update()
        {
            _KnownRGB.Clear();
            for (int i = 0; i < KnownColors.Length; i++)
            {
                _KnownRGB.Add(_KnownColors[i].ToArgb(), KnownValues[i]);
            }
        }

        public double Classfiy(Color input)
        {
            double classfied = NoData;
            var rgb = input.ToArgb();
            if (_KnownRGB.Keys.Contains(rgb))
            {
                classfied = _KnownRGB[rgb];
            }
            return classfied;
        }
    }
}
