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
           // context.Dynamic_Cylinders.AddOrUpdate(x => x.Id,new Dynamic_Cylinder() { Id = 1, 型号 = "2FRW16-3X160L6AYG24", 序列号 = "123456789", 制造商 = "REXROTH" });
            //context.check_valve.AddOrUpdate(x => x.Id,
            //    new check_valve() { Id = 1, 型号 = "Z1S16T3-30", 序列号 = "123456789", 制造商 = "LIXIN", 额定压力 = 15, 额定流量 = 200, P口耐压 = 0, A口耐压 = 0, B口耐压 = 15, T口耐压 = 0, 液控 = false });
            //context.elemagdirection_valve.AddOrUpdate(x => x.Id,
            //    new elemag_direction_valve() { Id = 1, 型号 = "4WE6J73-6X/EG24N9K4/A12", 序列号 = "123456789", 制造商 = "REXROTH", 额定压力 = 15, 额定流量 = 80, P口耐压 = 0, A口耐压 = 15, B口耐压 = 0, T口耐压 = 0 });
            //context.electrohyd_valves.AddOrUpdate(x => x.Id,
                //new electrohyd_valve()
                //{
                //    Id = 1,
                //    型号 = "4WH16E7X/06EG24N9ETK4",
                //    序列号 = "123456789",
                //    制造商 = "REXROTH",
                //    额定压力 = 25,
                //    额定流量 = 150,
                //    P口耐压 = 0,
                //    A口耐压 = 25,
                //    B口耐压 = 0,
                //    T口耐压 = 0
                //});
            
            //{ Id = 1, 型号 = "H-4WEH16J-L6X/6EG24NS2Z467-H/JH1", 制造商 = "REXROTH", 额定压力 = 15, 额定流量 = 150, P口耐压 = 0, A口耐压 = 15, B口耐压 = 0, T口耐压 = 0 });
            //context.hydraulic_valves.AddOrUpdate(x => x.Id,
            //    new hydraulic_valve() { Id = 1, 型号 = "4HWH16E7X/0", 序列号 = "123456789", 制造商 = "REXROTH", 额定压力 = 15, 额定流量 = 150, P口耐压 = 0, A口耐压 = 15, B口耐压 = 0, T口耐压 = 0 });
            //context.manual_valves.AddOrUpdate(x => x.Id,
            //    new manual_valve() { Id = 1, 型号 = "4WMM6E-L6X/F", 序列号 = "123456789", 制造商 = "REXROTH", 额定压力 = 15, 额定流量 = 50, P口耐压 = 0, A口耐压 = 15, B口耐压 = 0, T口耐压 = 0 });
            //context.mechopera_valves.AddOrUpdate(x => x.Id,
            //    new mechopera_valve() { Id = 1, 型号 = "4WH16E7X/0", 序列号 = "123456789", 制造商 = "REXROTH", 额定压力 = 15, 额定流量 = 50, P口耐压 = 0, A口耐压 = 15, B口耐压 = 0, T口耐压 = 0 });
            //context.reduce_valves.AddOrUpdate(x => x.Id,
            //    new reduce_valve()
            //    {
            //        Id = 1,
            //        型号 = "DR20-4-5X/315Y",
            //        序列号 = "123456789",
            //        制造商 = "REXROTH",
            //        额定压力 = 25,
            //        额定流量 = 150,
            //        P口耐压 = 25,
            //        A口耐压 = 0,
            //        B口耐压 = 0,
            //        T口耐压 = 0,
            //        有外泄漏口 = false

            //    });
            //{ Id = 1, 型号 = "2FRW16-3X160L6AYG24", 制造商 = "REXROTH", 额定压力 = 31.5, 额定流量 = 160, P口耐压 = 10, A口耐压 = 0, B口耐压 = 0, T口耐压 = 0, 有外泄漏口 = false });
            //context.relief_valves.AddOrUpdate(x => x.Id,
            //    new relief_valve() { Id = 1, 型号 = "2FRW16-3X160L6AYG24", 序列号 = "123456789", 制造商 = "REXROTH", 额定压力 = 15, 额定流量 = 160, P口耐压 = 10, A口耐压 = 0, B口耐压 = 0, T口耐压 = 0 });
            //context.hydcheck_valves.AddOrUpdate(x => x.Id,
            //    new hydcheck_valve() { Id = 1, 型号 = "Z1S16T3-30", 序列号 = "123456789", 制造商 = "LIXIN", 额定压力 = 15, 额定流量 = 140, P口耐压 = 0, A口耐压 = 15, B口耐压 = 0, T口耐压 = 0, 液控 = true, 开启压力 = 0.6 });
            //context.propodirection_valves.AddOrUpdate(x => x.Id,
            //    new Propodirection_valve() { Id = 1, 型号 = "4WRZ10E85-7X/6EG24N9K4/V", 序列号 = "123456789", 制造商 = "REXROTH", 额定压力 = 10, 额定流量 = 200, P口耐压 = 0, A口耐压 = 10, B口耐压 = 0, T口耐压 = 0, 液控 = true, X口压力 = 5 });
        }
    }
}
