using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Messages;
using Web.Models;

namespace Web.Business
{
    public class MarketingBLL
    {

        public List<Drivers> SearchMarketing(int? ID, int? OAmin, int? OAmax, int? CONmin, int? CONmax, int? TALmin, int? TALmax, int? AGGmin, int? AGGmax,
            int? EXPmin, int? EXPmax, int? TEImin, int? TEImax, int? STAmin, int? STAmax, int? MOTmin, int? MOTmax)
        {
            using (SmartBagEntities entities = new SmartBagEntities())
            {
                try
                {
                    IQueryable<Drivers> query = entities.Drivers.Where(x=>x.Ativo == true); 
                    //.Select(x => new Drivers
                    //{
                    //    ID = x.ID,
                    //    NAME = x.NAME,
                    //    NAT = x.NAT,
                    //    OA = x.OA,
                    //    CON = x.CON,
                    //    AGE = x.AGE,
                    //    AGG = x.AGG,
                    //    CHA  = x.CHA,
                    //    EXP = x.EXP,
                    //    FEE = x.FEE,
                    //    Last_updated= x.Last_updated,
                    //    MOT = x.MOT,
                    //    OFF = x.OFF,
                    //    REP = x.REP,
                    //    RET = x.RET,
                    //    SAL = x.SAL,
                    //    STA = x.STA,
                    //    TAL = x.TAL,
                    //    TEI = x.TEI,
                    //    WEI = x.WEI
                    //});

                    //select new Marketing
                    //{
                    //    CodMarketing = (int)mk.CodMarketing,
                    //    CodTipoMarketing = (int)tpM.CodTipoMarketing,
                    //    TipoMarketing = tpM.Descricao,
                    //    CodMarca = m.CodMarca,
                    //    Marca = m.Descricao,
                    //    Titulo = mk.Titulo,
                    //    Descricao = mk.Descricao,
                    //    TipoArquivo = mk.TipoArquivo,
                    //    NomeArquivo = mk.NomeArquivo,
                    //    Ativo = mk.IndAtivo == 1,
                    //    Destaque = mk.IndDestaque == 1,
                    //    DataCadastro = mk.CtrlDataOperacao.Value
                    //});

                    if (ID != null)
                    {

                        query = query.Where(x => x.ID == ID);
                    }

                    if (OAmin != null)
                        query = query.Where(x => x.OA >= OAmin);
                    if (OAmax != null)
                        query = query.Where(x => x.OA <= OAmax);
                    if (CONmin != null)
                        query = query.Where(x => x.CON >= CONmin);
                    if (CONmax != null)
                        query = query.Where(x => x.CON <= CONmax);
                    if (TALmin != null)                
                        query = query.Where(x => x.TAL >= TALmin);
                    if (TALmax != null)
                        query = query.Where(x => x.TAL <= TALmax);
                    if (AGGmin != null)                
                        query = query.Where(x => x.AGG >= AGGmin);
                    if (AGGmax != null)
                        query = query.Where(x => x.AGG <= AGGmax);
                    if (EXPmin != null)                
                        query = query.Where(x => x.EXP >= EXPmin);
                    if (EXPmax != null)
                        query = query.Where(x => x.EXP <= EXPmax);
                    if (TEImin != null)                
                        query = query.Where(x => x.TEI >= TEImin);
                    if (TEImax != null)
                        query = query.Where(x => x.TEI <= TEImax);
                    if (STAmin != null)                
                        query = query.Where(x => x.STA >= STAmin);
                    if (STAmax != null)
                        query = query.Where(x => x.STA <= STAmax);
                    if (MOTmin != null)                
                        query = query.Where(x => x.MOT >= MOTmin);
                    if (MOTmax != null)
                        query = query.Where(x => x.MOT <= MOTmax);

                    return query.OrderBy(x => x.OA).Take(30).ToList();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        public Web.Models.Drivers GetDriver(int ID)
        {

            using (SmartBagEntities entities = new SmartBagEntities())
            {
                try
                {
                    Web.Models.Drivers tBT_Marketing = entities.Drivers.Where(x => x.ID == ID)
                                               .FirstOrDefault();

                    return tBT_Marketing;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }


        //public bool SaveEdit(Marketing mkt)
        //{
        //    using (SmartBagEntities entities = new SmartBagEntities())
        //    {
        //        try
        //        {
        //            TBT_MARKETING m = entities.TBT_MARKETING.Find((decimal)mkt.CodMarketing);
        //            m.Titulo = mkt.Titulo;
        //            m.CodTipoMarketing = mkt.CodTipoMarketing;
        //            m.Descricao = mkt.Descricao;
        //            m.TipoArquivo = mkt.TipoArquivo;
        //            m.NomeArquivo= mkt.NomeArquivo;
        //            m.IndAtivo = mkt.Ativo ? 1 : 0;
        //            m.CodMarca = mkt.CodMarca;
        //            entities.Entry(m).State = EntityState.Modified;
        //            entities.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }

        //    }

        //}

        //public Marketing IncluirMkt(Marketing mkt)
        //{
        //    using (SmartBagEntities entities = new SmartBagEntities())
        //    {
        //        try
        //        {
        //            int codMarketing = (int)entities.TBT_MARKETING.Select(x => x.CodMarketing).OrderByDescending(x => x).FirstOrDefault() + 1;
        //            TBT_MARKETING m = new TBT_MARKETING();
        //            m.CodMarketing = codMarketing;
        //            m.Titulo = mkt.Titulo;
        //            m.CodTipoMarketing = mkt.CodTipoMarketing;
        //            m.Descricao = mkt.Descricao;
        //            m.TipoArquivo = mkt.TipoArquivo;
        //            m.NomeArquivo = mkt.NomeArquivo;
        //            m.IndAtivo = mkt.Ativo ? 1 : 0;
        //            m.CodMarca = mkt.CodMarca;
        //            entities.TBT_MARKETING.Add(m);
        //            entities.Entry(m).State = EntityState.Added;
        //            entities.SaveChanges();

        //            //TBT_MARKETING m2 = entities.TBT_MARKETING.Find((decimal)mkt.CodMarketing);
        //            //m2.CodMarketing = m2.ID;
        //            //entities.Entry(m2).State = EntityState.Modified;
        //            //entities.SaveChanges();

        //            return GetMarketing((int)m.CodMarketing);

        //        }
        //        catch (Exception e)
        //        {
        //            return null;
        //        }
        //    }
        //}
        //public List<Inspection_Search> ListofInspection(string DtInitialDate, string DtFinalDate, int? TxtSituation,
        //    string txtnroInspection, string TxtClient, int? ResultCode, string Code,
        //    string Supplier, string PINumber, string ItemCode, string ProductType, string InspectorCode)
        //{

        //        var query = (from ins in entities.TBT_INSPECTION
        //                     join c in entities.TBT_CLIENT
        //                     on ins.ClientCode equals c.ClientCode
        //                     join f in entities.TBT_FACTORY
        //                     on ins.FactoryCode equals f.FactoryCode
        //                     join s in entities.TBT_STATUS
        //                     on ins.StatusCode equals s.StatusCode
        //                     join i in entities.TBT_INSPECTOR
        //                     on ins.InspectorCode equals i.InspectorCode
        //                     join z in entities.TBT_SUPPLIER
        //                     on ins.SupplierCode equals z.SupplierCode
        //                     join item in entities.TBT_ITEM
        //                     on new { ins.ClientCode, ins.ItemCode } equals new { item.ClientCode, item.ItemCode }
        //                     join pt in entities.TBT_PRODUCT_TYPE
        //                     on item.ProductTypeCode equals pt.ProductTypeCode
        //                     join r in entities.TBT_RESULT
        //                    on ins.OverallInspectionResultCode equals r.ResultCode
        //                     into _t
        //                     from a in _t.DefaultIfEmpty()
        //                     let cCount = (from ism in entities.TBT_INSPECTION_SAMPLE_MEASURE
        //                                   where ins.InspectionCode == ism.InspectionCode && ism.DifferenceValue > 0
        //                                   select ism
        //                        ).Count()

        //                     select new Inspection_Search
        //                     {
        //                         InspectorName = i.Name,
        //                         InspectionCode = ins.InspectionCode.ToString().Replace(",00", ""),
        //                         InspectionNumber = ins.InspectionNumber.ToString().Replace(",00", ""),
        //                         Factory = f.Description,
        //                         InspectionFinish = ins.InspectionFinish,
        //                         InspectionLocation = ins.InspectionLocation,
        //                         InspectionDate = ins.InspectionDate.Value,
        //                         InspectorCode = ins.InspectorCode,
        //                         SituationName = s.Description,
        //                         ClientName = c.Name,
        //                         Situation = s.StatusCode,
        //                         OverallInspectionResult = a.Description,
        //                         OverallInspectionResultCode = a.ResultCode,
        //                         ItemCode = ins.ItemCode,
        //                         ErrorsCount = cCount,
        //                         SupplierName = z.Name,
        //                         ProductTypeCode = pt.ProductTypeCode.ToString().Replace(",00", ""),
        //                         PINumber = ins.PINumber,
        //                         OrderTotalQuantity = ins.OrderTotalQuantity
        //                     });


        //        if (!string.IsNullOrEmpty(TxtClient))
        //        {
        //            query = query.Where(x => x.ClientName.Contains(TxtClient));
        //        }

        //        if (TxtSituation > 0)
        //        {
        //            query = query.Where(x => x.Situation == TxtSituation);
        //        }
        //        if (ResultCode > 0)
        //        {
        //            query = query.Where(x => x.OverallInspectionResultCode == ResultCode);
        //        }
        //        if (!string.IsNullOrEmpty(Code))
        //        {
        //            query = query.Where(x => x.InspectionCode.Equals(Code));
        //        }

        //        if (!string.IsNullOrEmpty(txtnroInspection))
        //        {
        //            query = query.Where(x => x.InspectionNumber.Equals(txtnroInspection));
        //        }

        //       if (!string.IsNullOrEmpty(Supplier))
        //       {
        //           query = query.Where(x => x.SupplierName.Equals(Supplier));
        //       }

        //         if (!string.IsNullOrEmpty(ProductType))
        //       {
        //           query = query.Where(x => x.ProductTypeCode.Equals(ProductType));
        //       }

        //         if (!string.IsNullOrEmpty(PINumber))
        //       {
        //           query = query.Where(x => x.PINumber.Equals(PINumber));
        //       }

        //         if (!string.IsNullOrEmpty(ItemCode))
        //       {
        //           query = query.Where(x => x.ItemCode.Equals(ItemCode));
        //       }


        //       if (!string.IsNullOrEmpty(DtInitialDate))
        //        {
        //            CultureInfo cultura = new CultureInfo("en-US");
        //            DateTime DtConvertido = Convert.ToDateTime(DtInitialDate);
        //            query = query.Where(x => x.InspectionDate >= DtConvertido);
        //        }
        //       if (!string.IsNullOrEmpty(DtFinalDate))
        //        {
        //            string date = string.Format(DtFinalDate + " 12:59:59 PM");
        //            CultureInfo cultura = new CultureInfo("en-US");
        //            DateTime DtConvertido = Convert.ToDateTime(date);
        //            query = query.Where(x => x.InspectionDate <= DtConvertido);
        //        }

        //       if (!string.IsNullOrEmpty(InspectorCode))
        //       {
        //           decimal codInspetor = Convert.ToDecimal(InspectorCode);
        //           query = query.Where(x => x.InspectorCode == codInspetor);
        //       }

        //       return query.OrderByDescending(x => x.InspectionDate).ThenBy(x => x.SupplierName).ToList();
        //    }
        //}

        //public int GetTotalInspectionProducts(decimal id)
        //{
        //    using (SmartBagEntities entities = new SmartBagEntities())
        //    {
        //        var query = (from IP in entities.TBT_INSPECTION_PRODUCT.Where(x => x.InspectionCode == id) select 1).Count();
        //        return query;
        //    }
        //}

        //public Uploads GetInspection(decimal? id)
        //{
        //    using (SmartBagEntities entities = new SmartBagEntities())
        //    {
        //        var query = (from ins in entities.TBT_INSPECTION.Where(x => x.ID == id)
        //                     join it in entities.TBT_ITEM
        //                     on ins.ItemCode equals it.ItemCode
        //                     join sup in entities.TBT_SUPPLIER
        //                     on ins.SupplierCode equals sup.SupplierCode
        //                     join c in entities.TBT_CLIENT
        //                     on ins.ClientCode equals c.ClientCode
        //                     join f in entities.TBT_FACTORY
        //                     on ins.FactoryCode equals f.FactoryCode
        //                     join s in entities.TBT_STATUS
        //                     on ins.StatusCode equals s.StatusCode
        //                     join i in entities.TBT_INSPECTOR
        //                     on ins.InspectorCode equals i.InspectorCode
        //                     join r in entities.TBT_RESULT
        //                    on ins.OverallInspectionResultCode equals r.ResultCode
        //                     into _t
        //                     from a in _t.DefaultIfEmpty()

        //                     select new Uploads
        //                     {
        //                         InspectorName = i.Name,
        //                         Supplier = sup.Name,
        //                         SupplierCode = sup.SupplierCode,
        //                         InspectionCode = (int)ins.InspectionCode,
        //                         InspectionNumber = (int)ins.InspectionNumber,
        //                         FactoryCode = f.FactoryCode,
        //                         Factory = f.Description,
        //                         InspectionFinish = ins.InspectionFinish,
        //                         InspectionLocation = ins.InspectionLocation,
        //                         InspectionDate = ins.InspectionDate.Value,
        //                         InspectorCode = (int)ins.InspectorCode,
        //                         SituationName = s.Description,
        //                         ClientCode = c.ClientCode,
        //                         ClientName = c.Name,
        //                         Situation = s.StatusCode,
        //                         OverallInspectionResult = a.Description,
        //                         OverallInspectionResultCode = a.ResultCode,
        //                         ItemCode = ins.ItemCode,
        //                         OrderTotalQuantity = (int)ins.OrderTotalQuantity,
        //                         Responsible = ins.ResponsibleName,
        //                         PINumber = ins.PINumber,
        //                         ClientSpecialRequest = ins.ClientSpecialRequest,
        //                         Products = entities.TBT_PRODUCT.Where(x => x.ItemCode == it.ItemCode)
        //                         .Select(x => new Inspection_Products { ProductCode = x.ProductCode, Product = x.Description }).ToList()
        //                     }).FirstOrDefault();

        //        var temp = entities.TBT_INSPECTION_PRODUCT.Where(x => x.InspectionCode == query.InspectionCode);

        //        if (id != null)
        //        {
        //            foreach (var item in query.Products)
        //                item.Checked = temp.Where(x => x.ProductCode == item.ProductCode).FirstOrDefault() == null ? false : true;
        //        }
        //        return query;
        //    }
        //}
        //public string GetClientSpecialRequest(decimal? inspeccode)
        //{
        //    using (SmartBagEntities entities = new SmartBagEntities())
        //    {
        //        var query = entities.TBT_INSPECTION.Where(x => x.InspectionCode == inspeccode).Select(x => x.ClientSpecialRequest).FirstOrDefault();

        //        return query;
        //    }
        //}

        //public decimal? Create(decimal ClientCode, decimal InspectorCode, decimal SupplierCode, string PINumber, decimal InspectionNumber, string InspectionLocation, decimal FactoryCode, string ResponsibleName, decimal OrderTotalQuantity, string ItemCode, string subName, string ClientSpecialRequest)
        //{
        //    using (SmartBagEntities entities = new SmartBagEntities())
        //    {
        //        //var query = entities.TBT_INSPECTION
        //        //                    .Where(x => x.PINumber == PINumber && x.InspectionNumber == InspectionNumber)
        //        //                    .FirstOrDefault();

        //        //if (query != null)
        //        //{
        //        //    return null;
        //        //}
        //        //else
        //        //{
        //            TBT_INSPECTION ins = new TBT_INSPECTION();
        //            ins.InspectorCode = InspectorCode;
        //            ins.ClientCode = ClientCode;
        //            ins.SupplierCode = SupplierCode;
        //            ins.PINumber = PINumber;
        //            ins.InspectionNumber = InspectionNumber;
        //            ins.InspectionLocation = InspectionLocation;
        //            ins.FactoryCode = FactoryCode;
        //            ins.ResponsibleName = ResponsibleName;
        //            ins.InspectionDate = DateTime.Now.Date;
        //            ins.OrderTotalQuantity = OrderTotalQuantity;
        //            ins.StatusCode = 2;
        //            ins.ItemCode = ItemCode;
        //            ins.ClientSpecialRequest = ClientSpecialRequest;
        //            entities.TBT_INSPECTION.Add(ins);

        //            entities.SaveChanges();

        //            if (!string.IsNullOrEmpty(subName))
        //            {
        //                foreach (var item in subName.Split(','))
        //                {
        //                    TBT_INSPECTION_PRODUCT tip = new TBT_INSPECTION_PRODUCT();
        //                    tip.InspectionCode = ins.InspectionCode;
        //                    tip.ProductCode = Convert.ToDecimal(item);
        //                    entities.TBT_INSPECTION_PRODUCT.Add(tip);
        //                }
        //            }

        //            entities.SaveChanges();

        //            return ins.InspectionCode;
        //        //}
        //    }

        //}

        //public void CopyInsProducts(int idSource, int idDestiny)
        //{
        //    using (SmartBagEntities entities = new SmartBagEntities())
        //    {
        //        var get = (from IP in entities.TBT_INSPECTION_PRODUCT.Where(p => p.InspectionCode == idSource)
        //                       select new  
        //                       {
        //                           InspectionCode = idDestiny,
        //                           ProductCode = IP.ProductCode
        //                       }).ToList();

        //        List<TBT_INSPECTION_PRODUCT> toInsert = new List<TBT_INSPECTION_PRODUCT>();
        //        foreach (var i in get)
        //        { 
        //            TBT_INSPECTION_PRODUCT p = new TBT_INSPECTION_PRODUCT();
        //            p.ProductCode = i.ProductCode;
        //            p.InspectionCode = i.InspectionCode;
        //            toInsert.Add(p);
        //        }

        //        var res = entities.TBT_INSPECTION_PRODUCT.AddRange(toInsert);
        //        entities.SaveChanges();
        //    }
        //}


    }
}