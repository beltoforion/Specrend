using System;


namespace SpecRend
{
    class Program
    {
        /// <summary>
        ///  Built-in test program which displays the x, y, and Z and RGB
        ///    values for black body spectra from 1000 to 10000 degrees kelvin.
        ///    When run, this program should produce the following output:
        ///
        ///    Temperature       x      y      z       R     G     B
        ///    -----------    ------ ------ ------   ----- ----- -----
        ///       1000 K      0.6528 0.3444 0.0028   1.000 0.007 0.000 (Approximation)
        ///       1500 K      0.5857 0.3931 0.0212   1.000 0.126 0.000 (Approximation)
        ///       2000 K      0.5267 0.4133 0.0600   1.000 0.234 0.010
        ///       2500 K      0.4770 0.4137 0.1093   1.000 0.349 0.067
        ///       3000 K      0.4369 0.4041 0.1590   1.000 0.454 0.151
        ///       3500 K      0.4053 0.3907 0.2040   1.000 0.549 0.254
        ///       4000 K      0.3805 0.3768 0.2428   1.000 0.635 0.370
        ///       4500 K      0.3608 0.3636 0.2756   1.000 0.710 0.493
        ///       5000 K      0.3451 0.3516 0.3032   1.000 0.778 0.620
        ///       5500 K      0.3325 0.3411 0.3265   1.000 0.837 0.746
        ///       6000 K      0.3221 0.3318 0.3461   1.000 0.890 0.869
        ///       6500 K      0.3135 0.3237 0.3628   1.000 0.937 0.988
        ///       7000 K      0.3064 0.3166 0.3770   0.907 0.888 1.000
        ///       7500 K      0.3004 0.3103 0.3893   0.827 0.839 1.000
        ///       8000 K      0.2952 0.3048 0.4000   0.762 0.800 1.000
        ///       8500 K      0.2908 0.3000 0.4093   0.711 0.766 1.000
        ///       9000 K      0.2869 0.2956 0.4174   0.668 0.738 1.000
        ///       9500 K      0.2836 0.2918 0.4246   0.632 0.714 1.000
        ///      10000 K      0.2807 0.2884 0.4310   0.602 0.693 1.000
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            double t, x, y, z, r, g, b;

            Console.WriteLine("Temperature       x      y      z       R     G     B\n");
            Console.WriteLine("-----------    ------ ------ ------   ----- ----- -----\n");

            for (t = 1000; t <= 10000; t += 500)
            {
                Kernel.SpectrumToXyz((double waveLength) => { return Kernel.BlackBodySpectrum(waveLength, t); }, out x, out y, out z);
                Kernel.XyzToRgb(ColourSystems.SMPTE, x, y, z, out r, out g, out b);

                Console.Write(string.Format("  {0} K      {1:0.0000} {2:0.0000} {3:0000}", t, x, y, z));

                if (Kernel.ConstrainRgb(ref r, ref g, ref b))
                {
                    Kernel.NormRgb(ref r, ref g, ref b);
                    Console.Write(string.Format("  {0:0.000} {1:0.000} {2:0.000} (Approximation)\n", r, g, b));
                }
                else
                {
                    Kernel.NormRgb(ref r, ref g, ref b);
                    Console.Write(string.Format("  {0:0.000} {1:0.000} {2:0.000}\n", r, g, b));
                }
            }
        }
    }
}
