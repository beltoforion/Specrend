﻿//
// Portation Notice: 
//
// This code will compute RGB values for Temperatures based on a Black Body Model.
// It is a C# port of the C-program "specrend.c" written by John walker.
// 
// Please do not bother the original author with questions regarding the C# version.
// I merely ported the code. I did not do any original research on the topic. I did 
// not intent to modify any logic. I cannot guarantee that i did not make 
// mistakes while porting it.
//
// Like the original this program is in the public domain
// 2019 Ingo Berg
//

//---------------------------------------------------------------------------------------------
// Original Copyright Notice from "specrend.c":
//
//            Colour Rendering of Spectra
//
//                   by John Walker
//
//              http://www.fourmilab.ch/
//
//             Last updated: March 9, 2003
//
//       This program is in the public domain.
//  For complete information about the techniques employed in
//  this program, see the World-Wide Web document:
//
//         http://www.fourmilab.ch/documents/specrend/
//
//  The xyz_to_rgb() function, which was wrong in the original
//  version of this program, was corrected by:
//
//        Andrew J. S. Hamilton 21 May 1999
//        Andrew.Hamilton@Colorado.EDU
//        http://casa.colorado.edu/~ajsh/
//
//  who also added the gamma correction facilities and
//  modified constrain_rgb() to work by desaturating the
//  colour by adding white.
//
//  A program which uses these functions to plot CIE
//  "tongue" diagrams called "ppmcie" is included in
//  the Netpbm graphics toolkit:
//
//    http://netpbm.sourceforge.net/
//
//  (The program was called cietoppm in earlier
//  versions of Netpbm.)
using System.Drawing;


namespace SpecRend
{
    public static class TempToColorHelper
    {
        private static void RgbFromTemp(double temp, out double r, out double g, out double b, ColourSystem cs)
        {
            double x, y, z;
            Kernel.SpectrumToXyz((double waveLength) => { return Kernel.BlackBodySpectrum(waveLength, temp); }, out x, out y, out z);
            Kernel.XyzToRgb(cs, x, y, z, out r, out g, out b);

            if (Kernel.ConstrainRgb(ref r, ref g, ref b))
            {
                Kernel.NormRgb(ref r, ref g, ref b);
            }
            else
            {
                Kernel.NormRgb(ref r, ref g, ref b);
            }
        }

        public static Color FromTemp(this Color col, double temp, ColourSystem cs)
        {
            double r, g, b;
            RgbFromTemp(temp, out r, out g, out b, cs);
            return Color.FromArgb(255, (int)r * 255, (int)r * 255, (int)r * 255);
        }

        public static Color FromTemp(this Color col, double temp)
        {
            double r, g, b;
            RgbFromTemp(temp, out r, out g, out b, ColourSystems.SMPTE);
            return Color.FromArgb(255, (int)r * 255, (int)r * 255, (int)r * 255);
        }
    }
}
