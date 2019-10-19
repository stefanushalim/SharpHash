﻿using SharpHash.Base;
using SharpHash.Interfaces;
using SharpHash.Utils;
using System;

namespace SharpHash.Crypto
{
    internal class SHA0 : BlockHash, ICryptoNotBuildIn, ITransformBlock
    {
        protected UInt32[] state = null;
        private UInt32[] data = null;

        private readonly static UInt32 C1 = 0x5A827999;
        private readonly static UInt32 C2 = 0x6ED9EBA1;
        private readonly static UInt32 C3 = 0x8F1BBCDC;
        private readonly static UInt32 C4 = 0xCA62C1D6;
               
        public SHA0()
            : base(20, 64)
        {
            state = new UInt32[5];
            data = new UInt32[80];
        } // end constructor

        override public IHash Clone()
        {
            SHA0 HashInstance = new SHA0();
            HashInstance.buffer = buffer.Clone();
            HashInstance.processed_bytes = processed_bytes;

            HashInstance.state = new UInt32[state.Length];
            Utils.Utils.memcopy(ref HashInstance.state, state, state.Length);

            HashInstance.BufferSize = BufferSize;

            return HashInstance;
        } // end function Clone

        override public unsafe void Initialize()
        {
            state[0] = 0x67452301;
            state[1] = 0xEFCDAB89;
            state[2] = 0x98BADCFE;
            state[3] = 0x10325476;
            state[4] = 0xC3D2E1F0;

            base.Initialize();
        } // end function Initialize

