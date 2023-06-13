﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
//  
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Scaffold.API.V1.Models
{
    /// <summary>
    /// 권한명
    /// </summary>
    public partial class ClaimName {

        public ClaimName()
        {
            OnCreated();
        }

        /// <summary>
        /// 권한명 아이디
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// 권한 제목
        /// </summary>
        public virtual string ClaimTitle { get; set; }

        /// <summary>
        /// 권한 타입
        /// </summary>
        public virtual string ClaimType { get; set; }

        /// <summary>
        /// 권한 값
        /// </summary>
        public virtual string ClaimValue { get; set; }

        /// <summary>
        /// 뎁스
        /// </summary>
        public virtual short Depth { get; set; }

        /// <summary>
        /// 순서
        /// </summary>
        public virtual string OrderNo { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}