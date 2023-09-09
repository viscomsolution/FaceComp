using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGMTcs;

namespace ConsoleCs
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 2)
                return 0;

            FaceComp detector = new FaceComp();

            string imagePath1 = args[0];
            string imagePath2 = args[1];

            FacialCompare result = detector.Compare(imagePath1, imagePath2, true);
            return result.percent;
        }
    }
}