        virtual protected unsafe void Expand(UInt32* a_data)
        {
            a_data[16] = ((a_data[16 - 3] ^ a_data[16 - 8]) ^ a_data[16 - 14]) ^ a_data[0];
            a_data[17] = ((a_data[17 - 3] ^ a_data[17 - 8]) ^ a_data[17 - 14]) ^ a_data[17 - 16];
            a_data[18] = ((a_data[18 - 3] ^ a_data[18 - 8]) ^ a_data[18 - 14]) ^ a_data[18 - 16];
            a_data[19] = ((a_data[19 - 3] ^ a_data[19 - 8]) ^ a_data[19 - 14]) ^ a_data[19 - 16];
            a_data[20] = ((a_data[20 - 3] ^ a_data[20 - 8]) ^ a_data[20 - 14]) ^ a_data[20 - 16];
            a_data[21] = ((a_data[21 - 3] ^ a_data[21 - 8]) ^ a_data[21 - 14]) ^ a_data[21 - 16];
            a_data[22] = ((a_data[22 - 3] ^ a_data[22 - 8]) ^ a_data[22 - 14]) ^ a_data[22 - 16];
            a_data[23] = ((a_data[23 - 3] ^ a_data[23 - 8]) ^ a_data[23 - 14]) ^ a_data[23 - 16];
            a_data[24] = ((a_data[24 - 3] ^ a_data[24 - 8]) ^ a_data[24 - 14]) ^ a_data[24 - 16];
            a_data[25] = ((a_data[25 - 3] ^ a_data[25 - 8]) ^ a_data[25 - 14]) ^ a_data[25 - 16];
            a_data[26] = ((a_data[26 - 3] ^ a_data[26 - 8]) ^ a_data[26 - 14]) ^ a_data[26 - 16];
            a_data[27] = ((a_data[27 - 3] ^ a_data[27 - 8]) ^ a_data[27 - 14]) ^ a_data[27 - 16];
            a_data[28] = ((a_data[28 - 3] ^ a_data[28 - 8]) ^ a_data[28 - 14]) ^ a_data[28 - 16];
            a_data[29] = ((a_data[29 - 3] ^ a_data[29 - 8]) ^ a_data[29 - 14]) ^ a_data[29 - 16];
            a_data[30] = ((a_data[30 - 3] ^ a_data[30 - 8]) ^ a_data[30 - 14]) ^ a_data[30 - 16];
            a_data[31] = ((a_data[31 - 3] ^ a_data[31 - 8]) ^ a_data[31 - 14]) ^ a_data[31 - 16];
            a_data[32] = ((a_data[32 - 3] ^ a_data[32 - 8]) ^ a_data[32 - 14]) ^ a_data[32 - 16];
            a_data[33] = ((a_data[33 - 3] ^ a_data[33 - 8]) ^ a_data[33 - 14]) ^ a_data[33 - 16];
            a_data[34] = ((a_data[34 - 3] ^ a_data[34 - 8]) ^ a_data[34 - 14]) ^ a_data[34 - 16];
            a_data[35] = ((a_data[35 - 3] ^ a_data[35 - 8]) ^ a_data[35 - 14]) ^ a_data[35 - 16];
            a_data[36] = ((a_data[36 - 3] ^ a_data[36 - 8]) ^ a_data[36 - 14]) ^ a_data[36 - 16];
            a_data[37] = ((a_data[37 - 3] ^ a_data[37 - 8]) ^ a_data[37 - 14]) ^ a_data[37 - 16];
            a_data[38] = ((a_data[38 - 3] ^ a_data[38 - 8]) ^ a_data[38 - 14]) ^ a_data[38 - 16];
            a_data[39] = ((a_data[39 - 3] ^ a_data[39 - 8]) ^ a_data[39 - 14]) ^ a_data[39 - 16];
            a_data[40] = ((a_data[40 - 3] ^ a_data[40 - 8]) ^ a_data[40 - 14]) ^ a_data[40 - 16];
            a_data[41] = ((a_data[41 - 3] ^ a_data[41 - 8]) ^ a_data[41 - 14]) ^ a_data[41 - 16];
            a_data[42] = ((a_data[42 - 3] ^ a_data[42 - 8]) ^ a_data[42 - 14]) ^ a_data[42 - 16];
            a_data[43] = ((a_data[43 - 3] ^ a_data[43 - 8]) ^ a_data[43 - 14]) ^ a_data[43 - 16];
            a_data[44] = ((a_data[44 - 3] ^ a_data[44 - 8]) ^ a_data[44 - 14]) ^ a_data[44 - 16];
            a_data[45] = ((a_data[45 - 3] ^ a_data[45 - 8]) ^ a_data[45 - 14]) ^ a_data[45 - 16];
            a_data[46] = ((a_data[46 - 3] ^ a_data[46 - 8]) ^ a_data[46 - 14]) ^ a_data[46 - 16];
            a_data[47] = ((a_data[47 - 3] ^ a_data[47 - 8]) ^ a_data[47 - 14]) ^ a_data[47 - 16];
            a_data[48] = ((a_data[48 - 3] ^ a_data[48 - 8]) ^ a_data[48 - 14]) ^ a_data[48 - 16];
            a_data[49] = ((a_data[49 - 3] ^ a_data[49 - 8]) ^ a_data[49 - 14]) ^ a_data[49 - 16];
            a_data[50] = ((a_data[50 - 3] ^ a_data[50 - 8]) ^ a_data[50 - 14]) ^ a_data[50 - 16];
            a_data[51] = ((a_data[51 - 3] ^ a_data[51 - 8]) ^ a_data[51 - 14]) ^ a_data[51 - 16];
            a_data[52] = ((a_data[52 - 3] ^ a_data[52 - 8]) ^ a_data[52 - 14]) ^ a_data[52 - 16];
            a_data[53] = ((a_data[53 - 3] ^ a_data[53 - 8]) ^ a_data[53 - 14]) ^ a_data[53 - 16];
            a_data[54] = ((a_data[54 - 3] ^ a_data[54 - 8]) ^ a_data[54 - 14]) ^ a_data[54 - 16];
            a_data[55] = ((a_data[55 - 3] ^ a_data[55 - 8]) ^ a_data[55 - 14]) ^ a_data[55 - 16];
            a_data[56] = ((a_data[56 - 3] ^ a_data[56 - 8]) ^ a_data[56 - 14]) ^ a_data[56 - 16];
            a_data[57] = ((a_data[57 - 3] ^ a_data[57 - 8]) ^ a_data[57 - 14]) ^ a_data[57 - 16];
            a_data[58] = ((a_data[58 - 3] ^ a_data[58 - 8]) ^ a_data[58 - 14]) ^ a_data[58 - 16];
            a_data[59] = ((a_data[59 - 3] ^ a_data[59 - 8]) ^ a_data[59 - 14]) ^ a_data[59 - 16];
            a_data[60] = ((a_data[60 - 3] ^ a_data[60 - 8]) ^ a_data[60 - 14]) ^ a_data[60 - 16];
            a_data[61] = ((a_data[61 - 3] ^ a_data[61 - 8]) ^ a_data[61 - 14]) ^ a_data[61 - 16];
            a_data[62] = ((a_data[62 - 3] ^ a_data[62 - 8]) ^ a_data[62 - 14]) ^ a_data[62 - 16];
            a_data[63] = ((a_data[63 - 3] ^ a_data[63 - 8]) ^ a_data[63 - 14]) ^ a_data[63 - 16];
            a_data[64] = ((a_data[64 - 3] ^ a_data[64 - 8]) ^ a_data[64 - 14]) ^ a_data[64 - 16];
            a_data[65] = ((a_data[65 - 3] ^ a_data[65 - 8]) ^ a_data[65 - 14]) ^ a_data[65 - 16];
            a_data[66] = ((a_data[66 - 3] ^ a_data[66 - 8]) ^ a_data[66 - 14]) ^ a_data[66 - 16];
            a_data[67] = ((a_data[67 - 3] ^ a_data[67 - 8]) ^ a_data[67 - 14]) ^ a_data[67 - 16];
            a_data[68] = ((a_data[68 - 3] ^ a_data[68 - 8]) ^ a_data[68 - 14]) ^ a_data[68 - 16];
            a_data[69] = ((a_data[69 - 3] ^ a_data[69 - 8]) ^ a_data[69 - 14]) ^ a_data[69 - 16];
            a_data[70] = ((a_data[70 - 3] ^ a_data[70 - 8]) ^ a_data[70 - 14]) ^ a_data[70 - 16];
            a_data[71] = ((a_data[71 - 3] ^ a_data[71 - 8]) ^ a_data[71 - 14]) ^ a_data[71 - 16];
            a_data[72] = ((a_data[72 - 3] ^ a_data[72 - 8]) ^ a_data[72 - 14]) ^ a_data[72 - 16];
            a_data[73] = ((a_data[73 - 3] ^ a_data[73 - 8]) ^ a_data[73 - 14]) ^ a_data[73 - 16];
            a_data[74] = ((a_data[74 - 3] ^ a_data[74 - 8]) ^ a_data[74 - 14]) ^ a_data[74 - 16];
            a_data[75] = ((a_data[75 - 3] ^ a_data[75 - 8]) ^ a_data[75 - 14]) ^ a_data[75 - 16];
            a_data[76] = ((a_data[76 - 3] ^ a_data[76 - 8]) ^ a_data[76 - 14]) ^ a_data[76 - 16];
            a_data[77] = ((a_data[77 - 3] ^ a_data[77 - 8]) ^ a_data[77 - 14]) ^ a_data[77 - 16];
            a_data[78] = ((a_data[78 - 3] ^ a_data[78 - 8]) ^ a_data[78 - 14]) ^ a_data[78 - 16];
            a_data[79] = ((a_data[79 - 3] ^ a_data[79 - 8]) ^ a_data[79 - 14]) ^ a_data[79 - 16];

        } // end function Expand

