using SharpHash.Base;
using SharpHash.Interfaces;
using SharpHash.Utils;
using SharpHash.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SharpHash.XOFandKMAC.Tests
{
    [TestClass]
    public class Shake_128Tests
    {
        protected IHash hash = HashFactory.XOF.CreateShake_128(512);

        protected string ExpectedHashOfEmptyData = "7F9C2BA4E88F827D616045507605853ED73B8093F6EFBC88EB1A6EACFA66EF263CB1EEA988004B93103CFB0AEEFD2A686E01FA4A58E8A3639CA8A1E3F9AE57E2";
        protected string ExpectedHashOfDefaultData = "10F69AD42A1BDE254004CD13B5176D6DAAD5E92198CD4715AA923017FFC809C4B3AA88E2CCBF4ABA98A0E9B7B49FC1A39ABAEC03F020CE4A72601B80E158F515";
        protected string ExpectedHashOfOnetoNine = "1ACA6B9E651B5F20079A305CA8F86D39B9451C4C32873F95F8B315834BD5F272C3044114D6F3E2C2F5F4EAA1825FC80F8CE10CF3E7DE557408811F54D1AF85FD";
        protected string ExpectedHashOfabcde = "907C1B3F41470218D0DFD8FEDDDA93C1074F0D608F08980E4F17BE0853D0A684324815152908BE3DFB69D8A01EA8DD41A3413CD1F635F449D9875DE319469648";
        protected string ExpectedVeryLongShakeOfEmptyString =
            "7F9C2BA4E88F827D616045507605853ED73B8093F6EFBC88EB1A6EACFA66EF263CB1EEA988004B93103CFB0AEEFD2A686E01FA4A58E8A3639CA8A1E3F9"
          + "AE57E235B8CC873C23DC62B8D260169AFA2F75AB916A58D974918835D25E6A435085B2BADFD6DFAAC359A5EFBB7BCC4B59D538DF9A04302E10C8BC1CBF1A0B3A5120EA17CDA7CFA"
          + "D765F5623474D368CCCA8AF0007CD9F5E4C849F167A580B14AABDEFAEE7EEF47CB0FCA9767BE1FDA69419DFB927E9DF07348B196691ABAEB580B32D"
          + "EF58538B8D23F87732EA63B02B4FA0F4873360E2841928CD60DD4CEE8CC0D4C922A96188D032675C8AC850933C7AFF1533B94C834ADBB69C6115BAD4692D8619F90B0CDF8A7B9"
          + "C264029AC185B70B83F2801F2F4B3F70C593EA3AEEB613A7F1B1DE33FD75081F592305F2E4526EDC09631B10958F464D889F31BA010250FDA7F1368EC2967FC84EF2AE9AFF268E0B1700AFFC6820B523A3D917135F2DFF2EE06BFE72B3124721D"
          + "4A26C04E53A75E30E73A7A9C4A95D91C55D495E9F51DD0B5E9D83C6D5E8CE803AA62B8D654DB53D09B8DCFF273CDFEB573FAD8BCD45578BEC2E770D"
          + "01EFDE86E721A3F7C6CCE275DABE6E2143F1AF18DA7EFDDC4C7B70B5E345DB93CC936BEA323491CCB38A388F546A9FF00DD4E1300B9B2153D2041D205B443E41B45A653F2A5C4492C1ADD544512DDA2529833462B71A41A45BE97290B6F4CFFDA2CF990051634A4B1EDF6114F"
          + "B49083C1FA3B302EE097F051266BE69DC716FDEEF91B0D4AB2DE525550BF80DC8A684BC3B5A4D46B7EFAE7AFDC6292988DC9ACAE03F8634486C1ABE2781AAE4C02F3460D2CD4E6A"
          + "463A2BA9562EE623CF0E9F82AB4D0B5C9D040A269366479DFF0038ABFAF2E0FF21F36968972E3F104DDCBE1EB831A87C213162E29B34ADFA564D121E9F6E7729F4203FC5C6C22FA7A7350AFDDB6209"
          + "23A4A129B8ACB19EA10F818C30E3B5B1C571FA79E57EE304388316A02FCD93A0D8EE02BB85701EE4FF097534B502C1B12FBB95C8CCB2F548921D99CC7C9FE17AC991B675E631144423EEF7A5869168DA63D1F4C21F650C02923BFD396CA6A5DB541068624CBC5FFE208C0D1A74E1A29618D0BB60036F524"
          + "9ABFA88898E393718D6EFAB05BB41279EFCD4C5A0CC837CCFC22BE4F725C081F6AA090749DBA7077BAE8D41AF3FEC5A6EE1B8ADCD25E72DE36434584EF567C643D344294E8B2086B87F69"
          + "C3BDC0D5969857082987CA1C63B7182E86898FB9B8039E75EDA219E289331610369271867B145B2908293963CD677C9A1AE6CEB28289B254CDEB76B12F33CE5CF3743131BFB550F019"
          + "7BFE16AFF92367227ADC5074FE3DC0D8D116253980A38636BC9D29F799BBB2D76A0A5F138B8C73BA484D6588764E331D70C378C0641F2D9";

        [TestMethod]
        public void TestEmptyString()
        {
            TestHelper.TestActualAndExpectedData(TestConstants.EmptyData,
                ExpectedHashOfEmptyData, hash);
        }

        [TestMethod]
        public void TestDefaultData()
        {
            TestHelper.TestActualAndExpectedData(TestConstants.DefaultData,
                ExpectedHashOfDefaultData, hash);
        }

        [TestMethod]
        public void TestOnetoNine()
        {
            TestHelper.TestActualAndExpectedData(TestConstants.OnetoNine,
                ExpectedHashOfOnetoNine, hash);
        }

        [TestMethod]
        public void TestBytesabcde()
        {
            TestHelper.TestActualAndExpectedData(TestConstants.Bytesabcde,
                ExpectedHashOfabcde, hash);
        }

        [TestMethod]
        public void TestEmptyStream()
        {
            TestHelper.TestEmptyStream(ExpectedHashOfEmptyData, hash);
        }

        [TestMethod]
        public void TestIncrementalHash()
        {
            TestHelper.TestIncrementalHash(TestConstants.DefaultData,
                ExpectedHashOfDefaultData, hash);
        }

        [TestMethod]
        public void TestHashCloneIsCorrect()
        {
            TestHelper.TestHashCloneIsCorrect(hash);
        }

        [TestMethod]
        public void TestHashCloneIsUnique()
        {
            TestHelper.TestHashCloneIsUnique(hash);
        }

        [TestMethod]
        public void TestHMACCloneIsCorrect()
        {
            TestHelper.TestHMACCloneIsCorrect(hash);
        }

        [TestMethod]
        public void TestVeryLongShakeOfEmptyString()
        {
            IHash VeryLongShake_128 = HashFactory.XOF.CreateShake_128(8000);

            string ActualString = VeryLongShake_128.ComputeString(
                TestConstants.EmptyData).ToString();

            string ExpectedString = ExpectedVeryLongShakeOfEmptyString;

            Assert.AreEqual(ExpectedString, ActualString,
                String.Format("Expected {0} but got {1}.",
                ExpectedString, ActualString));
        }

        [TestMethod]
        public void TestVeryLongShakeOfEmptyStringWithStreamingOutput()
        {
            IXOF VeryLongShake_128;
            byte[] TempResult, ExpectedChunk, ActualChunk;

            byte[] Expected = Converters.ConvertHexStringToBytes(ExpectedVeryLongShakeOfEmptyString);

            TempResult = new byte[1000];
            VeryLongShake_128 = HashFactory.XOF.CreateShake_128(8000) as IXOF;
            VeryLongShake_128.Initialize();
            VeryLongShake_128.TransformString(TestConstants.EmptyData);

            VeryLongShake_128.DoOutput(ref TempResult, 0, 250);

            ActualChunk = new byte[250];
            Utils.Utils.memcopy(ref ActualChunk, TempResult, 250, 0);

            ExpectedChunk = new byte[250];
            Utils.Utils.memcopy(ref ExpectedChunk, Expected, 250, 0);

            Assert.IsTrue(TestHelper.Compare(ExpectedChunk, ActualChunk), 
                "Shake128 Streaming Test 1 Mismatch");

            VeryLongShake_128.DoOutput(ref TempResult, 250, 250);
            
            Utils.Utils.memcopy(ref ActualChunk, TempResult, 250, 250);
            Utils.Utils.memcopy(ref ExpectedChunk, Expected, 250, 250);

            Assert.IsTrue(TestHelper.Compare(ExpectedChunk, ActualChunk),
                 "Shake128 Streaming Test 2 Mismatch");

            VeryLongShake_128.DoOutput(ref TempResult, 500, 250);

            Utils.Utils.memcopy(ref ActualChunk, TempResult, 250, 500);
            Utils.Utils.memcopy(ref ExpectedChunk, Expected, 250, 500);

            Assert.IsTrue(TestHelper.Compare(ExpectedChunk, ActualChunk),
                 "Shake128 Streaming Test 3 Mismatch");

            VeryLongShake_128.DoOutput(ref TempResult, 750, 250);

            Utils.Utils.memcopy(ref ActualChunk, TempResult, 250, 750);
            Utils.Utils.memcopy(ref ExpectedChunk, Expected, 250, 750);

            Assert.IsTrue(TestHelper.Compare(ExpectedChunk, ActualChunk),
                 "Shake128 Streaming Test 4 Mismatch");

            string ActualString = Converters.ConvertBytesToHexString(TempResult, false);
            string ExpectedString = ExpectedVeryLongShakeOfEmptyString;

            Assert.AreEqual(ExpectedString, ActualString, 
                String.Format("Expected {0} but got {1}.", 
                ExpectedString, ActualString));

            // Verify that Initialization Works
            VeryLongShake_128.Initialize();

            VeryLongShake_128.DoOutput(ref TempResult, 0, 250);

            Utils.Utils.memcopy(ref ActualChunk, TempResult, 250, 0);
            Utils.Utils.memcopy(ref ExpectedChunk, Expected, 250, 0);
            
            Assert.IsTrue(TestHelper.Compare(ExpectedChunk, ActualChunk),
                "Shake128 Streaming Initialization Test Fail");

        }

    }
}