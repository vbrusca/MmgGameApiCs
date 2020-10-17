using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;

//Converted
namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgLabelValuePairUnitTest_2
    {

        public MmgLabelValuePairUnitTest_2()
        {
        }

        [TestInitialize]
        public static void setUpClass()
        {
        }

        [TestCleanup]
        public static void tearDownClass()
        {
        }

        public void setUp()
        {
        }

        public void tearDown()
        {
        }

        [TestMethod]
        public void test1()
        {
            MmgLabelValuePair l1, l2, l3 = null;

            l1 = new MmgLabelValuePair();
            l3 = new MmgLabelValuePair();

            Assert.AreEqual(true, l1.GetLabel().ApiEquals(new MmgFont(MmgFontData.GetFontBold())));
            Assert.AreEqual(true, l1.GetValue().ApiEquals(new MmgFont(MmgFontData.GetFontNorm())));
            Assert.AreEqual(true, l1.GetPaddingX() == MmgLabelValuePair.DEFAULT_PADDING_X);
            Assert.AreEqual(true, l1.GetHeight() == 0);
            Assert.AreEqual(true, l1.GetWidth() == 0);

            l1.SetFontSize(15);
            Assert.AreEqual(true, l1.GetFontSize() == 15);

            l1.SetLabel(MmgFontData.GetMmgFontNorm());

            Assert.AreEqual(true, l1.GetLabel().ApiEquals(MmgFontData.GetMmgFontNorm()));

            l1.SetLabelFont(MmgFontData.CreateDefaultNormalFontLg());

            Assert.AreEqual(true, l1.GetLabelFont().Equals(MmgFontData.CreateDefaultNormalFontLg()));

            l1.SetMmgColor(MmgColor.GetBlue());
            l1.SetPaddingX(24);

            Assert.AreEqual(true, l1.GetMmgColor().ApiEquals(MmgColor.GetBlue()));
            Assert.AreEqual(true, l1.GetPaddingX() == 24);

            l1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            l1.SetPosition(50, 50);

            Assert.AreEqual(true, l1.GetX() == 50);
            Assert.AreEqual(true, l1.GetY() == 50);

            l1.SetSkipReset(true);
            l1.SetValue(MmgFontData.GetMmgFontItalic());

            Assert.AreEqual(true, l1.GetSkipReset() == true);
            Assert.AreEqual(true, l1.GetValue().ApiEquals(MmgFontData.GetMmgFontItalic()));

            l1.SetValueFont(MmgFontData.CreateDefaultBoldFontLg());

            Assert.AreEqual(true, l1.GetValueFont().Equals(MmgFontData.CreateDefaultBoldFontLg()));

            l1.SetValueText("Test String");

            Assert.AreEqual(true, l1.GetValueText().Equals("Test String"));

            l2 = l1.CloneTyped();

            Assert.AreEqual(true, l1.ApiEquals(l1));
            Assert.AreEqual(true, l1.ApiEquals(l2));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(false, l3.ApiEquals(l1));
            Assert.AreEqual(false, l1.ApiEquals(l3));
        }

        [TestMethod]
        public void test2()
        {
            MmgLabelValuePair l1, l2, l3 = null;

            l1 = new MmgLabelValuePair(MmgFontData.CreateDefaultBoldFontLg(), MmgFontData.CreateDefaultNormalFontLg());
            l3 = new MmgLabelValuePair(MmgFontData.CreateDefaultNormalFontLg(), MmgFontData.CreateDefaultNormalFontLg());

            Assert.AreEqual(true, l1.GetLabel().ApiEquals(new MmgFont(MmgFontData.CreateDefaultBoldFontLg())));
            Assert.AreEqual(true, l1.GetValue().ApiEquals(new MmgFont(MmgFontData.CreateDefaultNormalFontLg())));
            Assert.AreEqual(true, l1.GetPaddingX() == MmgLabelValuePair.DEFAULT_PADDING_X);
            Assert.AreEqual(true, l1.GetHeight() == 0);
            Assert.AreEqual(true, l1.GetWidth() == 0);

            l1.SetFontSize(15);
            Assert.AreEqual(true, l1.GetFontSize() == 15);

            l1.SetLabel(MmgFontData.GetMmgFontNorm());

            Assert.AreEqual(true, l1.GetLabel().ApiEquals(MmgFontData.GetMmgFontNorm()));

            l1.SetLabelFont(MmgFontData.CreateDefaultNormalFontLg());

            Assert.AreEqual(true, l1.GetLabelFont().Equals(MmgFontData.CreateDefaultNormalFontLg()));

            l1.SetMmgColor(MmgColor.GetBlue());
            l1.SetPaddingX(24);

            Assert.AreEqual(true, l1.GetMmgColor().ApiEquals(MmgColor.GetBlue()));
            Assert.AreEqual(true, l1.GetPaddingX() == 24);

            l1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            l1.SetPosition(50, 50);

            Assert.AreEqual(true, l1.GetX() == 50);
            Assert.AreEqual(true, l1.GetY() == 50);

            l1.SetSkipReset(true);
            l1.SetValue(MmgFontData.GetMmgFontItalic());

            Assert.AreEqual(true, l1.GetSkipReset() == true);
            Assert.AreEqual(true, l1.GetValue().ApiEquals(MmgFontData.GetMmgFontItalic()));

            l1.SetValueFont(MmgFontData.CreateDefaultBoldFontLg());

            Assert.AreEqual(true, l1.GetValueFont().Equals(MmgFontData.CreateDefaultBoldFontLg()));

            l1.SetValueText("Test String");

            Assert.AreEqual(true, l1.GetValueText().Equals("Test String"));

            l2 = l1.CloneTyped();

            Assert.AreEqual(true, l1.ApiEquals(l1));
            Assert.AreEqual(true, l1.ApiEquals(l2));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(false, l3.ApiEquals(l1));
            Assert.AreEqual(false, l1.ApiEquals(l3));
        }

        [TestMethod]
        public void test3()
        {
            MmgLabelValuePair l1, l2, l3 = null;

            l1 = new MmgLabelValuePair(MmgFontData.CreateDefaultBoldMmgFontLg(), MmgFontData.CreateDefaultNormalMmgFontLg());
            l3 = new MmgLabelValuePair(MmgFontData.CreateDefaultNormalFontLg(), MmgFontData.CreateDefaultNormalFontLg());

            Assert.AreEqual(true, l1.GetLabel().ApiEquals(MmgFontData.CreateDefaultBoldMmgFontLg()));
            Assert.AreEqual(true, l1.GetValue().ApiEquals(MmgFontData.CreateDefaultNormalMmgFontLg()));
            Assert.AreEqual(true, l1.GetPaddingX() == MmgLabelValuePair.DEFAULT_PADDING_X);
            Assert.AreEqual(true, l1.GetHeight() == 0);
            Assert.AreEqual(true, l1.GetWidth() == 0);

            l1.SetFontSize(15);
            Assert.AreEqual(true, l1.GetFontSize() == 15);

            l1.SetLabel(MmgFontData.GetMmgFontNorm());

            Assert.AreEqual(true, l1.GetLabel().ApiEquals(MmgFontData.GetMmgFontNorm()));

            l1.SetLabelFont(MmgFontData.CreateDefaultNormalFontLg());

            Assert.AreEqual(true, l1.GetLabelFont().Equals(MmgFontData.CreateDefaultNormalFontLg()));

            l1.SetMmgColor(MmgColor.GetBlue());
            l1.SetPaddingX(24);

            Assert.AreEqual(true, l1.GetMmgColor().ApiEquals(MmgColor.GetBlue()));
            Assert.AreEqual(true, l1.GetPaddingX() == 24);

            l1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            l1.SetPosition(50, 50);

            Assert.AreEqual(true, l1.GetX() == 50);
            Assert.AreEqual(true, l1.GetY() == 50);

            l1.SetSkipReset(true);
            l1.SetValue(MmgFontData.GetMmgFontItalic());

            Assert.AreEqual(true, l1.GetSkipReset() == true);
            Assert.AreEqual(true, l1.GetValue().ApiEquals(MmgFontData.GetMmgFontItalic()));

            l1.SetValueFont(MmgFontData.CreateDefaultBoldFontLg());

            Assert.AreEqual(true, l1.GetValueFont().Equals(MmgFontData.CreateDefaultBoldFontLg()));

            l1.SetValueText("Test String");

            Assert.AreEqual(true, l1.GetValueText().Equals("Test String"));

            l2 = l1.CloneTyped();

            Assert.AreEqual(true, l1.ApiEquals(l1));
            Assert.AreEqual(true, l1.ApiEquals(l2));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(false, l3.ApiEquals(l1));
            Assert.AreEqual(false, l1.ApiEquals(l3));
        }

        [TestMethod]
        public void test4()
        {
            MmgLabelValuePair l1, l2, l3 = null;

            l1 = new MmgLabelValuePair(new MmgLabelValuePair(MmgFontData.CreateDefaultBoldMmgFontLg(), MmgFontData.CreateDefaultNormalMmgFontLg()));
            l3 = new MmgLabelValuePair(MmgFontData.CreateDefaultNormalFontLg(), MmgFontData.CreateDefaultNormalFontLg());

            Assert.AreEqual(true, l1.GetLabel().ApiEquals(MmgFontData.CreateDefaultBoldMmgFontLg()));
            Assert.AreEqual(true, l1.GetValue().ApiEquals(MmgFontData.CreateDefaultNormalMmgFontLg()));
            Assert.AreEqual(true, l1.GetPaddingX() == MmgLabelValuePair.DEFAULT_PADDING_X);
            Assert.AreEqual(true, l1.GetHeight() == 0);
            Assert.AreEqual(true, l1.GetWidth() == 0);

            l1.SetFontSize(15);
            Assert.AreEqual(true, l1.GetFontSize() == 15);

            l1.SetLabel(MmgFontData.GetMmgFontNorm());

            Assert.AreEqual(true, l1.GetLabel().ApiEquals(MmgFontData.GetMmgFontNorm()));

            l1.SetLabelFont(MmgFontData.CreateDefaultNormalFontLg());

            Assert.AreEqual(true, l1.GetLabelFont().Equals(MmgFontData.CreateDefaultNormalFontLg()));

            l1.SetMmgColor(MmgColor.GetBlue());
            l1.SetPaddingX(24);

            Assert.AreEqual(true, l1.GetMmgColor().ApiEquals(MmgColor.GetBlue()));
            Assert.AreEqual(true, l1.GetPaddingX() == 24);

            l1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            l1.SetPosition(50, 50);

            Assert.AreEqual(true, l1.GetX() == 50);
            Assert.AreEqual(true, l1.GetY() == 50);

            l1.SetSkipReset(true);
            l1.SetValue(MmgFontData.GetMmgFontItalic());

            Assert.AreEqual(true, l1.GetSkipReset() == true);
            Assert.AreEqual(true, l1.GetValue().ApiEquals(MmgFontData.GetMmgFontItalic()));

            l1.SetValueFont(MmgFontData.CreateDefaultBoldFontLg());

            Assert.AreEqual(true, l1.GetValueFont().Equals(MmgFontData.CreateDefaultBoldFontLg()));

            l1.SetValueText("Test String");

            Assert.AreEqual(true, l1.GetValueText().Equals("Test String"));

            l2 = l1.CloneTyped();

            Assert.AreEqual(true, l1.ApiEquals(l1));
            Assert.AreEqual(true, l1.ApiEquals(l2));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(true, l2.ApiEquals(l1));
            Assert.AreEqual(false, l3.ApiEquals(l1));
            Assert.AreEqual(false, l1.ApiEquals(l3));
        }
    }
}