// ***********************************************************************
// Solution         : KC.Foundation
// Project          : KC.Foundation
// File             : Time.cs
// Updated          : 2017-08-21 1:58 PM
// ***********************************************************************
// <copyright>
//     Copyright © 2016 - 2018 Kolibre Credit Team. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using DDDSample.Infrastructure.Extensions;

namespace DDDSample.Infrastructure.Utilities
{
    public static class Time
    {
        public static DateTimeOffset Now => DateTimeOffset.UtcNow.ToChinaStandardTime();

        public static DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

        public static DateTimeOffset Today => new DateTimeOffset(Now.Year, Now.Month, Now.Day, 0, 0, 0, 0, TimeSpan.FromHours(8));

        public static DateTimeOffset CurrentMonth => new DateTimeOffset(Now.Year, Now.Month, 1, 0, 0, 0, 0, TimeSpan.FromHours(8));

        public static DateTimeOffset CurrentYear => new DateTimeOffset(Now.Year, 1, 1, 0, 0, 0, 0, TimeSpan.FromHours(8));
    }
}