        override protected unsafe byte[] GetResult()
        {
            byte[] result = new byte[5 * sizeof(UInt32)];

            fixed (UInt32* sPtr = state)
            {
                fixed(byte* bPtr= result)
                {
                    Converters.be32_copy((IntPtr)sPtr, 0, (IntPtr)bPtr, 0, result.Length);
                }
            }
            
            return result;
        } // end function GetResult

        override protected void Finish()
        {
            Int32 padindex;

            UInt64 bits = processed_bytes * 8;
            if (buffer.Position < 56)
                padindex = 56 - buffer.Position;
            else
                padindex = 120 - buffer.Position;

            byte[] pad = new byte[padindex + 8];

            pad[0] = 0x80;

            bits = Converters.be2me_64(bits);

            Converters.ReadUInt64AsBytesLE(bits, ref pad, padindex);

            padindex = padindex + 8;

            TransformBytes(pad, 0, padindex);
        } // end function Finish

        override protected unsafe void TransformBlock(IntPtr a_data,
                Int32 a_data_length, Int32 a_index)
        {
            UInt32 A, B, C, D, E;            

            fixed (UInt32* dPtr = data)
            {
                Converters.be32_copy(a_data, a_index, (IntPtr)dPtr, 0, 64);

                Expand(dPtr);
            }

            A = state[0];
            B = state[1];
            C = state[2];
            D = state[3];
            E = state[4];

            E = (data[0] + C1 + Bits.RotateLeft32(A, 5) +
                (D ^ (B & (C ^ D)))) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[1] + C1 + Bits.RotateLeft32(E, 5) +
                (C ^ (A & (B ^ C)))) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[2] + C1 + Bits.RotateLeft32(D, 5) +
                (B ^ (E & (A ^ B)))) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[3] + C1 + Bits.RotateLeft32(C, 5) +
                (A ^ (D & (E ^ A)))) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[4] + C1 + Bits.RotateLeft32(B, 5) +
                (E ^ (C & (D ^ E)))) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[5] + C1 + Bits.RotateLeft32(A, 5) +
                (D ^ (B & (C ^ D)))) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[6] + C1 + Bits.RotateLeft32(E, 5) +
                (C ^ (A & (B ^ C)))) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[7] + C1 + Bits.RotateLeft32(D, 5) +
                (B ^ (E & (A ^ B)))) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[8] + C1 + Bits.RotateLeft32(C, 5) +
                (A ^ (D & (E ^ A)))) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[9] + C1 + Bits.RotateLeft32(B, 5) +
                (E ^ (C & (D ^ E)))) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[10] + C1 + Bits.RotateLeft32(A, 5) +
                (D ^ (B & (C ^ D)))) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[11] + C1 + Bits.RotateLeft32(E, 5) +
                (C ^ (A & (B ^ C)))) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[12] + C1 + Bits.RotateLeft32(D, 5) +
                (B ^ (E & (A ^ B)))) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[13] + C1 + Bits.RotateLeft32(C, 5) +
                (A ^ (D & (E ^ A)))) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[14] + C1 + Bits.RotateLeft32(B, 5) +
                (E ^ (C & (D ^ E)))) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[15] + C1 + Bits.RotateLeft32(A, 5) +
                (D ^ (B & (C ^ D)))) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[16] + C1 + Bits.RotateLeft32(E, 5) +
                (C ^ (A & (B ^ C)))) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[17] + C1 + Bits.RotateLeft32(D, 5) +
                (B ^ (E & (A ^ B)))) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[18] + C1 + Bits.RotateLeft32(C, 5) +
                (A ^ (D & (E ^ A)))) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[19] + C1 + Bits.RotateLeft32(B, 5) +
                (E ^ (C & (D ^ E)))) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[20] + C2 + Bits.RotateLeft32(A, 5) + (B ^ C ^ D)) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[21] + C2 + Bits.RotateLeft32(E, 5) + (A ^ B ^ C)) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[22] + C2 + Bits.RotateLeft32(D, 5) + (E ^ A ^ B)) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[23] + C2 + Bits.RotateLeft32(C, 5) + (D ^ E ^ A)) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[24] + C2 + Bits.RotateLeft32(B, 5) + (C ^ D ^ E)) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[25] + C2 + Bits.RotateLeft32(A, 5) + (B ^ C ^ D)) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[26] + C2 + Bits.RotateLeft32(E, 5) + (A ^ B ^ C)) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[27] + C2 + Bits.RotateLeft32(D, 5) + (E ^ A ^ B)) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[28] + C2 + Bits.RotateLeft32(C, 5) + (D ^ E ^ A)) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[29] + C2 + Bits.RotateLeft32(B, 5) + (C ^ D ^ E)) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[30] + C2 + Bits.RotateLeft32(A, 5) + (B ^ C ^ D)) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[31] + C2 + Bits.RotateLeft32(E, 5) + (A ^ B ^ C)) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[32] + C2 + Bits.RotateLeft32(D, 5) + (E ^ A ^ B)) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[33] + C2 + Bits.RotateLeft32(C, 5) + (D ^ E ^ A)) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[34] + C2 + Bits.RotateLeft32(B, 5) + (C ^ D ^ E)) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[35] + C2 + Bits.RotateLeft32(A, 5) + (B ^ C ^ D)) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[36] + C2 + Bits.RotateLeft32(E, 5) + (A ^ B ^ C)) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[37] + C2 + Bits.RotateLeft32(D, 5) + (E ^ A ^ B)) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[38] + C2 + Bits.RotateLeft32(C, 5) + (D ^ E ^ A)) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[39] + C2 + Bits.RotateLeft32(B, 5) + (C ^ D ^ E)) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[40] + C3 + Bits.RotateLeft32(A, 5) +
                ((B & C) | (D & (B | C)))) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[41] + C3 + Bits.RotateLeft32(E, 5) +
                ((A & B) | (C & (A | B)))) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[42] + C3 + Bits.RotateLeft32(D, 5) +
                ((E & A) | (B & (E | A)))) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[43] + C3 + Bits.RotateLeft32(C, 5) +
                ((D & E) | (A & (D | E)))) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[44] + C3 + Bits.RotateLeft32(B, 5) +
                ((C & D) | (E & (C | D)))) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[45] + C3 + Bits.RotateLeft32(A, 5) +
                ((B & C) | (D & (B | C)))) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[46] + C3 + Bits.RotateLeft32(E, 5) +
                ((A & B) | (C & (A | B)))) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[47] + C3 + Bits.RotateLeft32(D, 5) +
                ((E & A) | (B & (E | A)))) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[48] + C3 + Bits.RotateLeft32(C, 5) +
                ((D & E) | (A & (D | E)))) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[49] + C3 + Bits.RotateLeft32(B, 5) +
                ((C & D) | (E & (C | D)))) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[50] + C3 + Bits.RotateLeft32(A, 5) +
                ((B & C) | (D & (B | C)))) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[51] + C3 + Bits.RotateLeft32(E, 5) +
                ((A & B) | (C & (A | B)))) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[52] + C3 + Bits.RotateLeft32(D, 5) +
                ((E & A) | (B & (E | A)))) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[53] + C3 + Bits.RotateLeft32(C, 5) +
                ((D & E) | (A & (D | E)))) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[54] + C3 + Bits.RotateLeft32(B, 5) +
                ((C & D) | (E & (C | D)))) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[55] + C3 + Bits.RotateLeft32(A, 5) +
                ((B & C) | (D & (B | C)))) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[56] + C3 + Bits.RotateLeft32(E, 5) +
                ((A & B) | (C & (A | B)))) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[57] + C3 + Bits.RotateLeft32(D, 5) +
                ((E & A) | (B & (E | A)))) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[58] + C3 + Bits.RotateLeft32(C, 5) +
                ((D & E) | (A & (D | E)))) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[59] + C3 + Bits.RotateLeft32(B, 5) +
                ((C & D) | (E & (C | D)))) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[60] + C4 + Bits.RotateLeft32(A, 5) + (B ^ C ^ D)) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[61] + C4 + Bits.RotateLeft32(E, 5) + (A ^ B ^ C)) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[62] + C4 + Bits.RotateLeft32(D, 5) + (E ^ A ^ B)) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[63] + C4 + Bits.RotateLeft32(C, 5) + (D ^ E ^ A)) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[64] + C4 + Bits.RotateLeft32(B, 5) + (C ^ D ^ E)) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[65] + C4 + Bits.RotateLeft32(A, 5) + (B ^ C ^ D)) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[66] + C4 + Bits.RotateLeft32(E, 5) + (A ^ B ^ C)) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[67] + C4 + Bits.RotateLeft32(D, 5) + (E ^ A ^ B)) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[68] + C4 + Bits.RotateLeft32(C, 5) + (D ^ E ^ A)) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[69] + C4 + Bits.RotateLeft32(B, 5) + (C ^ D ^ E)) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[70] + C4 + Bits.RotateLeft32(A, 5) + (B ^ C ^ D)) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[71] + C4 + Bits.RotateLeft32(E, 5) + (A ^ B ^ C)) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[72] + C4 + Bits.RotateLeft32(D, 5) + (E ^ A ^ B)) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[73] + C4 + Bits.RotateLeft32(C, 5) + (D ^ E ^ A)) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[74] + C4 + Bits.RotateLeft32(B, 5) + (C ^ D ^ E)) + A;

            C = Bits.RotateLeft32(C, 30);
            E = (data[75] + C4 + Bits.RotateLeft32(A, 5) + (B ^ C ^ D)) + E;

            B = Bits.RotateLeft32(B, 30);
            D = (data[76] + C4 + Bits.RotateLeft32(E, 5) + (A ^ B ^ C)) + D;

            A = Bits.RotateLeft32(A, 30);
            C = (data[77] + C4 + Bits.RotateLeft32(D, 5) + (E ^ A ^ B)) + C;

            E = Bits.RotateLeft32(E, 30);
            B = (data[78] + C4 + Bits.RotateLeft32(C, 5) + (D ^ E ^ A)) + B;

            D = Bits.RotateLeft32(D, 30);
            A = (data[79] + C4 + Bits.RotateLeft32(B, 5) + (C ^ D ^ E)) + A;

            C = Bits.RotateLeft32(C, 30);

            state[0] = state[0] + A;
            state[1] = state[1] + B;
            state[2] = state[2] + C;
            state[3] = state[3] + D;
            state[4] = state[4] + E;

            Utils.Utils.memset(ref data, 0);

        } // end function TransformBlock

    } // end class SHA0

}
