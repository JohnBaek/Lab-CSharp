using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffold.API.V1.Models
{
    /// <summary>
    /// 잡 관련 정보
    /// </summary>
    public class Job
    {
        /// <summary>
        /// 아이디 
        /// </summary>
        public Guid Id { get; set; }
    
        /// <summary>
        ///  작업명
        /// </summary>
        public string Name { get; set; } = "";
    }
}
