﻿///////////////////////////////////////////////////////////////////////
/// SharpHash Library
/// Copyright(c) 2019 - 2020  Mbadiwe Nnaemeka Ronald
/// Github Repository <https://github.com/ron4fun/SharpHash>
///
/// The contents of this file are subject to the
/// Mozilla Public License Version 2.0 (the "License");
/// you may not use this file except in
/// compliance with the License. You may obtain a copy of the License
/// at https://www.mozilla.org/en-US/MPL/2.0/
///
/// Software distributed under the License is distributed on an "AS IS"
/// basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See
/// the License for the specific language governing rights and
/// limitations under the License.
///
/// Acknowledgements:
///
/// Thanks to Ugochukwu Mmaduekwe (https://github.com/Xor-el) for his creative
/// development of this library in Pascal/Delphi (https://github.com/Xor-el/HashLib4Pascal).
///
/// Also, I will like to thank Udezue Chukwunwike (https://github.com/IzarchTech) for
/// his contributions to the growth and development of this library.
///
////////////////////////////////////////////////////////////////////////

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpHash.Base;
using SharpHash.Interfaces;
using SharpHash.Tests;
using SharpHash.Utils;
using System;
using System.Text;

namespace SharpHash
{
    [TestClass]
    public abstract class CryptoHashBaseTests : HashAdapter1BaseTests
    {
        protected string ExpectedHashOfDefaultDataWithHMACWithLongKey { get; set; }
        protected string ExpectedHashOfDefaultDataWithHMACWithShortKey { get; set; }

        [TestMethod]
        public void TestHMACWithDefaultDataAndLongKey()
        {
            IHMAC hmac = HashFactory.HMAC.CreateHMAC(hash,
                Converters.ConvertStringToBytes(TestConstants.HMACLongStringKey,
                Encoding.UTF8));
            string ActualString = hmac.ComputeString(TestConstants.DefaultData,
                Encoding.UTF8).ToString();

            Assert.AreEqual(ExpectedHashOfDefaultDataWithHMACWithLongKey, ActualString,
                String.Format("Expected {0} but got {1}.",
                ExpectedHashOfDefaultDataWithHMACWithLongKey, ActualString));
        }

        [TestMethod]
        public void TestHMACWithDefaultDataAndShortKey()
        {
            IHMAC hmac = HashFactory.HMAC.CreateHMAC(hash,
                Converters.ConvertStringToBytes(TestConstants.HMACShortStringKey,
                Encoding.UTF8));
            string ActualString = hmac.ComputeString(TestConstants.DefaultData,
                Encoding.UTF8).ToString();

            Assert.AreEqual(ExpectedHashOfDefaultDataWithHMACWithShortKey, ActualString,
                String.Format("Expected {0} but got {1}.",
                ExpectedHashOfDefaultDataWithHMACWithShortKey, ActualString));
        }

        [TestMethod]
        public void TestHMACCloneIsCorrect()
        {
            TestHelper.TestHMACCloneIsCorrect(hash);
        }
    }
}