using Assignment.IServices;
using ClassLibrary1.Models;
using Gremlin.Net.Process.Traversal;

namespace Assignment.Services
{
    public class GioHangChiTietServices : IGioHangChiTietServices
    {


        CuaHangGiayDBContext context;
        public GioHangChiTietServices()
        {
            context = new CuaHangGiayDBContext();
        }
        public bool CreateGioHangChiTiet(/*Guid userId, Guid productId*/GioHangChiTiet p)
        {
            //var cartItem = context.GioHangChiTiets
            //    .Where(x => x.UserId == userId && x.IdChiTietSp == productId)
            //    .FirstOrDefault();
            //ChiTietSp sp = context.ChiTietSps.Find(productId);
            //if (cartItem == null)
            //{
            //    cartItem = new GioHangChiTiet
            //    {
            //        Id = Guid.NewGuid(),
            //        IdChiTietSp = productId,
            //        UserId = userId,
            //        SoLuong = 1,
            //        DonGia = sp.GiaBan,
            //        TrangThai = 0
            //    };

            //    context.GioHangChiTiets.Add(cartItem);
            //}
            //else
            //{
            //    cartItem.SoLuong += 1;
            //    context.GioHangChiTiets.Update(cartItem);
            //}

            //try
            //{
            //    context.SaveChanges();
            //    return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
            try
            {
                context.GioHangChiTiets.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
      
        public bool AddProductToCart(Guid userId, Guid productId, int quantity)
        {
            // Tìm kiếm sản phẩm trong giỏ hàng chi tiết của người dùng
            var cartItem = context.GioHangChiTiets
                .Where(x => x.UserId == userId && x.IdChiTietSp == productId)
                .FirstOrDefault();
            ChiTietSp sp = context.ChiTietSps.Find(productId);
            if (cartItem == null)
            {
                // Nếu sản phẩm chưa có trong giỏ hàng chi tiết, tạo mới bản ghi
                cartItem = new GioHangChiTiet
                {
                    Id = Guid.NewGuid(),
                    IdChiTietSp = productId,
                    UserId = userId,
                    SoLuong = quantity,
                    DonGia = sp.GiaBan,
                    TrangThai = 0
                };

                context.GioHangChiTiets.Add(cartItem);
            }
            else
            {
                // Nếu sản phẩm đã tồn tại trong giỏ hàng chi tiết, cộng dồn số lượng mới vào số lượng cũ
                cartItem.SoLuong += quantity;
                context.GioHangChiTiets.Update(cartItem);
            }

            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteGioHangChiTiet(Guid id)
        {
            try
            {
                var Anh = context.GioHangChiTiets.Find(id);
                context.GioHangChiTiets.Remove(Anh);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GioHangChiTiet> GetAllGioHangChiTiets()
        {
            return context.GioHangChiTiets.ToList();
        }


        public GioHangChiTiet GetGioHangChiTietById(Guid id)
        {
            return context.GioHangChiTiets.FirstOrDefault(p => p.Id == id);
        }

        //public List<GioHangChiTiet> GetAnhByName(string name)
        //{
        //    return context.GioHangChiTiets.Where(p => p.t.Contains(name)).ToList();
        //}

        public bool UpdateGioHangChiTiet(GioHangChiTiet p)
        {

            try
            {
                var Anh = context.GioHangChiTiets.Find(p.Id);
                Anh.IdChiTietSp=p.IdChiTietSp;
                Anh.TrangThai=p.TrangThai;
                Anh.DonGia=p.DonGia;
                Anh.SoLuong=p.SoLuong;
                Anh.UserId=p.UserId;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       
    }
}
