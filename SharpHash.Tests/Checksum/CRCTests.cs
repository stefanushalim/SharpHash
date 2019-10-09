﻿using SharpHash.Base;
using SharpHash.Interfaces;
using SharpHash.Utils;
using SharpHash.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SharpHash.Checksum.Tests
{
    public static class EnumUtil
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    } // end class EnumUtil

    [TestClass]
    public class CRCTests
    {
        protected IHash crcObj = null;
        protected IEnumerable<CRCStandard> CRCStandardValues = EnumUtil.GetValues<CRCStandard>();

        [TestMethod]
        public void TestAnotherChunkedDataIncrementalHash()
        {
            string temp, ActualString, ExpectedString;
            Int32 x, size, i;            

            for (x = 0; x < TestConstants.chunkSize.Length / sizeof(Int32); x++)
            {
                size = TestConstants.chunkSize[x];

                foreach (CRCStandard Idx in CRCStandardValues)
                {
                    crcObj = CRC.CreateCRCObject(Idx);
                    crcObj.Initialize();

                    i = size;
                    while (i < TestConstants.ChunkedData.Length)
                    {
                        temp = TestConstants.ChunkedData.Substring(i - size, size);
                        crcObj.TransformString(temp);

                        i += size;
                    } // end while

                    temp = TestConstants.ChunkedData.Substring((i - size));
                    crcObj.TransformString(temp);

                    ActualString = crcObj.TransformFinal().ToString();

                    ExpectedString = CRC.CreateCRCObject(Idx) 
                        .ComputeString(TestConstants.ChunkedData).ToString();

                    Assert.AreEqual(ExpectedString, ActualString);
                } // end for
            } // end for

        }

        [TestMethod]
        public void TestCheckValue()
        {
            string ActualString, ExpectedString;

            foreach (CRCStandard Idx in CRCStandardValues)
            {
                crcObj = CRC.CreateCRCObject(Idx);

                ExpectedString = ((crcObj as ICRC).GetCheckValue().ToString("X"));

                ActualString = TestHelper.lstrip(crcObj.ComputeString(TestConstants.OnetoNine).ToString(), '0');
                
                Assert.AreEqual(ExpectedString, ActualString);
              } // end foreach
        }

        [TestMethod]
        public void TestCheckValueWithIncrementalHash()
        {
            string ExpectedString;

            foreach (CRCStandard Idx in CRCStandardValues)
            {
                crcObj = CRC.CreateCRCObject(Idx);

                ExpectedString = ((crcObj as ICRC).GetCheckValue().ToString("X"));
                
                TestHelper.TestIncrementalHash(TestConstants.OnetoNine,
                ExpectedString, crcObj);
            }

        }

        [TestMethod]
        public void TestHashCloneIsCorrect()
        {
            IHash Original, Copy;
            byte[] MainData, ChunkOne, ChunkTwo;
            Int32 Count;
            string ActualString, ExpectedString;

            MainData = Converters.ConvertStringToBytes(TestConstants.DefaultData);
            Count = MainData.Length - 3;

            ChunkOne = new byte[Count];
            ChunkTwo = new byte[MainData.Length - Count];

            Utils.Utils.memcopy(ChunkOne, MainData, Count);
            Utils.Utils.memcopy(ChunkTwo, MainData, MainData.Length - Count, Count);

            foreach (CRCStandard Idx in CRCStandardValues)
            {
                Original = CRC.CreateCRCObject(Idx);
                Original.Initialize();

                Original.TransformBytes(ChunkOne);
                // Make Copy Of Current State
                Copy = Original.Clone();
                Original.TransformBytes(ChunkTwo);
                ExpectedString = Original.TransformFinal().ToString();

                Copy.TransformBytes(ChunkTwo);
                ActualString = Copy.TransformFinal().ToString();

                Assert.AreEqual(ActualString, ExpectedString);
            } // end foreach
        }

        [TestMethod]
        public void TestHashCloneIsUnique()
        {
            IHash Original, Copy;

            foreach (CRCStandard Idx in CRCStandardValues)
            {
                Original = CRC.CreateCRCObject(Idx);
                Original.Initialize();
                Original.SetBufferSize(64 * 1024); // 64Kb
                                                   // Make Copy Of Current State
                Copy = Original.Clone();
                Copy.SetBufferSize(128 * 1024); // 128Kb

                Assert.AreNotEqual(Original.GetBufferSize(), Copy.GetBufferSize());
            } // end foreach
        }

    } // end class CRCTests


    [TestClass]
    public class CRC32FastTests
    {
        protected IHash crcObj = null;

        protected UInt32 CRC32_PKZIP_Check_Value = 0xCBF43926;
        protected UInt32 CRC32_CASTAGNOLI_Check_Value = 0xE3069283;
        protected Int32[] WorkingIndex = new Int32[] {0, 1};

        protected UInt32 GetWorkingValue(Int32 a_index)
        {
            switch (a_index)
            {
                case 0:
                    crcObj = new CRC32_PKZIP_Fast();
                    return CRC32_PKZIP_Check_Value;

                case 1:
                    crcObj = new CRC32_CASTAGNOLI_Fast();
                    return CRC32_CASTAGNOLI_Check_Value;
            } // end switch
  

            throw new Exception($"Invalid Index, \"{a_index }\"");
        } // end function GetWorkingValue

        [TestMethod]
        public void TestAnotherChunkedDataIncrementalHash()
        {
            string temp, ActualString, ExpectedString;
            Int32 x, size, i;

            for (x = 0; x < TestConstants.chunkSize.Length / sizeof(Int32); x++)
            {
                size = TestConstants.chunkSize[x];

                foreach (var Idx in WorkingIndex)
                {
                    GetWorkingValue(Idx);
                    crcObj.Initialize();

                    i = size;
                    while (i < TestConstants.ChunkedData.Length)
                    {
                        temp = TestConstants.ChunkedData.Substring(i - size, size);
                        crcObj.TransformString(temp);

                        i += size;
                    } // end while

                    temp = TestConstants.ChunkedData.Substring((i - size));
                    crcObj.TransformString(temp);

                    ActualString = crcObj.TransformFinal().ToString();

                    ExpectedString = crcObj.ComputeString(TestConstants.ChunkedData)
                        .ToString();
                    
                    Assert.AreEqual(ExpectedString, ActualString);
                } // end for
            } // end for

        }

        [TestMethod]
        public void TestCheckValue()
        {
            string ActualString, ExpectedString;
            UInt32 Check_Value;

            foreach (var Idx in WorkingIndex)
            {
                Check_Value = GetWorkingValue(Idx);

                ExpectedString = Check_Value.ToString("X");

                ActualString = TestHelper.lstrip(crcObj.ComputeString(TestConstants.OnetoNine).ToString(), '0');

                Assert.AreEqual(ExpectedString, ActualString);
            } // end foreach
        }

        [TestMethod]
        public void TestCheckValueWithIncrementalHash()
        {
            string ExpectedString;
            UInt32 Check_Value;

            foreach (var Idx in WorkingIndex)
            {
                Check_Value = GetWorkingValue(Idx);
                crcObj.Initialize();

                ExpectedString = Check_Value.ToString("X");

                TestHelper.TestIncrementalHash(TestConstants.OnetoNine,
                ExpectedString, crcObj);
            }

        }

        [TestMethod]
        public void TestHashCloneIsCorrect()
        {
            IHash Original, Copy;
            byte[] MainData, ChunkOne, ChunkTwo;
            Int32 Count;
            string ActualString, ExpectedString;

            MainData = Converters.ConvertStringToBytes(TestConstants.DefaultData);
            Count = MainData.Length - 3;

            ChunkOne = new byte[Count];
            ChunkTwo = new byte[MainData.Length - Count];

            Utils.Utils.memcopy(ChunkOne, MainData, Count);
            Utils.Utils.memcopy(ChunkTwo, MainData, MainData.Length - Count, Count);

            foreach (var Idx in WorkingIndex)
            {
                GetWorkingValue(Idx);
                Original = crcObj;
                Original.Initialize();

                Original.TransformBytes(ChunkOne);
                // Make Copy Of Current State
                Copy = Original.Clone();
                Original.TransformBytes(ChunkTwo);
                ExpectedString = Original.TransformFinal().ToString();

                Copy.TransformBytes(ChunkTwo);
                ActualString = Copy.TransformFinal().ToString();

                Assert.AreEqual(ActualString, ExpectedString);
            } // end foreach
        }

        [TestMethod]
        public void TestHashCloneIsUnique()
        {
            IHash Original, Copy;

            foreach (var Idx in WorkingIndex)
            {
                GetWorkingValue(Idx);
                Original = crcObj;
                Original.Initialize();
                Original.SetBufferSize(64 * 1024); // 64Kb
                                                   // Make Copy Of Current State
                Copy = Original.Clone();
                Copy.SetBufferSize(128 * 1024); // 128Kb

                Assert.AreNotEqual(Original.GetBufferSize(), Copy.GetBufferSize());
            } // end foreach
        }

    } // end class CRC32FastTests

}