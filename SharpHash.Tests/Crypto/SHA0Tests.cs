using SharpHash.Base;
using SharpHash.Interfaces;
using SharpHash.Utils;
using SharpHash.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace SharpHash.Crypto.Tests
{
    [TestClass]
    public class SHA0Tests
    {
        protected IHash hash = new SHA0();

        protected string ExpectedHashOfEmptyData = "F96CEA198AD1DD5617AC084A3D92C6107708C0EF";
        protected string ExpectedHashOfDefaultData = "C9CBBE593DE122CA36B13CC37FE2CA8D5606FEED";
        protected string ExpectedHashOfOnetoNine = "F0360779D2AF6615F306BB534223CF762A92E988";
        protected string ExpectedHashOfabcde = "D624E34951BB800F0ACAE773001DF8CFFE781BA8";
        protected string ExpectedHashOfDefaultDataWithHMACWithLongKey = "CDA87167A558311B9154F372F21A453030BBE16A";
        protected string ExpectedHashOfDefaultDataWithHMACWithShortKey = "EAA73E85DCAC5BAD0A0E71C0695F901FC32DB38A";

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

        public void TestHMACWithDefaultDataAndLongKey()
        {
            IHMAC hmac = new HMACNotBuildInAdapter(hash);
            hmac.Key = Converters.ConvertStringToBytes(TestConstants.HMACLongStringKey);
            string ActualString = hmac.ComputeString(TestConstants.DefaultData).ToString();

            Assert.AreEqual(ExpectedHashOfDefaultDataWithHMACWithLongKey, ActualString);
        }

        public void TestHMACWithDefaultDataAndShortKey()
        {
            IHMAC hmac = new HMACNotBuildInAdapter(hash);
            hmac.Key = Converters.ConvertStringToBytes(TestConstants.HMACShortStringKey);
            string ActualString = hmac.ComputeString(TestConstants.DefaultData).ToString();

            Assert.AreEqual(ExpectedHashOfDefaultDataWithHMACWithShortKey, ActualString);
        }

        public void TestHMACCloneIsCorrect()
        {
            TestHelper.TestHMACCloneIsCorrect(hash);
        }

    }

}