using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Net7Api.Data;

/// <summary>
/// DB컨텍스트
/// </summary>
public partial class Net7Context : IdentityDbContext
{
    /// <summary>
    /// DB 컨텍스트 옵션 
    /// </summary>
    private readonly DbContextOptions m_dbContextOptions;

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="dbContextOptions">DB 컨텍스트 옵션</param>
    public Net7Context(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        this.m_dbContextOptions = dbContextOptions;
    }
    
    
}