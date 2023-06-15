using Assignment.IServices;
using ClassLibrary1.Models;
using System.Collections.Generic;

namespace Assignment.Services
{
    public class ChiTietSpServices : IChiTietSpServices
    {
        CuaHangGiayDBContext context;
        public ChiTietSpServices()
        {
            context = new CuaHangGiayDBContext();
        }
        public bool CreateChiTietSp(ChiTietSp p)
        {
            try
            {
                context.ChiTietSps.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteChiTietSp(Guid id)
        {
            try
            {
                var ChiTietSp = context.ChiTietSps.Find(id);
                context.ChiTietSps.Remove(ChiTietSp);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ChiTietSp> GetAllChiTietSps()
        {
            return context.ChiTietSps.ToList();
        }


        public ChiTietSp GetChiTietSpById(Guid id)
        {
            return context.ChiTietSps.FirstOrDefault(p => p.Id == id);
        }

        public List<ChiTietSp> GetChiTietSpByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateChiTietSp(ChiTietSp p)
        {

            try
            {
                
                var ChiTietSp = context.ChiTietSps.Find(p.Id);
                //if (ChiTietSp.GiaBan > p.GiaBan)
                //{
                var x=context.ChiTietSps.FirstOrDefault(x => x.Ten == p.Ten && x.IdKieuSp == p.IdKieuSp && x.Id != p.Id);
                if (x!=null)
                {
                    return false;
                }
                else
                {
                    ChiTietSp.GiaBan = p.GiaBan;
                    ChiTietSp.Ten = p.Ten;

                    ChiTietSp.IdMauSac = p.IdMauSac;
                    ChiTietSp.IdKichCo = p.IdKichCo;
                    ChiTietSp.IdKieuSp = p.IdKieuSp;
                    ChiTietSp.BaoHanh = p.BaoHanh;
                    ChiTietSp.MoTa = p.MoTa;
                    ChiTietSp.SoLuongTon = p.SoLuongTon;
                    ChiTietSp.GiaNhap = p.GiaNhap;
                    ChiTietSp.LinkAnh = p.LinkAnh;
                    ChiTietSp.TrangThai = p.TrangThai;
                    context.SaveChanges();
                    return true;
                }
               
                //}
                //else return false;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
