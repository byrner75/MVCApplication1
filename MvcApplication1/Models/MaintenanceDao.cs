using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gateway.Data;
using Gateway.Data.Entities;
using System.Linq.Dynamic;

namespace MvcApplication1.Models
{
    public static class DaoExtensions
    {
        public static BranchGatewayProtocol WithId(this IQueryable<BranchGatewayProtocol> qry, int Id)
        {
            return (from r in qry where r.id == Id select r).SingleOrDefault<BranchGatewayProtocol>();
        }
    }

    public class MaintenanceDao
    {
        static private GatewayDbContext _ctx = new GatewayDbContext() { ObjectTrackingEnabled = false };

        public static IQueryable<BranchGatewayProtocol> GetBranchGatewayProtocol()
        {
            return _ctx.BranchGatewayProtocols;
        }

        public static IQueryable<BranchGatewayProtocol> GetBranchGatewayProtocol(int page, int pageSize, ref int total, string sidx, string sord)
        {
            total = _ctx.BranchGatewayProtocols.Count();
            return _ctx.BranchGatewayProtocols.OrderBy(sidx, sord).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static void SaveBranchGatewayProtocol(BranchGatewayProtocol change)
        {
            using (GatewayDbContext ctx = new GatewayDbContext())
            {
                if (change.id > 0)
                {
                    BranchGatewayProtocol orig = ctx.BranchGatewayProtocols.Single(o => o.id == change.id);

                    orig.Branch = change.Branch;
                    orig.ClientApplicationName = change.ClientApplicationName;
                    orig.FinancialInstitution = change.FinancialInstitution;
                    orig.GatewayId = change.GatewayId;
                    orig.Protocol = change.Protocol;
                    orig.SourceType = change.SourceType;
                    orig.SubOffice = change.SubOffice;
                }
                else
                {
                    ctx.BranchGatewayProtocols.InsertOnSubmit(change);
                }
                ctx.SubmitChanges();
            }
        }
    }
}
