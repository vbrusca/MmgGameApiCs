using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    public class MmgApiTestSuite
    {
        public static double DELTA_D = 0.00001;

        public static void setUpClass()
        {
        }

        public static void tearDownClass()
        {
        }

        public void setUp()
        {
        }

        public void tearDown()
        {
        }

        public void runTestSuite()
        {
            try
            {
                Mmg9SliceUnitTest t1 = new Mmg9SliceUnitTest();
                t1.testGettersSetters();
            }
            catch (Exception e)
            {
                MmgHelper.wr("Mmg9SliceUnitTest Failed:");
                MmgHelper.wrErr(e);
            }
        }
    }
}