﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace NetIOCPClient.Network
{
   
    /// <summary>
    ///基础类
    /// </summary>
    public abstract class PacketBase : INETPacket, IDisposable
    {

        /// <summary>
        /// 关联片段
        /// </summary>        
        public BufferSegment Buffer;
        

        #region

        /// <summary>
        /// packet id是不在DataLen长度之内的
        /// </summary>
        public virtual ushort PacketID { get; set; }

        /// <summary>
        /// 整个包的大小 通常是值等于DataLen+4
        /// </summary>
        public virtual int PacketBufLen {
            get;
            set;
        }
        /// <summary>
        /// 包内数据长度(不包括PacketID)
        /// </summary>
        public ushort DataLen { get; set; }
        /// <summary>
        /// int long 等基础数据大小端
        /// </summary>
        public virtual Endian Endian { get; set; }
        #endregion
        //读取数据
        /// <summary>
        /// Reverses the contents of an array
        /// </summary>
        /// <typeparam name="T">type of the array</typeparam>
        /// <param name="buffer">array of objects to reverse</param>
        protected static void Reverse<T>(T[] buffer) {
            Reverse(buffer, buffer.Length);
        }

        /// <summary>
        /// Reverses the contents of an array
        /// </summary>
        /// <typeparam name="T">type of the array</typeparam>
        /// <param name="buffer">array of objects to reverse</param>
        /// <param name="length">number of objects in the array</param>
        protected static void Reverse<T>(T[] buffer, int length) {
            for (int i = 0; i < length / 2; i++) {
                T temp = buffer[i];
                buffer[i] = buffer[length - i - 1];
                buffer[length - i - 1] = temp;
            }
        }


        public virtual void Dispose() {

        }
    }
   
}