using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace 医院住院药房管理系统.Repository
{
    public partial class MedicineSystem : DbContext
    {
        public MedicineSystem()
            : base("name=MedicineSystem")
        {
        }

        public virtual DbSet<ChangeInformation> ChangeInformation { get; set; }
        public virtual DbSet<InventoryForm> InventoryForm { get; set; }
        public virtual DbSet<InventoryType> InventoryType { get; set; }
        public virtual DbSet<IsMedicineRequest> IsMedicineRequest { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<MedicineAttribute> MedicineAttribute { get; set; }
        public virtual DbSet<MedicineBackHall> MedicineBackHall { get; set; }
        public virtual DbSet<MedicineBackStore> MedicineBackStore { get; set; }
        public virtual DbSet<MedicineBad> MedicineBad { get; set; }
        public virtual DbSet<MedicineCheck> MedicineCheck { get; set; }
        public virtual DbSet<MedicineEnterHall> MedicineEnterHall { get; set; }
        public virtual DbSet<MedicineForm> MedicineForm { get; set; }
        public virtual DbSet<MedicineHall> MedicineHall { get; set; }
        public virtual DbSet<MedicineInventory> MedicineInventory { get; set; }
        public virtual DbSet<MedicineLeaveHall> MedicineLeaveHall { get; set; }
        public virtual DbSet<MedicineOutHall> MedicineOutHall { get; set; }
        public virtual DbSet<MedicineProperty> MedicineProperty { get; set; }
        public virtual DbSet<MedicineRequest> MedicineRequest { get; set; }
        public virtual DbSet<MedicineStorage> MedicineStorage { get; set; }
        public virtual DbSet<MedicineType> MedicineType { get; set; }
        public virtual DbSet<Nurse> Nurse { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<OutDateResult> OutDateResult { get; set; }
        public virtual DbSet<SickMan> SickMan { get; set; }
        public virtual DbSet<SickRoom> SickRoom { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<TakeMedicineMan> TakeMedicineMan { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }
        public virtual DbSet<YesNo> YesNo { get; set; }
        public virtual DbSet<MedicineCheckPro> MedicineCheckPro { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<WardNurse> WardNurse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChangeInformation>()
                .Property(e => e.NO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChangeInformation>()
                .Property(e => e.PasswordQuestional1)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeInformation>()
                .Property(e => e.Answer1)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeInformation>()
                .Property(e => e.PasswordQuestional2)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeInformation>()
                .Property(e => e.Answer2)
                .IsUnicode(false);

            modelBuilder.Entity<InventoryForm>()
                .Property(e => e.Text)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<InventoryType>()
                .Property(e => e.Text)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<IsMedicineRequest>()
                .Property(e => e.ReQuestNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.No)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.NamePinyin)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Standard)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.FunctionWork)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.MedicinePropert)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.MedicineForm)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.BatchNo)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.BatchUnit)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.LifeSpan)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.LoginUnit)
                .IsUnicode(false);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Price1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Price2)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Medicine>()
                .Property(e => e.Price3)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MedicineAttribute>()
                .Property(e => e.MedicineNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineBackHall>()
                .Property(e => e.No)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineBackHall>()
                .Property(e => e.HallNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineBackHall>()
                .Property(e => e.NurseNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineBackHall>()
                .Property(e => e.MedicineNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineBackStore>()
                .Property(e => e.RestoreNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineBackStore>()
                .Property(e => e.OperatorNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineBad>()
                .Property(e => e.StoreNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineBad>()
                .Property(e => e.OperatorNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineBad>()
                .Property(e => e.Result)
                .IsUnicode(false);

            modelBuilder.Entity<MedicineCheck>()
                .Property(e => e.No)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineCheck>()
                .Property(e => e.CheckType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineCheck>()
                .Property(e => e.CheckForm)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineCheck>()
                .Property(e => e.OperatorNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineEnterHall>()
                .Property(e => e.RequestNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineEnterHall>()
                .Property(e => e.MedicineNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineEnterHall>()
                .Property(e => e.OperatorNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineForm>()
                .Property(e => e.Text)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineHall>()
                .Property(e => e.No)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineHall>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MedicineInventory>()
                .Property(e => e.No)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineInventory>()
                .Property(e => e.MedicineNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineInventory>()
                .Property(e => e.Supplier)
                .IsUnicode(false);

            modelBuilder.Entity<MedicineInventory>()
                .Property(e => e.ApprovalNumber)
                .IsUnicode(false);

            modelBuilder.Entity<MedicineInventory>()
                .Property(e => e.isHasQualified)
                .IsUnicode(false);

            modelBuilder.Entity<MedicineInventory>()
                .Property(e => e.isQualified)
                .IsUnicode(false);

            modelBuilder.Entity<MedicineInventory>()
                .Property(e => e.OperatorNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineLeaveHall>()
                .Property(e => e.No)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineLeaveHall>()
                .Property(e => e.MedicineNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineLeaveHall>()
                .Property(e => e.NurseNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineOutHall>()
                .Property(e => e.MedicineName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineOutHall>()
                .Property(e => e.WardName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineOutHall>()
                .Property(e => e.RoomName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineOutHall>()
                .Property(e => e.ManName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineOutHall>()
                .Property(e => e.OperateNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineOutHall>()
                .Property(e => e.Nurse)
                .IsUnicode(false);

            modelBuilder.Entity<MedicineProperty>()
                .Property(e => e.Text)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineRequest>()
                .Property(e => e.No)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineRequest>()
                .Property(e => e.EnterNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineRequest>()
                .Property(e => e.MedicineNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineRequest>()
                .Property(e => e.TakeNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineRequest>()
                .Property(e => e.OperatorNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineStorage>()
                .Property(e => e.No)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineStorage>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MedicineType>()
                .Property(e => e.Text)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Nurse>()
                .Property(e => e.No)
                .IsUnicode(false);

            modelBuilder.Entity<Nurse>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Operator>()
                .Property(e => e.NO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Operator>()
                .Property(e => e.UserNo)
                .IsUnicode(false);

            modelBuilder.Entity<Operator>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Operator>()
                .Property(e => e.Sex)
                .IsUnicode(false);

            modelBuilder.Entity<Operator>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Operator>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<OutDateResult>()
                .Property(e => e.Text)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SickMan>()
                .Property(e => e.Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SickRoom>()
                .Property(e => e.Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.No)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Text)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TakeMedicineMan>()
                .Property(e => e.No)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TakeMedicineMan>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Ward>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<YesNo>()
                .Property(e => e.No)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<YesNo>()
                .Property(e => e.Text)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineCheckPro>()
                .Property(e => e.CheckNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineCheckPro>()
                .Property(e => e.StoreNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MedicineCheckPro>()
                .Property(e => e.Remark)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.TypeNo)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.IDName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserType>()
                .Property(e => e.TypeName)
                .IsUnicode(false);
        }
    }
}
