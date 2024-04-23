using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repository.Contracts;
using Services.Contracts;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EFCore
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CheckRoomAvailabilityAsync(UserDto user)
        {
            try
            {
                // Veritabanından kullanıcının seçtiği tarih aralığında dolu olan odaları getir
                var reservedRooms = await _repository.Room.FindByCondition(r => r.CheckInDate <= user.CheckOutDate &&
                r.CheckOutDate >= user.CheckInDate).ToListAsync();

                // Seçilen oda tipine göre dolu odaları filtrele
                var filteredReservedRooms = reservedRooms.Where(r => r.RoomType == user.RoomType);

                // Seçilen oda tipindeki odaların sayısını al
                var selectedRoomTypeCount = await _repository.Room.CountAsync(r => r.RoomType == user.RoomType);

                // Rezervasyon yapılmak istenen tarih aralığındaki dolu odaların sayısını al
                var reservedRoomCount = filteredReservedRooms.Count();

                // Dolu odaların sayısını azaltarak müsait odaların sayısını bul
                var availableRoomCount = selectedRoomTypeCount - reservedRoomCount;

                // Eğer müsait odaların sayısı 0'dan büyükse true döndür
                return availableRoomCount > 0;
            }
            catch (Exception)
            {
                // Hata durumunda false döndür
                return false;
            }
        }
        public async Task<bool> CreateUser(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                await _repository.User.CreateUserAsync(user);
                await _repository.SaveAsync();
                return true; // Başarıyla kaydedildi
            }
            catch (Exception)
            {
                // Kayıt sırasında bir hata oluştu
                return false;
            }
        }
    }
}