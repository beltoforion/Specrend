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

namespace SpecRend
{
    /// <summary>
    /// White point chromaticities. 
    /// </summary>
    public static class WhitePointChromacity
    {
        /// <summary>
        /// For NTSC television
        /// </summary>
        public static Vector2 IlluminantC = new Vector2(0.3101, 0.3162);

        /// <summary>
        /// For EBU and SMPTE
        /// </summary>
        public static Vector2 IlluminantD65 = new Vector2(0.3127, 0.3291);

        /// <summary>
        /// CIE equal-energy illuminant
        /// </summary>
        public static Vector2 IlluminantE = new Vector2(0.33333333, 0.33333333);
    }
}
