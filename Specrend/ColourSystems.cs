//
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
    public static class ColourSystems
    {
        /// <summary>
        ///  Gamma of nonlinear correction.
        ///    See Charles Poynton's ColorFAQ Item 45 and GammaFAQ Item 6 at:
        ///
        ///    http://www.poynton.com/ColorFAQ.html
        ///    http://www.poynton.com/GammaFAQ.html
        /// </summary>
        public const double GAMMA_REC709 = 0; // Rec. 709

        public static ColourSystem NTSC = new ColourSystem("NTSC",
                                                           new Vector2(0.67, 0.33),            // Red
                                                           new Vector2(0.21, 0.71),            // Green
                                                           new Vector2(0.14, 0.08),            // Blue
                                                           WhitePointChromacity.IlluminantC,   // WhitePoint 
                                                           GAMMA_REC709);

        public static ColourSystem EBU = new ColourSystem("EBU (PAL/SECAM)",
                                                          new Vector2(0.64, 0.33),
                                                          new Vector2(0.29, 0.60),
                                                          new Vector2(0.15, 0.06),
                                                          WhitePointChromacity.IlluminantD65,
                                                          GAMMA_REC709);

        public static ColourSystem SMPTE = new ColourSystem("SMPTE",
                                                            new Vector2(0.630, 0.340),
                                                            new Vector2(0.310, 0.595),
                                                            new Vector2(0.155, 0.070),
                                                            WhitePointChromacity.IlluminantD65,
                                                            GAMMA_REC709);

        public static ColourSystem HDTV = new ColourSystem("HDTV",
                                                           new Vector2(0.670, 0.330),
                                                           new Vector2(0.210, 0.710),
                                                           new Vector2(0.150, 0.060),
                                                           WhitePointChromacity.IlluminantD65,
                                                           GAMMA_REC709);

        public static ColourSystem CIE = new ColourSystem("CIE",
                                                          new Vector2(0.7355, 0.2645),
                                                          new Vector2(0.2658, 0.7243),
                                                          new Vector2(0.1669, 0.0085),
                                                          WhitePointChromacity.IlluminantE,
                                                          GAMMA_REC709);

        public static ColourSystem Rec709system = new ColourSystem("CIE REC 709",
                                                                   new Vector2(0.64, 0.33),
                                                                   new Vector2(0.30, 0.60),
                                                                   new Vector2(0.15, 0.06),
                                                                   WhitePointChromacity.IlluminantD65,
                                                                   GAMMA_REC709);
    }
}
