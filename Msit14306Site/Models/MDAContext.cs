using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Msit14306Site.Models
{
    public partial class MDAContext : DbContext
    {
        public MDAContext()
        {
        }

        public MDAContext(DbContextOptions<MDAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<導演總表director> 導演總表directors { get; set; }
        public virtual DbSet<會員member> 會員members { get; set; }
        public virtual DbSet<演員總表actor> 演員總表actors { get; set; }
        public virtual DbSet<電影movie> 電影movies { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MDA;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<導演總表director>(entity =>
            {
                entity.HasKey(e => e.導演編號directorId)
                    .HasName("PK_導演總表 Director");

                entity.ToTable("導演總表Director");

                entity.Property(e => e.導演編號directorId).HasColumnName("導演編號Director_ID");

                entity.Property(e => e.中文名字nameCht)
                    .HasMaxLength(50)
                    .HasColumnName("中文名字Name_Cht");

                entity.Property(e => e.導演照片image).HasColumnName("導演照片Image");

                entity.Property(e => e.英文名字nameEng)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("英文名字Name_Eng");
            });

            modelBuilder.Entity<會員member>(entity =>
            {
                entity.HasKey(e => e.會員編號memberId)
                    .HasName("PK_會員 Members");

                entity.ToTable("會員Members");

                entity.Property(e => e.會員編號memberId).HasColumnName("會員編號Member_ID");

                entity.Property(e => e.名字fName)
                    .HasMaxLength(50)
                    .HasColumnName("名字F_Name");

                entity.Property(e => e.地址address)
                    .HasMaxLength(50)
                    .HasColumnName("地址Address");

                entity.Property(e => e.姓氏lName)
                    .HasMaxLength(50)
                    .HasColumnName("姓氏L_Name");

                entity.Property(e => e.密碼password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("密碼Password");

                entity.Property(e => e.建立時間createdTime)
                    .HasColumnType("date")
                    .HasColumnName("建立時間CreatedTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.性別gender).HasColumnName("性別Gender");

                entity.Property(e => e.暱稱nickName)
                    .HasMaxLength(50)
                    .HasColumnName("暱稱NickName");

                entity.Property(e => e.會員權限permission).HasColumnName("會員權限Permission");

                entity.Property(e => e.會員照片image).HasColumnName("會員照片Image");

                entity.Property(e => e.會員電話cellphone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("會員電話Cellphone")
                    .IsFixedLength(true);

                entity.Property(e => e.正式會員formal).HasColumnName("正式會員Formal");

                entity.Property(e => e.生日birthDate)
                    .HasColumnType("date")
                    .HasColumnName("生日BirthDate");

                entity.Property(e => e.紅利點數bonus).HasColumnName("紅利點數Bonus");

                entity.Property(e => e.電子信箱email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("電子信箱Email");
            });

            modelBuilder.Entity<演員總表actor>(entity =>
            {
                entity.HasKey(e => e.演員編號actorsId)
                    .HasName("PK_Actors");

                entity.ToTable("演員總表Actors");

                entity.Property(e => e.演員編號actorsId).HasColumnName("演員編號Actors_ID");

                entity.Property(e => e.中文名字nameCht)
                    .HasMaxLength(20)
                    .HasColumnName("中文名字Name_Cht");

                entity.Property(e => e.演員照片image).HasColumnName("演員照片Image");

                entity.Property(e => e.英文名字nameEng)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("英文名字Name_Eng");
            });

            modelBuilder.Entity<電影movie>(entity =>
            {
                entity.HasKey(e => e.電影編號movieId)
                    .HasName("PK_Movies");

                entity.ToTable("電影Movies");

                entity.Property(e => e.電影編號movieId).HasColumnName("電影編號Movie_ID");

                entity.Property(e => e.上映年份releaseYear).HasColumnName("上映年份Release_Year");

                entity.Property(e => e.上映日期releaseDate)
                    .HasColumnType("date")
                    .HasColumnName("上映日期Release_Date");

                entity.Property(e => e.中文標題titleCht)
                    .HasMaxLength(50)
                    .HasColumnName("中文標題Title_Cht");

                entity.Property(e => e.劇情大綱plot).HasColumnName("劇情大綱Plot");

                entity.Property(e => e.最後上映日期releasedDate)
                    .HasColumnType("date")
                    .HasColumnName("最後上映日期Released_Date");

                entity.Property(e => e.期待度anticipation).HasColumnType("numeric(2, 1)");

                entity.Property(e => e.片長runtime).HasColumnName("片長Runtime");

                entity.Property(e => e.票房boxOffice)
                    .HasMaxLength(50)
                    .HasColumnName("票房BoxOffice");

                entity.Property(e => e.系列編號seriesId).HasColumnName("系列編號Series_ID");

                entity.Property(e => e.英文標題titleEng)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("英文標題Title_Eng");

                entity.Property(e => e.評分rate)
                    .HasColumnType("numeric(2, 1)")
                    .HasColumnName("評分Rate");

                entity.Property(e => e.電影分級編號ratingId).HasColumnName("電影分級編號Rating_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
