using Entities.Models;
using Entities.ModelsDto;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        private readonly RepositoryContext _context;
        public RepositoryUser(RepositoryContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true; // Başarıyla kaydedildi
            }
            catch (Exception)
            {
                // Kayıt sırasında bir hata oluştu
                return false;
            }
        }
        public IQueryable<User> FindByCondition(Expression<Func<User, bool>> expression)
        {
            return _context.Users.Where(expression);
        }
        public async Task<int> CountAsync()
        {
            return await _context.Users.CountAsync();
        }
        public async Task<int> CountAsync(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.CountAsync(expression);
        }

        public async Task<bool> CheckRoomAvailabilityAsync(UserDto userDto)
        {
            try
            {
                // Rezervasyon yapılacak tarih aralığı
                DateTime checkInDate = userDto.CheckInDate;
                DateTime checkOutDate = userDto.CheckOutDate;

                // Rezervasyon yapılacak oda tipi
                RoomType roomType = userDto.RoomType;

                // Belirli bir tarih aralığında, belirli bir oda tipindeki rezervasyonları getir
                var existingReservations = await _context.Users
                    .Where(r => r.RoomType == roomType &&
                                ((r.CheckInDate >= checkInDate && r.CheckInDate < checkOutDate) ||
                                 (r.CheckOutDate > checkInDate && r.CheckOutDate <= checkOutDate)))
                    .ToListAsync();

                // Eğer mevcut rezervasyonlar yoksa, oda uygun demektir
                if (!existingReservations.Any())
                {
                    return true;
                }

                // Eğer mevcut rezervasyonlar varsa, oda uygun değildir
                return false;
            }
            catch (Exception)
            {
                // Oda uygunluğunu kontrol ederken bir hata oluştu
                return false;
            }
        }
    }

}
