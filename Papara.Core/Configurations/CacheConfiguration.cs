using System;
using System.Collections.Generic;
using System.Text;

namespace Papara.Core.Configurations
{
    public class CacheConfiguration
    {
        // MemoryCacheService de setliyoruz.
        public int AbsoluteExpirationInHours { get; set; }  // 1 saat setlendi. Garanti güncelleme süresi
        public int SlidingExpirationInSeconds { get; set; }  // örnek 5 sn setlendi. Bu süre içersinde eğer cache e bir get isteği gelmezse cache i günceller. Yani 5 sn sonra cache güncellicek fakat öncesinde get işlemi yapılmamış olması lazım.
    }
}
