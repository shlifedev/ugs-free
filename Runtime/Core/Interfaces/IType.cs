﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGS.Runtime.Core.Interfaces
{
    public interface IType
    {
   
    }

    /// <summary>
    /// 대부분 리플렉션을 해야하는 데이터 특성상 object로 처리하기 때문에
    /// T 입력 자체는 사실 아무런 의미가 없지만 사용자의 UGS API 사용경험을 향상시켜 주기 위함.
    ///
    /// 나중에 제네릭 관련 코드를 모드 object로 변경해도 되지만
    /// 임시로 냅두고 DeclareType을 따로선언해서 처리
    /// <typeparam name="T"></typeparam>
    public interface IType<T> : IType
    {       
        /// <summary>
        /// All Type Names Auto Convert To Lower. (Int => int), (iNT => int)
        /// </summary> 
        public List<string> TypeDeclarations { get; }

        public T Read(string value);

        public string Write(T value);
    }
}
