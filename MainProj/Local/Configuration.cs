namespace MainProj.Local
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MainProj.Local.LocalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; 
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MainProj.Local.LocalDbContext context)
        {
            //rc28389
           // context.Dynamic_Cylinders.AddOrUpdate(x => x.Id,new Dynamic_Cylinder() { Id = 1, �ͺ� = "2FRW16-3X160L6AYG24", ���к� = "123456789", ������ = "REXROTH" });
            //context.check_valve.AddOrUpdate(x => x.Id,
            //    new check_valve() { Id = 1, �ͺ� = "Z1S16T3-30", ���к� = "123456789", ������ = "LIXIN", �ѹ�� = 15, ����� = 200, P����ѹ = 0, A����ѹ = 0, B����ѹ = 15, T����ѹ = 0, Һ�� = false });
            //context.elemagdirection_valve.AddOrUpdate(x => x.Id,
            //    new elemag_direction_valve() { Id = 1, �ͺ� = "4WE6J73-6X/EG24N9K4/A12", ���к� = "123456789", ������ = "REXROTH", �ѹ�� = 15, ����� = 80, P����ѹ = 0, A����ѹ = 15, B����ѹ = 0, T����ѹ = 0 });
            //context.electrohyd_valves.AddOrUpdate(x => x.Id,
                //new electrohyd_valve()
                //{
                //    Id = 1,
                //    �ͺ� = "4WH16E7X/06EG24N9ETK4",
                //    ���к� = "123456789",
                //    ������ = "REXROTH",
                //    �ѹ�� = 25,
                //    ����� = 150,
                //    P����ѹ = 0,
                //    A����ѹ = 25,
                //    B����ѹ = 0,
                //    T����ѹ = 0
                //});
            
            //{ Id = 1, �ͺ� = "H-4WEH16J-L6X/6EG24NS2Z467-H/JH1", ������ = "REXROTH", �ѹ�� = 15, ����� = 150, P����ѹ = 0, A����ѹ = 15, B����ѹ = 0, T����ѹ = 0 });
            //context.hydraulic_valves.AddOrUpdate(x => x.Id,
            //    new hydraulic_valve() { Id = 1, �ͺ� = "4HWH16E7X/0", ���к� = "123456789", ������ = "REXROTH", �ѹ�� = 15, ����� = 150, P����ѹ = 0, A����ѹ = 15, B����ѹ = 0, T����ѹ = 0 });
            //context.manual_valves.AddOrUpdate(x => x.Id,
            //    new manual_valve() { Id = 1, �ͺ� = "4WMM6E-L6X/F", ���к� = "123456789", ������ = "REXROTH", �ѹ�� = 15, ����� = 50, P����ѹ = 0, A����ѹ = 15, B����ѹ = 0, T����ѹ = 0 });
            //context.mechopera_valves.AddOrUpdate(x => x.Id,
            //    new mechopera_valve() { Id = 1, �ͺ� = "4WH16E7X/0", ���к� = "123456789", ������ = "REXROTH", �ѹ�� = 15, ����� = 50, P����ѹ = 0, A����ѹ = 15, B����ѹ = 0, T����ѹ = 0 });
            //context.reduce_valves.AddOrUpdate(x => x.Id,
            //    new reduce_valve()
            //    {
            //        Id = 1,
            //        �ͺ� = "DR20-4-5X/315Y",
            //        ���к� = "123456789",
            //        ������ = "REXROTH",
            //        �ѹ�� = 25,
            //        ����� = 150,
            //        P����ѹ = 25,
            //        A����ѹ = 0,
            //        B����ѹ = 0,
            //        T����ѹ = 0,
            //        ����й©�� = false

            //    });
            //{ Id = 1, �ͺ� = "2FRW16-3X160L6AYG24", ������ = "REXROTH", �ѹ�� = 31.5, ����� = 160, P����ѹ = 10, A����ѹ = 0, B����ѹ = 0, T����ѹ = 0, ����й©�� = false });
            //context.relief_valves.AddOrUpdate(x => x.Id,
            //    new relief_valve() { Id = 1, �ͺ� = "2FRW16-3X160L6AYG24", ���к� = "123456789", ������ = "REXROTH", �ѹ�� = 15, ����� = 160, P����ѹ = 10, A����ѹ = 0, B����ѹ = 0, T����ѹ = 0 });
            //context.hydcheck_valves.AddOrUpdate(x => x.Id,
            //    new hydcheck_valve() { Id = 1, �ͺ� = "Z1S16T3-30", ���к� = "123456789", ������ = "LIXIN", �ѹ�� = 15, ����� = 140, P����ѹ = 0, A����ѹ = 15, B����ѹ = 0, T����ѹ = 0, Һ�� = true, ����ѹ�� = 0.6 });
            //context.propodirection_valves.AddOrUpdate(x => x.Id,
            //    new Propodirection_valve() { Id = 1, �ͺ� = "4WRZ10E85-7X/6EG24N9K4/V", ���к� = "123456789", ������ = "REXROTH", �ѹ�� = 10, ����� = 200, P����ѹ = 0, A����ѹ = 10, B����ѹ = 0, T����ѹ = 0, Һ�� = true, X��ѹ�� = 5 });
        }
    }
}
